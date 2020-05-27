using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomShowEnglish.Model
{
    public class Word
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Synonym { get; set; }
        public string Mean { get; set; }
        public Lesson Lesson { get; set; }
    }
}
