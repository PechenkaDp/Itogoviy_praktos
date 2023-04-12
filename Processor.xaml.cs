using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
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
    /// Логика взаимодействия для Processor.xaml
    /// </summary>
    public partial class Processor : Page
    {
        ProcessorTableAdapter proc = new ProcessorTableAdapter();
        int cost;
        int cpu;
        int Cores;
        int Sp;
        
        public Processor()
        {
            InitializeComponent();
            ProcTabl.ItemsSource = proc.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(CPU.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(cores.Text) || String.IsNullOrEmpty(speed.Text) || String.IsNullOrEmpty(proc_name.Text) || String.IsNullOrEmpty(Socket.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        cpu = Convert.ToInt32(CPU.Text);
                        Cores = Convert.ToInt32(cores.Text);
                        Sp = Convert.ToInt32(speed.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (cpu > 0 && Cores > 0 && Sp > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(proc_name.Text) || String.IsNullOrEmpty(Socket.Text))
                            {
                                MessageBox.Show("");
                            }
                            else
                            {
                                proc.InsertQuery(proc_name.Text, Socket.Text, cpu, Sp, Cores, cost);
                                ProcTabl.ItemsSource = proc.GetData();
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

        private void Ydalenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    object id = (ProcTabl.SelectedItem as DataRowView).Row[0];
                    proc.DeleteQuery(Convert.ToInt32(id));
                    ProcTabl.ItemsSource = proc.GetData();
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
                    if (String.IsNullOrEmpty(CPU.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(cores.Text) || String.IsNullOrEmpty(speed.Text) || String.IsNullOrEmpty(proc_name.Text) || String.IsNullOrEmpty(Socket.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        cpu = Convert.ToInt32(CPU.Text);
                        Cores = Convert.ToInt32(cores.Text);
                        Sp = Convert.ToInt32(speed.Text);
                        cost = Convert.ToInt32(Cost.Text);
                        if (cpu > 0 && Cores > 0 && Sp > 0 && cost > 0)
                        {
                            if (String.IsNullOrEmpty(proc_name.Text) || String.IsNullOrEmpty(Socket.Text))
                            {
                                MessageBox.Show("");
                            }
                            else
                            {
                                object Id = (ProcTabl.SelectedItem as DataRowView).Row[0];


                                proc.UpdateQuery(proc_name.Text, Socket.Text, cpu, Sp, Cores, cost, Convert.ToInt32(Id));
                                ProcTabl.ItemsSource = proc.GetData();
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
