using Microsoft.EntityFrameworkCore;
using RandomShowEnglish.Entity;
using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public class LessonRepository : ILessonRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public LessonRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task Create(Lesson lesson)
        {
            this._dbContext.Lessons.Add(lesson);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task Delete(Lesson lesson)
        {
            this._dbContext.Lessons.Remove(lesson);
            await this._dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Lesson>> GetLessons()
        {
            var lessons = await this._dbContext.Lessons.ToListAsync();
            return lessons;
        }

        public async Task<Lesson> GetLesson(Guid id)
        {
            var lesson = await this._dbContext.Lessons.FindAsync(id);
            return lesson;
        }

        public async Task Update(Lesson lesson)
        {
            this._dbContext.Lessons.Update(lesson);
            await this._dbContext.SaveChangesAsync();
        }
    }
}
