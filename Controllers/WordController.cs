using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomShowEnglish.Service;

namespace RandomShowEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IWordService _wordService;
        public WordController(IWordService wordService)
        {
            this._wordService = wordService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRandsWords(string lessonId)
        {
            Guid id = Guid.Parse(lessonId);
            var words = await this._wordService.GetRandomWord(id);
            return Ok(words);
        }
    }
}