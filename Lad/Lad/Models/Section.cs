using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lad.Models
{
    public class Section
    {
        public int SectionId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public ICollection<Learning> Learnings { get; set; }
        public ICollection<Achivment> Achivments { get; set; }

        public Section()
        {
            Learnings = new List<Learning>();
            Achivments = new List<Achivment>();
        }
    }
}
