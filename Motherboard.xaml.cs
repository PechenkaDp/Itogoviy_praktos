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
    /// Логика взаимодействия для Motherboard.xaml
    /// </summary>
    public partial class Motherboard : Page
    {
        MotherboardTableAdapter mat = new MotherboardTableAdapter();
        int cost;
        public Motherboard()
        {
            InitializeComponent();
            MatTabl.ItemsSource = mat.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(mat_name.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(soket.Text) || String.IsNullOrEmpty(size.Text))
                    {

                    }
                    else
                    {
                        cost = Convert.ToInt32(Cost.Text);
                        if (cost > 0)
                        {
                            if (String.IsNullOrEmpty(mat_name.Text) || String.IsNullOrEmpty(soket.Text) || String.IsNullOrEmpty(size.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                mat.InsertQuery(mat_name.Text, soket.Text, size.Text, cost);
                                MatTabl.ItemsSource = mat.GetData();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Низя");
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
                    object id = (MatTabl.SelectedItem as DataRowView).Row[0];
                    mat.DeleteQuery(Convert.ToInt32(id));
                    MatTabl.ItemsSource = mat.GetData();
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

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(mat_name.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(soket.Text) || String.IsNullOrEmpty(size.Text))
                    {

                    }
                    else
                    {
                        object Id = (MatTabl.SelectedItem as DataRowView).Row[0];
                        cost = Convert.ToInt32(Cost.Text);
                        mat.UpdateQuery(mat_name.Text, soket.Text, size.Text, cost, Convert.ToInt32(Id));
                        MatTabl.ItemsSource = mat.GetData();
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
