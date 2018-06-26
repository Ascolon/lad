using Lad.Models;
using System;
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
    /// Логика взаимодействия для AddSectionDialog.xaml
    /// </summary>
    public partial class AddSectionDialog : Window
    {
        Models.Section s = new Models.Section();
        public AddSectionDialog()
        {
            InitializeComponent();
        }

        private void AddSection(object sender, RoutedEventArgs e)
        {
            BasicLadaContext c = new BasicLadaContext();
            s.Name = NewName.Text;
            if (NewName.Text.Length == 0)
                return;
            var task = Task<int>.Factory.StartNew(() =>
            {
                c.Sections.Add(s);
                return c.SaveChanges();
            });
            task.Wait();
            // MessageBox.Show(task.IsCompleted == true ? "Выполнено" : "Ошибка создания");
            var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            w.Sections.ItemsSource = c.Sections.ToList();
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
