using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Employeer_page.xaml
    /// </summary>
    public partial class Employeer_page : Page
    {
        private VodocanalEntities1 DB = new VodocanalEntities1();
        public Employeer_page()
        {
            InitializeComponent();
            table_grid.ItemsSource = DB.Empl4.ToList();

            empl_id_filter.ItemsSource = DB.Empl4.ToList();
            empl_name_filter.ItemsSource = DB.Empl4.ToList();
            empl_surname_filter.ItemsSource = DB.Empl4.ToList();
            empl_midlename_filter.ItemsSource = DB.Empl4.ToList();
            empl_post_filter.ItemsSource = DB.Posts.ToList();

            empl_id_filter.DisplayMemberPath = "employeer_id";
            empl_name_filter.DisplayMemberPath = "employeer_name";
            empl_surname_filter.DisplayMemberPath = "employeer_surname";
            empl_midlename_filter.DisplayMemberPath = "employeer_middlename";
            empl_post_filter.DisplayMemberPath = "post_name";

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
            table_grid.ItemsSource = DB.Empl4.ToList();
            done_but.IsEnabled = false;
            InterDIS();
        }

        private void done_but_Click(object sender, RoutedEventArgs e)
        {
            done_but.IsEnabled = false;
            if (empl_id_filter.Visibility == Visibility.Visible)
            {
                table_grid.ItemsSource = DB.Empl4.ToList().Where(item =>
                    item.employeer_id == (empl_id_filter.SelectedIndex != -1 ? (empl_id_filter.SelectedItem as Empl4).employeer_id : -1) ||
                    item.employeer_name == (empl_name_filter.SelectedIndex != -1 ? (empl_name_filter.SelectedItem as Empl4).employeer_name : " ") ||
                    item.employeer_surname == (empl_surname_filter.SelectedIndex != -1 ? (empl_surname_filter.SelectedItem as Empl4).employeer_surname : " ") ||
                    item.employeer_middlename == (empl_midlename_filter.SelectedIndex != -1 ? (empl_midlename_filter.SelectedItem as Empl4).employeer_middlename : " ") ||
                    item.post_name == (empl_post_filter.SelectedIndex != -1 ? (empl_post_filter.SelectedItem as Empl4).post_name : " ") 
                );
                
            }
            else
            {
                table_grid.ItemsSource = DB.Empl4.ToList().Where(item => item.employeer_id.ToString().Contains(empl_id.Text) ||
                item.employeer_name.ToString().Contains(empl_id.Text) ||
                item.employeer_surname.ToString().Contains(empl_id.Text) ||
                item.employeer_middlename.ToString().Contains(empl_id.Text) ||
                item.post_name.ToString().Contains(empl_id.Text) ||
                item.post_salary.ToString().Contains(empl_id.Text));
            }

            InterDIS();
        }


        void InterEN(bool filter)
        {
            it.Visibility = Visibility.Visible;
            nt.Visibility = Visibility.Visible;
            st.Visibility = Visibility.Visible;
            mt.Visibility = Visibility.Visible;
            pt.Visibility = Visibility.Visible;
            if (filter)
            {
                empl_id_filter.Visibility = Visibility.Visible;
                empl_name_filter.Visibility = Visibility.Visible;
                empl_surname_filter.Visibility = Visibility.Visible;
                empl_midlename_filter.Visibility = Visibility.Visible;
                empl_post_filter.Visibility = Visibility.Visible;
            }
            else
            {
                empl_id.Visibility = Visibility.Visible;
            }
        }

        void InterDIS()
        {
            empl_id.Text = "";

            empl_id_filter.SelectedIndex = -1;
            empl_name_filter.SelectedIndex = -1;
            empl_surname_filter.SelectedIndex = -1;
            empl_midlename_filter.SelectedIndex = -1;
            empl_post_filter.SelectedIndex = -1;

            empl_id.Visibility = Visibility.Hidden;

            empl_id_filter.Visibility = Visibility.Hidden;
            empl_name_filter.Visibility = Visibility.Hidden;
            empl_surname_filter.Visibility = Visibility.Hidden;
            empl_midlename_filter.Visibility = Visibility.Hidden;
            empl_post_filter.Visibility = Visibility.Hidden;

            it.Visibility = Visibility.Hidden;
            nt.Visibility = Visibility.Hidden;
            st.Visibility = Visibility.Hidden;
            mt.Visibility = Visibility.Hidden;
            pt.Visibility = Visibility.Hidden;
        }
    }
}
