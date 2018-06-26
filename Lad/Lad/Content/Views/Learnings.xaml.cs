using Lad.Ajax;
using Lad.Models;
using System.Windows.Controls;
using System.Windows.Input;
using System.Data.Entity;
using System.Linq;
using Lad.MessageBoxWindow;
using System.Windows;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Lad.Content.Views
{
    /// <summary>
    /// Логика взаимодействия для Learnings.xaml
    /// </summary>
    public partial class Learnings : Page
    {
        OpenFileDialog selectImage = new OpenFileDialog();
        AjaxQuery query = new AjaxQuery();
        BasicLadaContext context = new BasicLadaContext();
        private int CurrentIdSection = 0;
        public Learnings(int id)
        {
            InitializeComponent();
            CurrentIdSection = id;
            LearningsList.ItemsSource = query.AjaxLearning(id);
        }

        private void DeleteOneLearning(object sender, MouseButtonEventArgs e)
        {
            var id = int.Parse(((Image)sender).Tag.ToString());
            var l = context.Learnings.Include(g => g.Achivments).FirstOrDefault(g => g.LearningId == id);
            var l1 = context.Learnings.Include(g => g.Achivments).FirstOrDefault(g => g.LearningId == id).Achivments;
            context.Learnings.Remove(l);
            context.SaveChanges();
            LearningsList.ItemsSource = query.AjaxLearning(CurrentIdSection);
            context.Achivments.RemoveRange(l1);
            context.SaveChanges();
        }

        private void AddLearning(object sender, System.Windows.RoutedEventArgs e)
        {
            AddLearningDialog dialog = new AddLearningDialog(CurrentIdSection);
            dialog.ShowDialog();
        }

        private void AddAchivmentForLearning(object sender, MouseButtonEventArgs e)
        {
            var id = int.Parse(((Image)sender).Tag.ToString());
            AddAchivmentDialog dialog = new AddAchivmentDialog(id);
            dialog.ShowDialog();
        }

        private void DeleteAchivmentFromLearning(object sender, MouseButtonEventArgs e)
        {
            var id = int.Parse(((Image)sender).Tag.ToString());
            context.Achivments.Remove(context.Achivments.FirstOrDefault(g => g.AchivmentId == id));
            context.SaveChanges();
            // MessageBox.Show("Удаленно");
            var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            w.Body.Content = new Learnings(CurrentIdSection);
        }

        private void EditAchivmentFromLearning(object sender, MouseButtonEventArgs e)
        {
            var id = int.Parse(((Image)sender).Tag.ToString());
            EditAchivmentDialog dialog = new EditAchivmentDialog(id);
            dialog.ShowDialog();
        }

        private void EditLearning(object sender, MouseButtonEventArgs e)
        {
            var id = int.Parse(((Image)sender).Tag.ToString());
            EditLearningDialog dialog = new EditLearningDialog(id);
            dialog.ShowDialog();
        }
    }
}
