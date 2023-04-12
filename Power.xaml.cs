using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
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
    /// Логика взаимодействия для Power.xaml
    /// </summary>
    public partial class Power : Page
    {
        Power_SupplyTableAdapter pow = new Power_SupplyTableAdapter();
        int CAp;
        int cost;

        public Power()
        {
            InitializeComponent();
            PowTabl.ItemsSource = pow.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            if (globalVariables.ID == 1)
            {
                if (String.IsNullOrEmpty(Cap.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Pow_name.Text))
                {

                }
                else
                {
                    CAp = Convert.ToInt32(Cap.Text);
                    cost = Convert.ToInt32(Cost.Text);
                    if (CAp > 0 && cost > 0)
                    {
                        if (String.IsNullOrEmpty(Pow_name.Text))
                        {
                            MessageBox.Show("Низя");
                        }
                        else
                        {
                            pow.InsertQuery(Pow_name.Text, CAp, cost);
                            PowTabl.ItemsSource = pow.GetData();
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
                    object id = (PowTabl.SelectedItem as DataRowView).Row[0];
                    pow.DeleteQuery(Convert.ToInt32(id));
                    PowTabl.ItemsSource = pow.GetData();
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
                    if (String.IsNullOrEmpty(Cap.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Pow_name.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        object Id = (PowTabl.SelectedItem as DataRowView).Row[0];
                        CAp = Convert.ToInt32(Cap.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (CAp > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(Pow_name.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                pow.UpdateQuery(Pow_name.Text, CAp, cost, Convert.ToInt32(Id));
                                PowTabl.ItemsSource = pow.GetData();
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
    }
}
