using Lad.Content.Views;
using Lad.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Entity;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для EditLearningDialog.xaml
    /// </summary>
    public partial class EditLearningDialog : Window
    {
        BasicLadaContext context = new BasicLadaContext();
        Learning l;
        int CurrentLearningId = 0;
        public EditLearningDialog(int id)
        {
            InitializeComponent();
            CurrentLearningId = id;
            InitializeComponent();
            l = context.Learnings.Include(g => g.Section).FirstOrDefault(g => g.LearningId == CurrentLearningId);
            NewName.Text = l.Name;
            NewFamily.Text = l.Family;
        }

        private void EditLearning(object sender, RoutedEventArgs e)
        {
            var id = l.Section.SectionId;
            if (NewName.Text.Length == 0 || NewFamily.Text.Length == 0)
                return;
            l.Name = NewName.Text;
            l.Family = NewFamily.Text;
            var task = Task<int>.Factory.StartNew(() =>
            {
                return context.SaveChanges();
            });
            task.Wait();
            // MessageBox.Show(task.IsCompleted == true ? "Выполнено" : "Ошибка");
            var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            w.Body.Content = new Learnings(id);
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
