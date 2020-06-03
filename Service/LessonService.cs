using DocumentFormat.OpenXml.ExtendedProperties;
using Mapster;
using Microsoft.AspNetCore.Http;
using RandomShowEnglish.Model;
using RandomShowEnglish.Repository;
using RandomShowEnglish.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Service
{
    public class LessonService : ILessonService
    {
        private readonly IFileService _fileService;
        private readonly ILessonRepository _lessonRepository;
        private readonly IWordService _wordService;
        private readonly static Random random = new Random();
        public LessonService(IFileService fileService, ILessonRepository lessonRepository, IWordService wordService)
        {
            this._fileService = fileService;
            this._lessonRepository = lessonRepository;
            this._wordService = wordService;
        }
        public async Task CreateLesson(LessonViewModel lessonViewModel, IFormFile file)
        {
            var id = Guid.NewGuid();

            // create new lesson
            var listWordFromFile = await this._fileService.GetListWordAsync(file);

            var lesson = lessonViewModel.Adapt<Lesson>();
            lesson.Id = id;

            // save lesson
            await this._lessonRepository.Create(lesson);

            // set id for all list words
            var listwords = await this._wordService.SetLessonIdListWordsAsync(listWordFromFile, lesson);
            listWordFromFile = listwords.ToList();

            // save list word
            await this._wordService.CreateListWords(listWordFromFile);
        }

        public async Task<IEnumerable<Lesson>> GetAllLesson()
        {
            return await this._lessonRepository.GetLessons();
        }
    }
}
