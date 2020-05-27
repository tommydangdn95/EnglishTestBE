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
        private readonly IWordRepository _wordRepository;
        private readonly static Random random = new Random();
        public LessonService(IFileService fileService, ILessonRepository lessonRepository, IWordRepository wordRepository)
        {
            this._fileService = fileService;
            this._lessonRepository = lessonRepository;
            this._wordRepository = wordRepository;
        }
        public async Task CreateLesson(LessonViewModel lessonViewModel, IFormFile file)
        {
            var id = Guid.NewGuid();

            // create new lesson
            var listWord = await this._fileService.GetListWordAsync(file);

            // save lesson
            var lesson = lessonViewModel.Adapt<Lesson>();
            lesson.Id = id;
            await this._lessonRepository.Create(lesson);

            // save list word
            await this._wordRepository.CreateRange(listWord);
        }

        public async Task<WordViewModel> GetRandomWord(Guid lessonId)
        {
            var listWords = await this.GetListWord(lessonId);
            if(listWords != null)
            {
                if(listWords.Count() > 0)
                {
                    var word = listWords.ToList().ElementAt(random.Next(listWords.Count()));
                    return word.Adapt<WordViewModel>();
                } 
            }
            return new WordViewModel();
        }

        public async Task<IEnumerable<Word>> GetListWord(Guid lessonId)
        {
            return await this._wordRepository.GetWordByLesson(lessonId);
        }
    }
}
