using Microsoft.AspNetCore.Http;
using RandomShowEnglish.Model;
using RandomShowEnglish.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Service
{
    public interface ILessonService
    {
        Task CreateLesson(LessonViewModel lesson, IFormFile file);
        Task<IEnumerable<Lesson>> GetAllLesson();
    }
}
