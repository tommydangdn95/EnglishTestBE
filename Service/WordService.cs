using Mapster;
using RandomShowEnglish.Helper;
using RandomShowEnglish.Model;
using RandomShowEnglish.Repository;
using RandomShowEnglish.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Service
{
    public class WordService : IWordService
    {
        private readonly IWordRepository _wordRepository;
        private readonly Randomize rand = new Randomize();
        public WordService(IWordRepository wordRepository)
        {
            this._wordRepository = wordRepository;
        }

        public async Task CreateListWords(IEnumerable<Word> listWords)
        {
            await this._wordRepository.CreateRange(listWords);
        }

        public async Task<IEnumerable<Word>> GetListWord(Guid lessonId)
        {
            return await this._wordRepository.GetWordByLesson(lessonId);
        }

        public async Task<WordViewModel> GetRandomWord(Guid lessonId)
        {
            var listWords = await this.GetListWord(lessonId);
            if (listWords != null)
            {
                if (listWords.Count() > 0)
                {
                    var word = listWords.ToList().ElementAt(rand.GetRandom.Next(listWords.Count()));
                    return word.Adapt<WordViewModel>();
                }
            }
            return new WordViewModel();
        }

        public async Task<IEnumerable<Word>> SetLessonIdListWordsAsync(IEnumerable<Word> listWords, Lesson lesson)
        {
            return await Task.FromResult(SetLessonIdForListWords(listWords, lesson));
        }


        private IEnumerable<Word> SetLessonIdForListWords(IEnumerable<Word> listWords, Lesson lesson)
        {
            return listWords.Select(l =>
            {
                l.Lesson = lesson;
                return l;
            });
        }
    }
}
