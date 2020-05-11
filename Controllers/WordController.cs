using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RandomShowEnglish.Helper;
using RandomShowEnglish.Model;

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
            var randomWord = GetRandomWord(list);
            var words = new Words
            {
                MainWord = randomWord.Key,
                SynonymWord = randomWord.Value
            };
            return Ok(words);
        }

        private Dictionary<string, string> InitList()
        {
            var listWord = new Dictionary<string, string>()
            {
                {"actor", "performer"},
                {"artist", "virtuoso" },
                {"atmosphere",  "không khí"},
                {"audience", "spectator" },
                {"ballet", "ba lê"},
                {"classical", "classic" },
                {"concert", "show" },
                {"costume", "clothing" },
                {"craft", "handicraft" },
                {"design", "create" },
                {"dramatic", "(thuộc) kịch/ như kịch" },
                {"emotion", "feeling"},
                {"escape", "get away" },
                {"exhibition", "display" },
                {"festival", "fete" },
                {"gallery", "phòng trưng bày tranh tượng" },
                {"image", "hình ảnh" },
                {"influence", "impact" },
                {"landscape", "tranh phong cảnh" },
                {"live", "sống, trực tiếp"},
                {"lyric", "word" },
                {"musical", "lời bài hát" },
                {"musician", "artist" },
                {"painting", "drawing" },
                {"play", "drama" },
                {"poetry", "rhyme" },
                {"popular", "famous" },
                {"relaxing", "calm" },
                {"style", "manner" },
                {"taste", "khiếu thẩm mĩ" },
                {"Celebrate", "Celebration" },
                {"Masquerade", "Masquerade party" },
                {"Parade", "cuộc diễu hành"},
                {"Massive", "huge" },
                {"Tradition", "Traditional" },
                {"early Februry", "đàu tháng hai" },
                {"crowded point", "tụ điểm" },
                {"turning moment", "khoảnh khắc giao thừa" },
                {"Reunion", "họp mặt, đoàn tụ" },
                {"take the chance", "nhân cơ hội" },
                {"Fantastic", "wonderful" },
                {"dress up", "ăn diện lên" }
            };

            return listWord;
        }

        private KeyValuePair<string, string> GetRandomWord(Dictionary<string, string> listWord)
        {
            return listWord.ElementAt(rand.GetRandIns().Next(listWord.Count));
        }
    }
}