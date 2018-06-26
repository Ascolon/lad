using Lad.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для EditSectionDialog.xaml
    /// </summary>
    public partial class EditSectionDialog : Window
    {
        BasicLadaContext context = new BasicLadaContext();
        Section s;
        public EditSectionDialog(int id)
        {
            InitializeComponent();
            s = context.Sections.FirstOrDefault(g => g.SectionId == id);
        }


        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Editing(object sender, RoutedEventArgs e)
        {
            if(s == null)
                MessageBox.Show("Данные не загружены!!");
            if (NewName.Text.Length == 0)
                return;
            if(s != null)
            {
                s.Name = NewName.Text;
                var task = Task<int>.Factory.StartNew(() => 
                {
                    return context.SaveChanges();
                });
                task.Wait();
                // MessageBox.Show(task.IsCompleted == true ? "Выполнено" : "Ошибка сохранения");
                var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
                w.Sections.ItemsSource = context.Sections.ToList();
                Close();
            }
        }
    }
}
