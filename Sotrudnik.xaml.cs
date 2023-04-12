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
using System.Windows.Shapes;
using Itogoviy_praktos.itogDataSetTableAdapters;

namespace Itogoviy_praktos
{
    /// <summary>
    /// Логика взаимодействия для Sotrudnik.xaml
    /// </summary>
    public partial class Sotrudnik : Window
    {
        personalTableAdapter persona = new personalTableAdapter();
        int Role_int;
        int Role1;
        int num;
        public Sotrudnik()
        {
            InitializeComponent();
            PersTabl.ItemsSource = persona.GetData();
            RoleP.ItemsSource = persona.GetData();
            RoleP.DisplayMemberPath = "role_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adm = new AdminWindow();
            adm.Show();
            Close();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            try { 
            var allLogins = persona.GetData().Rows;
            string idsh = "1";
            string idsh2 = "2";
            int a = 0;
            int b = 0;
            int sel_id;


            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == idsh)
                {
                    a = a + 1;

                }

                if (allLogins[i][2].ToString() == idsh2)
                {
                    b = b + 1;

                }
            }
            if (a > 1)
            {
                object id = (PersTabl.SelectedItem as DataRowView).Row[0];
                object rol = (PersTabl.SelectedItem as DataRowView).Row[2];
                sel_id = (int)rol;
                if (sel_id == 1)
                {
                    persona.DeleteQuery(Convert.ToInt32(id));
                    PersTabl.ItemsSource = persona.GetData();
                }
                else
                {
                    MessageBox.Show("Единственного пользователя нельзя удалить");
                }

            }
            if (b > 1)
            {
                object id = (PersTabl.SelectedItem as DataRowView).Row[0];
                object rol = (PersTabl.SelectedItem as DataRowView).Row[2];
                sel_id = (int)rol;
                if (sel_id == 2)
                {
                    persona.DeleteQuery(Convert.ToInt32(id));
                    PersTabl.ItemsSource = persona.GetData();
                }
                else
                {
                    MessageBox.Show("Единственного админа нельзя удалить");
                }

            }
            if (a == 1)
            {
                MessageBox.Show("Напоминалка: Единственного админа нельзя удалить");
            }
            if (b == 1)
            {
                MessageBox.Show("Напоминалка: Единственного пользователя нельзя удалить");
            }
        }
            catch
            {
                MessageBox.Show("Вы не выбрали строку для удаления");
            }
            

        }
        private void RoleP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object role = (RoleP.SelectedItem as DataRowView).Row[2];
            Role1 = (int)role;
            
            

        }

        private void Dobavl_Click(object sender, RoutedEventArgs e)
        {
            try { 
            int err = 0;
            string osh = NameZet.Text;
            var allLogins = persona.GetData().Rows;
            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][1].ToString() == osh)
                {
                    MessageBox.Show("Данное имя уже существует");
                    err = err + 1;
                    break;

                }
            }
            if (err == 0)
            {
                if (String.IsNullOrEmpty(NameZet.Text) || String.IsNullOrEmpty(Passw.Text))
                {
                    MessageBox.Show("Логин или пароль пустой");
                }
                else
                {
                    Role_int = Convert.ToInt32(Role1);
                    persona.InsertQuery(NameZet.Text, Role_int, Passw.Text);
                    PersTabl.ItemsSource = persona.GetData();
                }



            }
        }
            catch
            {
                MessageBox.Show("Вы вели что-то не то");
            }


        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {

            try { 
            var allLogins = persona.GetData().Rows;
            string idsh = "1";
            int a = 0;


            for (int i = 0; i < allLogins.Count; i++)
            {
                if (allLogins[i][2].ToString() == idsh)
                {
                    a = a + 1;

                }

            }
            if (a > 1)
            {
                if (String.IsNullOrEmpty(NameZet.Text) || String.IsNullOrEmpty(Passw.Text))
                {
                    MessageBox.Show("Логин или пароль пустой");
                }
                else
                {
                    object Id = (PersTabl.SelectedItem as DataRowView).Row[0];
                    Role_int = Convert.ToInt32(Role1);
                    persona.UpdateQuery(NameZet.Text, Role_int, Passw.Text, Convert.ToInt32(Id));
                    PersTabl.ItemsSource = persona.GetData();
                }



            }
            if (a == 1)
            {
                MessageBox.Show("Напоминалка: Единственного админа нельзя изменить");
            }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали строку или ввели что-то не то");
            }

        }
    }
}
