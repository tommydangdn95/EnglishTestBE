using RandomShowEnglish.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Repository
{
    public interface ILessonRepository
    {
        Task<IEnumerable<Lesson>> GetLessons();
        Task<Lesson> GetLesson(Guid id);
        Task Create(Lesson lesson);
        Task Update(Lesson lesson);
        Task Delete(Lesson lesson);
    }
}
