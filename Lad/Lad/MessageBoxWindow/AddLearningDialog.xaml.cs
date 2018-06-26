using Lad.Models;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using Lad.Content.Views;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для AddLearningDialog.xaml
    /// </summary>
    public partial class AddLearningDialog : Window
    {
        BasicLadaContext context = new BasicLadaContext();
        Section s;
        int CurrentId = 0;
        public AddLearningDialog(int id)
        {
            InitializeComponent();
            CurrentId = id;
            s = context.Sections.FirstOrDefault(g => g.SectionId == id);
        }

        private void AddLearning(object sender, RoutedEventArgs e)
        {
            if (s == null)
                MessageBox.Show("Данные не загружены!!");
            if (NewName.Text.Length == 0 || NewFamily.Text.Length == 0)
                return;
            if (s != null)
            {
                var l = new Learning();
                l.Name = NewFamily.Text;
                l.Family = NewName.Text;
                l.Section = s;
                s.Learnings.Add(l);
                var task = Task<int>.Factory.StartNew(() =>
                {
                   
                    return context.SaveChanges();
                });
                task.Wait();
                // MessageBox.Show(task.IsCompleted == true ? "Выполнено" : "Ошибка сохранения");
                var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                w.Body.Content = new Learnings(CurrentId);
                Close();
            }

        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
