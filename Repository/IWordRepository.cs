using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public interface IWordRepository
    {
        Task<IEnumerable<Word>> GetWords();
        Task<Word> GetWord(Guid id);
        Task Create(Word word);
        Task Update(Word word);
        Task Delete(Word word);
        Task CreateRange(IEnumerable<Word> words);

        Task<IEnumerable<Word>> GetWordByLesson(Guid lessonId);
    }
}
