using Microsoft.EntityFrameworkCore;
using RandomShowEnglish.Entity;
using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public class WordRepository : IWordRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public WordRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Create(Word word)
        {
            await this._dbContext.Words.AddAsync(word);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task CreateRange(List<Word> words)
        {
            await this._dbContext.Words.AddRangeAsync(words);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task Delete(Word word)
        {
            this._dbContext.Words.Remove(word);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<Word> GetWord(Guid id)
        {
            var word = await this._dbContext.Words.FindAsync(id);
            return word;
        }

        public async Task<IEnumerable<Word>> GetWordByLesson(Guid lessonId)
        {
            var words = await this._dbContext.Words.Where(w => w.Lesson.Id == lessonId).ToListAsync();
            return words;
        }

        public async Task<IEnumerable<Word>> GetWords()
        {
            var words = await this._dbContext.Words.ToListAsync();
            return words;
        }

        public async Task Update(Word word)
        {
            this._dbContext.Words.Update(word);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
