using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomShowEnglish.Service;
using RandomShowEnglish.ViewModel;

namespace RandomShowEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        public LessonController(ILessonService lessonService)
        {
            this._lessonService = lessonService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromForm]LessonViewModel lesson, IFormFile file)
        {
            if (lesson != null && file != null && file.Length > 0)
            {
                await this._lessonService.CreateLesson(lesson, file);
                return Ok();
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetWord()
        {
            Guid id = Guid.Parse("AB4A9079-E48E-4732-A429-6273CACD7663");
            var words = await this._lessonService.GetRandomWord(id);
            return Ok(words);
        }
    }
}