using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для Ohlad.xaml
    /// </summary>
    public partial class Ohlad : Page
    {
        CoolingTableAdapter Cool = new CoolingTableAdapter();
        int NT;
        int NF;
        int Rotate;
        int cost;
        int Sp;

        public Ohlad()
        {
            InitializeComponent();
            OhlTabl.ItemsSource = Cool.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(NumberOfF.Text) || String.IsNullOrEmpty(NumberOfT.Text) || String.IsNullOrEmpty(Rotation.Text) || String.IsNullOrEmpty(Scorost.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(fan_name.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        NT = Convert.ToInt32(NumberOfT.Text);
                        NF = Convert.ToInt32(NumberOfF.Text);
                        Rotate = Convert.ToInt32(Rotation.Text);
                        Sp = Convert.ToInt32(Scorost.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (NT > 0 && NF > 0 && Rotate > 0 && Sp > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(fan_name.Text))
                            {
                                Cool.InsertQuery(fan_name.Text, NT, NF, Rotate, Sp, cost);
                                OhlTabl.ItemsSource = Cool.GetData();
                            }
                            else
                            {
                                MessageBox.Show("Низя");
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
                    object id = (OhlTabl.SelectedItem as DataRowView).Row[0];
                    Cool.DeleteQuery(Convert.ToInt32(id));
                    OhlTabl.ItemsSource = Cool.GetData();
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
                    if (String.IsNullOrEmpty(NumberOfF.Text) || String.IsNullOrEmpty(NumberOfT.Text) || String.IsNullOrEmpty(Rotation.Text) || String.IsNullOrEmpty(Scorost.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(fan_name.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        object Id = (OhlTabl.SelectedItem as DataRowView).Row[0];
                        NT = Convert.ToInt32(NumberOfT.Text);
                        NF = Convert.ToInt32(NumberOfF.Text);
                        Rotate = Convert.ToInt32(Rotation.Text);
                        Sp = Convert.ToInt32(Scorost.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (NT > 0 && NF > 0 && Rotate > 0 && Sp > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(fan_name.Text))
                            {
                                Cool.UpdateQuery(fan_name.Text, NT, NF, Rotate, Sp, cost, Convert.ToInt32(Id));
                                OhlTabl.ItemsSource = Cool.GetData();
                            }
                            else
                            {
                                MessageBox.Show("Низя");
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
