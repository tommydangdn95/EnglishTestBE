using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Model
{
    public class Lesson
    {
        public Guid Id { get; set; } 
        public string Name { get; set; }
        public bool IsUsed { get; set; }
        public IEnumerable<FileUpload> FileUploads { get; set; }
        public IEnumerable<Word> Words { get; set; }
    }
}
