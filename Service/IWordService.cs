using RandomShowEnglish.Model;
using RandomShowEnglish.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Service
{
    public interface IWordService
    {
        Task<WordViewModel> GetRandomWord(Guid lessonId);
        Task<IEnumerable<Word>> GetListWord(Guid lessonId);
        Task<IEnumerable<Word>> SetLessonIdListWordsAsync(IEnumerable<Word> listWords, Lesson lesson);
        Task CreateListWords(IEnumerable<Word> listWords);
    }
}
