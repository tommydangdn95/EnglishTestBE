using Microsoft.AspNetCore.Http;
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
        Task<WordViewModel> GetRandomWord(Guid lessonId);
    }
}
