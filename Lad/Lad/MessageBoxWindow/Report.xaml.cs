using Lad.Ajax;
using Lad.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        public Report()
        {
            InitializeComponent();
            ReportDefault.ItemsSource = GetAllSections();
            //Competetive.ItemsSource = new ComboBoxData().GetCompetition();
        }

        public List<dynamic> GetAllSections()
        {
            var t = new List<dynamic>();
            using (Models.BasicLadaContext b = new Models.BasicLadaContext())
            {
                var sections = b.Sections.Include(s => s.Achivments).ToList();
                foreach (Models.Section s in sections)
                {
                    var section = new
                    {
                        CestionName = s.Name,
                        LearningsCount = b.Learnings.Where(l => l.Section.SectionId == s.SectionId).Count(),
                        Learnings = b.Learnings.Where(l => l.Section.SectionId == s.SectionId).Include(g => g.Achivments).ToList(),
                    };
                    t.Add(section);
                }
                return t.ToList();
        }
    }

        private void CompetetiveOrder(object sender, SelectionChangedEventArgs e)
        {
            //var s = (Competetive.SelectedItem as string);
        }

        private void SearchData(object sender, RoutedEventArgs e)
        {
            if (LearningName.Text.Length == 0)
                return;
            using (BasicLadaContext b = new BasicLadaContext())
            {
                var learnings = b.Learnings
                    .Include(s => s.Achivments)
                    .ToList()
                    .Where(l => l.Family.ToLower().Contains(LearningName.Text.ToLower()) ||
                    l.Name.ToLower().Contains(LearningName.Text.ToLower()));
                LearningData.ItemsSource = learnings;
                LearningData.Visibility = Visibility.Visible;
                ScrollReport.Visibility = Visibility.Collapsed;
            }
        }
    }
}
