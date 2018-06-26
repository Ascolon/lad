using Lad.Ajax;
using Lad.Content.Views;
using Lad.MessageBoxWindow;
using Lad.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Lad
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AjaxQuery query = new AjaxQuery();
        BasicLadaContext context = new BasicLadaContext();
        List<Section> List = new List<Section>();
        public MainWindow()
        {
            InitializeComponent();
            Sections.ItemsSource = query.AjaxSection();
        }

        private void ShowMenu(object sender, MouseButtonEventArgs e)
        {
            DoubleAnimation buttonAnimation = new DoubleAnimation();
            buttonAnimation.From = Menu.ActualWidth;
            buttonAnimation.To = Menu.ActualWidth == 300 ? MenuIcon.ActualWidth : 300;
            Menu.Background = Menu.ActualWidth == 300 ? new SolidColorBrush(Color.FromRgb(179, 78, 233)) : new SolidColorBrush(Color.FromRgb(192, 218, 215));
            MenuIcon.Margin = Menu.ActualWidth == 300 ? new Thickness(3) : new Thickness(2);
            buttonAnimation.Duration = TimeSpan.FromSeconds(.3);
            Menu.BeginAnimation(WidthProperty, buttonAnimation);
            GridMenu.Visibility = Menu.ActualWidth == 300 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void QuerySectionInput(object sender, TextChangedEventArgs e)
        {
            var s = QuerySection.Text;
            using (BasicLadaContext c = new BasicLadaContext())
            {
                var l = Task.Factory.StartNew(() =>
                {
                    var r = c.Sections.Where(g => g.Name.ToLower().Contains(s.ToLower())).ToList();
                    return r;
                });
                l.Wait();
                Sections.ItemsSource = l.Result;
                if (s == "")
                    Sections.ItemsSource = c.Sections.ToList();
            }
        }

        private void EditSection(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(((Image)sender).Tag);
            EditSectionDialog dialog = new EditSectionDialog(id);
            dialog.ShowDialog();
        }

        private void GetLearningList(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(((TextBlock)sender).Tag);
            Body.Content = new Learnings(id);
        }

        private void DeleteSection(object sender, MouseButtonEventArgs e)
        {
            int id = Convert.ToInt32(((Image)sender).Tag);
            using (BasicLadaContext c = new BasicLadaContext())
            {
                var t = c.Sections.Include(b => b.Learnings).FirstOrDefault(g => g.SectionId == id);
                c.Sections.Remove(t);
                c.SaveChanges();
                Sections.ItemsSource = c.Sections.ToList();
            }
            if (context.Sections.FirstOrDefault() != null)
                Body.Content = new Learnings(context.Sections.FirstOrDefault().SectionId);
            else
                Body.Content = new Startup();
        }

        private void AddSection(object sender, RoutedEventArgs e)
        {
            AddSectionDialog dialog = new AddSectionDialog();
            dialog.ShowDialog();
        }

        private void ShowReport(object sender, RoutedEventArgs e)
        {
            new Report().ShowDialog();
        }
    }
}
