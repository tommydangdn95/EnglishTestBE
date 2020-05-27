using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Model
{
    public class FileUpload
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string Path { get; set; }
        public int FileType { get; set; }
        public Lesson Lesson { get; set; }
    }
}
