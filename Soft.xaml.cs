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
using Itogoviy_praktos.itogDataSetTableAdapters;

namespace Itogoviy_praktos
{
    /// <summary>
    /// Логика взаимодействия для Soft.xaml
    /// </summary>
    public partial class Soft : Page
    {
        SoftwareTableAdapter soft = new SoftwareTableAdapter();
        int Cap;
        int cost;
        public Soft()
        {
            InitializeComponent();
            SoftTabl.ItemsSource = soft.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            if (globalVariables.ID == 1)
            {
                if (String.IsNullOrEmpty(cap.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(sof_name.Text))
                {
                    MessageBox.Show("Низя");
                }
                else
                {
                    Cap = Convert.ToInt32(cap.Text);
                    cost = Convert.ToInt32(Cost.Text);
                    if (Cap > 0 || cost > 0)
                    {
                        if (String.IsNullOrEmpty(sof_name.Text))
                        {
                            MessageBox.Show("Ошибка 0");
                        }
                        else
                        {
                            soft.InsertQuery(sof_name.Text, Cap, cost);
                            SoftTabl.ItemsSource = soft.GetData();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Число должно быть больше 0");
                    }
                }


            }
            else
            {
                MessageBox.Show("Низя");
            }
        }
            catch
            {
                MessageBox.Show("Вы ввели что-то неправильно");
            }

        }

        private void Ydalenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    object id = (SoftTabl.SelectedItem as DataRowView).Row[0];
                    soft.DeleteQuery(Convert.ToInt32(id));
                    SoftTabl.ItemsSource = soft.GetData();
                }
                else
                {
                    MessageBox.Show("Низя");
                }
            }
            catch
            {
                MessageBox.Show("Вы не выбрали");
            }


        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            if (globalVariables.ID == 1)
            {
                if (String.IsNullOrEmpty(cap.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(sof_name.Text))
                {
                    MessageBox.Show("Низя");
                }
                else
                {
                    if (Cap > 0 || cost > 0)
                    {
                        if (String.IsNullOrEmpty(sof_name.Text))
                        {
                            MessageBox.Show("");
                        }
                        else
                        {
                            object Id = (SoftTabl.SelectedItem as DataRowView).Row[0];
                            Cap = Convert.ToInt32(cap.Text);
                            cost = Convert.ToInt32(Cost.Text);
                            soft.UpdateQuery(sof_name.Text, Cap, cost, Convert.ToInt32(Id));
                            SoftTabl.ItemsSource = soft.GetData();
                        }

                    }
                    else
                    {
                        MessageBox.Show("");
                    }
                }
            }

            else
            {
                MessageBox.Show("Низя");
            }
        }
            catch
            {
                MessageBox.Show("Вы ввели что-то неправильно");
            }


        }
    }
}
