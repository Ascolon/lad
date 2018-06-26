using System.Collections.Generic;

namespace Lad.Models
{
    public class Learning
    {
        public int LearningId { get; set; }
        public string Family { get; set; }
        public string Name { get; set; }
        public Section Section { get; set; }
        public ICollection<Achivment> Achivments { get; set; }

        public Learning()
        {
            Achivments = new List<Achivment>();
        }
    }
}