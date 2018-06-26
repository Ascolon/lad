using Lad.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Lad.Content.Views;
using System.Data.Entity;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для EditAchivmentDialog.xaml
    /// </summary>
    public partial class EditAchivmentDialog : Window
    {
        BasicLadaContext context = new BasicLadaContext();
        Achivment l;
        int CurrentAchivmentId = 0;
        public EditAchivmentDialog(int id)
        {
            CurrentAchivmentId = id;
            InitializeComponent();
            l = context.Achivments.FirstOrDefault(g => g.AchivmentId == CurrentAchivmentId);
            NewName.Text = l.Name;
            Result.Text = l.Result;
            Desc.Text = l.Description;
        }

        private void EditAchivment(object sender, RoutedEventArgs e)
        {
            var hack = context.Learnings.Include(g => g.Section);
            var y = hack.AsEnumerable().FirstOrDefault(g => g.Achivments.Contains(l)).Section.SectionId;
            //var id = y.Section.SectionId;
            // MessageBox.Show(y.ToString());
            ///UPDATE
            if (NewName.Text.Length == 0 || Result.Text.Length == 0 || Desc.Text.Length == 0)
                return;
            l.Name = NewName.Text;
            l.Result = Result.Text;
            l.Description = Desc.Text;
            var task = Task<int>.Factory.StartNew(() =>
            {
                return context.SaveChanges();
            });
            task.Wait();
            // MessageBox.Show(task.IsCompleted == true ? "Выполнено" : "Ошибка");
            var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            w.Body.Content = new Learnings(y);
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
