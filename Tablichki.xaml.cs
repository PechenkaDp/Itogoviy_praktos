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
    /// Логика взаимодействия для Tablichki.xaml
    /// </summary>
    public partial class Tablichki : Page
    {
        int Tsena_int;
        computer_caseTableAdapter korpus = new computer_caseTableAdapter();
        public Tablichki()
        {
            InitializeComponent();
            korpTabl.ItemsSource = korpus.GetData();

        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try { 
            if (globalVariables.ID == 1)
            {
                if (String.IsNullOrEmpty(Tsena.Text) || String.IsNullOrEmpty(SizeS.Text) || String.IsNullOrEmpty(Case_name.Text))
                {

                }
                else
                {
                    Tsena_int = Convert.ToInt32(Tsena.Text);
                    if (Tsena_int > 0)
                    {
                        if (String.IsNullOrEmpty(SizeS.Text) || String.IsNullOrEmpty(Case_name.Text))
                        {
                            MessageBox.Show("Низя");
                        }
                        else
                        {
                            korpus.InsertQuery(Case_name.Text, SizeS.Text, Tsena_int);
                            korpTabl.ItemsSource = korpus.GetData();
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
                    object id = (korpTabl.SelectedItem as DataRowView).Row[0];
                    korpus.DeleteQuery(Convert.ToInt32(id));
                    korpTabl.ItemsSource = korpus.GetData();
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
                    if (String.IsNullOrEmpty(Tsena.Text) || String.IsNullOrEmpty(SizeS.Text) || String.IsNullOrEmpty(Case_name.Text))
                    {

                    }
                    else
                    {
                        object Id = (korpTabl.SelectedItem as DataRowView).Row[0];

                        Tsena_int = Convert.ToInt32(Tsena.Text);
                        if (Tsena_int > 0)
                        {
                            if (String.IsNullOrEmpty(SizeS.Text) || String.IsNullOrEmpty(Case_name.Text))
                            {
                                MessageBox.Show("Низя");
                            }
                            else
                            {
                                korpus.UpdateQuery(Case_name.Text, SizeS.Text, Tsena_int, Convert.ToInt32(Id));
                                korpTabl.ItemsSource = korpus.GetData();
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
