using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Migrations;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PRACT_LAB_2_EF
{
    /// <summary>
    /// Логика взаимодействия для Post_page.xaml
    /// </summary>
    public partial class Post_page : Page
    {
        private VodocanalEntities1 DB = new VodocanalEntities1();
        public Post_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Posts.ToList();

            table_grid.ItemsSource = DB.Posts.ToList();
            post_id_filter.ItemsSource = DB.Posts.ToList();
            post_name_filter.ItemsSource = DB.Posts.ToList();
            post_salary_filter.ItemsSource = DB.Posts.ToList();
            post_id_filter.DisplayMemberPath = "post_id";
            post_name_filter.DisplayMemberPath = "post_name";
            post_salary_filter.DisplayMemberPath = "post_salary";
        }

        private void search_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN(false);
            done_but.IsEnabled = true;
        }

        private void filter_but_Click(object sender, RoutedEventArgs e)
        {
            InterDIS();
            InterEN(true);
            done_but.IsEnabled = true;
        }

        private void cancel_but_Click(object sender, RoutedEventArgs e)
        {
            table_grid.ItemsSource = DB.Posts.ToList();
            done_but.IsEnabled = false;
            InterDIS();
        }

        private void done_but_Click(object sender, RoutedEventArgs e)
        {
            done_but.IsEnabled = false;
            if (post_id_filter.Visibility == Visibility.Visible)
            {
                table_grid.ItemsSource = DB.Posts.ToList().Where(item =>
                    item.post_id == (post_id_filter.SelectedItem != null ? (post_id_filter.SelectedItem as Posts).post_id : -1) ||
                    item.post_name == (post_name_filter.SelectedItem as Posts != null ? (post_name_filter.SelectedItem as Posts).post_name : " ") ||
                    item.post_salary == (post_salary_filter.SelectedItem as Posts != null ? (post_salary_filter.SelectedItem as Posts).post_salary : -1));
            }
            else
            {
                table_grid.ItemsSource = DB.Posts.ToList().Where(item => item.post_id.ToString().Contains(post_id.Text) || item.post_name.ToString().Contains(post_id.Text) || item.post_salary.ToString().Contains(post_id.Text));
            }
            InterDIS();
        }

        void InterEN(bool filter)
        {
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            it.Visibility = Visibility.Visible;
            if (filter)
            {
                post_id_filter.Visibility = Visibility.Visible;
                post_name_filter.Visibility = Visibility.Visible;
                post_salary_filter.Visibility = Visibility.Visible;
            }
            else
            {
                post_id.Visibility = Visibility.Visible;
            }
        }

        void InterDIS()
        {
            post_id.Text = "";

            post_name_filter.SelectedIndex = -1;
            post_salary_filter.SelectedIndex = -1;
            post_id_filter.SelectedIndex = -1;

            post_id.Visibility = Visibility.Hidden;

            post_name_filter.Visibility = Visibility.Hidden;
            post_salary_filter.Visibility = Visibility.Hidden;
            post_id_filter.Visibility = Visibility.Hidden;

            it.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
        }
    }
}
