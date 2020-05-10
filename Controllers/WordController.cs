using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomShowEnglish.Helper;

namespace RandomShowEnglish.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WordController : ControllerBase
    {
        private readonly IRandInstance rand;
        public WordController(IRandInstance rand)
        {
            this.rand = rand;
        }

        [HttpGet]
        public IActionResult ShowRandomWord()
        {
            var list = InitList();
            return Ok(GetRandomWord(list));
        }

        private List<string> InitList()
        {
            var listWord = new List<string>()
            {
                "actor",
                "performer",
                "artist",
                "virtuoso",
                "atmosphere",
                "audience",
                "ballet",
                "classical",
                "concert",
                "show",
                "costume",
                "clothing",
                "craft",
                "handicraft",
                "design",
                "create",
                "dramatic",
                "emotion",
                "feeling",
                "escape",
                "get away",
                "exhibition",
                "display",
                "festival",
                "fete",
                "gallery",
                "image",
                "influence",
                "impact",
                "landscape",
                "live",
                "lyric",
                "word",
                "musical",
                "musician",
                "artist",
                "painting",
                "drawing",
                "play",
                "drama",
                "poetry",
                "rhyme",
                "popular",
                "famous",
                "relaxing",
                "calm",
                "style",
                "manner",
                "taste",
                "Celebrate",
                "Celebration",
                "Celebratory",
                "Masquerade",
                "Parade",
                "Massive",
                "Tradition",
                "early Februry",
                "crowded point",
                "turning moment",
                "Reunion",
                "take the chance",
                "Fantastic",
                "dress up"
            };

            return listWord;
        }

        private string GetRandomWord(List<string> listWord)
        {
            int index = rand.GetRandIns().Next(listWord.Count);
            return listWord[index];
        }
    }
}