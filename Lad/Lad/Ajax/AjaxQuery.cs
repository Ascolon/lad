using Lad.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Lad.Ajax
{
    public class AjaxQuery
    {
        BasicLadaContext context = new BasicLadaContext();

        public List<Section> AjaxSection()
        {
            return context.Sections.ToList();
        }

        public List<Learning> AjaxLearning(int id)
        {
            return context.Learnings
                .Include(g => g.Achivments)
                .Where(g => g.Section.SectionId == id).ToList();
        }
    }
}
