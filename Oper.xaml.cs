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
    /// Логика взаимодействия для Oper.xaml
    /// </summary>
    public partial class Oper : Page
    {
        RAMTableAdapter Operat = new RAMTableAdapter();
        int cost;
        int cap;
        int RAMf;
        public Oper()
        {
            InitializeComponent();
            OperTabl.ItemsSource = Operat.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(Capa.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Ram_name.Text) || String.IsNullOrEmpty(ram_f.Text))
                    {

                    }
                    else
                    {
                        cap = Convert.ToInt32(Capa.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (cap > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(Ram_name.Text) || String.IsNullOrEmpty(ram_f.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                Operat.InsertQuery(Ram_name.Text, cap, ram_f.Text, cost);
                                OperTabl.ItemsSource = Operat.GetData();
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
                    object id = (OperTabl.SelectedItem as DataRowView).Row[0];
                    Operat.DeleteQuery(Convert.ToInt32(id));
                    OperTabl.ItemsSource = Operat.GetData();
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
                    if (String.IsNullOrEmpty(Capa.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(Ram_name.Text) || String.IsNullOrEmpty(ram_f.Text))
                    {

                    }
                    else
                    {
                        object Id = (OperTabl.SelectedItem as DataRowView).Row[0];
                        cap = Convert.ToInt32(Capa.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (cap > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(Ram_name.Text) || String.IsNullOrEmpty(ram_f.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                Operat.UpdateQuery(Ram_name.Text, cap, ram_f.Text, cost, Convert.ToInt32(Id));
                                OperTabl.ItemsSource = Operat.GetData();
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
