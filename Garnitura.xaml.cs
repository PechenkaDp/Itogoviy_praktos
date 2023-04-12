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
    /// Логика взаимодействия для Garnitura.xaml
    /// </summary>
    public partial class Garnitura : Page
    {
        PC_headsetTableAdapter gar = new PC_headsetTableAdapter();
        int cost;
        public Garnitura()
        {
            InitializeComponent();
            GarTabl.ItemsSource = gar.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(Sound.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Netw.Text))
                    {

                    }
                    else
                    {
                        cost = Convert.ToInt32(Cost.Text);
                        if (cost > 0)
                        {
                            if (String.IsNullOrEmpty(Sound.Text) || String.IsNullOrEmpty(Netw.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                gar.InsertQuery(Sound.Text, Netw.Text, cost);
                                GarTabl.ItemsSource = gar.GetData();
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
                    object id = (GarTabl.SelectedItem as DataRowView).Row[0];
                    gar.DeleteQuery(Convert.ToInt32(id));
                    GarTabl.ItemsSource = gar.GetData();
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
                    if (String.IsNullOrEmpty(Sound.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Netw.Text))
                    {

                    }
                    else
                    {
                        object Id = (GarTabl.SelectedItem as DataRowView).Row[0];
                        cost = Convert.ToInt32(Cost.Text);
                        if (cost > 0)
                        {
                            if (String.IsNullOrEmpty(Sound.Text) || String.IsNullOrEmpty(Netw.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                gar.UpdateQuery(Sound.Text, Netw.Text, cost, Convert.ToInt32(Id));
                                GarTabl.ItemsSource = gar.GetData();
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
