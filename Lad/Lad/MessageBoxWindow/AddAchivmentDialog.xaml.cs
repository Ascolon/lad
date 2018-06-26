using Lad.Ajax;
using Lad.Content.Views;
using Lad.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Lad.MessageBoxWindow
{
    /// <summary>
    /// Логика взаимодействия для AddAchivmentDialog.xaml
    /// </summary>
    public partial class AddAchivmentDialog : Window
    {
        OpenFileDialog dialog = new OpenFileDialog();
        BasicLadaContext context = new BasicLadaContext();
        ComboBoxData Data = new ComboBoxData();
        int CurrentLearningId = 0;
        public AddAchivmentDialog(int id)
        {
            InitializeComponent();
            CurrentLearningId = id;
            Type.ItemsSource = Data.AllType();
        }

        private void AddAchivment(object sender, RoutedEventArgs e)
        {
            var learning = context.Learnings.Include(g => g.Section).FirstOrDefault(g => g.LearningId == CurrentLearningId);
            var id = learning.Section.SectionId;
            var section = context.Sections.FirstOrDefault(s => s.SectionId == id);
            if (NewName.Text.Length == 0
                || Result.Text.Length == 0
                || Desc.Text.Length == 0
                || Level.Text == null
                || Type.Text == null
                || dialog.FileName.Length == 0)
            {
                MessageBox.Show("Empty");
                return;
            }
            var achiv = new Achivment()
            {
                Name = NewName.Text,
                Result = Result.Text,
                Description = Desc.Text,
                Level = Level.SelectedItem as string,
                Type = Type.SelectedItem as string,
                Image = ImageName.Text
            };
            learning.Achivments.Add(achiv);
            section.Achivments.Add(achiv);
            var task = Task<int>.Factory.StartNew(() =>
            {
                return context.SaveChanges();
            });
            task.Wait();
            // MessageBox.Show(task.IsCompleted ? "Выполнено" : "Ошибка создания");
            var w = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            w.Body.Content = new Learnings(id);
            Close();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Type_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var text = (sender as ComboBox).SelectedItem as string;
            if (text == "Соревнования") // "Соревнования", "Нормативы", "Разряды"
            {
                Level.ItemsSource = Data.GetCompetition();
            }
            if (text == "Нормативы") // "Соревнования", "Нормативы", "Разряды"
            {
                Level.ItemsSource = Data.GetStandart();

            }
            if (text == "Разряды") // "Соревнования", "Нормативы", "Разряды"
            {
                Level.ItemsSource = Data.GetCategory();
            }
        }

        private void AddImage(object sender, RoutedEventArgs e)
        {
            var t = "";
            if (dialog.ShowDialog() == true)
            {
                ImageName.Text = dialog.FileName;
                //t = dialog.FileName;
            }
            //FileInfo info = new FileInfo(t);
            //info.CopyTo($"Image/{DateTime.Now.ToShortTimeString()}", true);

        }
    }
}
