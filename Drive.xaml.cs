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
    /// Логика взаимодействия для Drive.xaml
    /// </summary>
    public partial class Drive : Page
    {            
            DriveTableAdapter dri = new DriveTableAdapter();
            int mem;
            int process;
            int cost;
        public Drive()
        {
            InitializeComponent();
            DriTabl.ItemsSource = dri.GetData();

        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(Mem.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(procc.Text) || String.IsNullOrEmpty(SSD.Text) || String.IsNullOrEmpty(HDD.Text))
                    {

                    }
                    else
                    {
                        mem = Convert.ToInt32(Mem.Text);
                        process = Convert.ToInt32(procc.Text);
                        cost = Convert.ToInt32(Cost.Text);

                        if (mem > 0 && process > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(SSD.Text) || String.IsNullOrEmpty(HDD.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                dri.InsertQuery(mem, process, SSD.Text, HDD.Text, cost);
                                DriTabl.ItemsSource = dri.GetData();
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
                object id = (DriTabl.SelectedItem as DataRowView).Row[0];
                dri.DeleteQuery(Convert.ToInt32(id));
                DriTabl.ItemsSource = dri.GetData();
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
                    if (String.IsNullOrEmpty(Mem.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(procc.Text) || String.IsNullOrEmpty(SSD.Text) || String.IsNullOrEmpty(HDD.Text))
                    {

                    }
                    else
                    {
                        object id = (DriTabl.SelectedItem as DataRowView).Row[0];
                        mem = Convert.ToInt32(Mem.Text);
                        process = Convert.ToInt32(procc.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (mem > 0 && process > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(SSD.Text) || String.IsNullOrEmpty(HDD.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                dri.UpdateQuery(mem, process, SSD.Text, HDD.Text, cost, Convert.ToInt32(id));
                                DriTabl.ItemsSource = dri.GetData();
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
