using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.ViewModel
{
    public class LessonViewModel
    {
        [Required]
        public string Name { get; set; }
        public bool IsUsed { get; set; }
    }
}
