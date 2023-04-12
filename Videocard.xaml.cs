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
    /// Логика взаимодействия для Videocard.xaml
    /// </summary>
    public partial class Videocard : Page
    {
        VieocardTableAdapter vid = new VieocardTableAdapter();
        int MEM;
        int graph;
        int Cons;
        int cost;
        public Videocard()
        {
            InitializeComponent();
            VidTabl.ItemsSource = vid.GetData();
        }

        private void Sozdanie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    if (String.IsNullOrEmpty(mem.Text) || String.IsNullOrEmpty(Con.Text) || String.IsNullOrEmpty(graf.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(vid_name.Text))
                    {
                        MessageBox.Show("Низя");
                    }
                    else
                    {
                        if (MEM > 0 && Cons > 0 && graph > 0 && cost > 0)
                        {
                            MEM = Convert.ToInt32(mem.Text);
                            Cons = Convert.ToInt32(Con.Text);
                            graph = Convert.ToInt32(graf.Text);
                            cost = Convert.ToInt32(Cost.Text);

                            vid.InsertQuery(vid_name.Text, MEM, Cons, graph, cost);
                            VidTabl.ItemsSource = vid.GetData();
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
            try { 
            if (globalVariables.ID == 1)
            {
                object id = (VidTabl.SelectedItem as DataRowView).Row[0];
                vid.DeleteQuery(Convert.ToInt32(id));
                VidTabl.ItemsSource = vid.GetData();
            }
            else
            {
                MessageBox.Show("Низя");
            }
        }
            catch
            {
                MessageBox.Show("Вы не выбрали строку");
            }

        }

        private void Redact_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            
            if (globalVariables.ID == 1)
            {
                if (String.IsNullOrEmpty(mem.Text) || String.IsNullOrEmpty(Con.Text) || String.IsNullOrEmpty(graf.Text) || String.IsNullOrEmpty(Cost.Text) || String.IsNullOrEmpty(vid_name.Text))
                {

                }
                else
                {
                    object Id = (VidTabl.SelectedItem as DataRowView).Row[0];
                    MEM = Convert.ToInt32(mem.Text);
                    Cons = Convert.ToInt32(Con.Text);
                    graph = Convert.ToInt32(graf.Text);
                    cost = Convert.ToInt32(Cost.Text);

                    if (MEM > 0 && Cons > 0 && graph > 0 && cost > 0)
                    {


                        vid.UpdateQuery(vid_name.Text, MEM, Cons, graph, cost, Convert.ToInt32(Id));
                        VidTabl.ItemsSource = vid.GetData();
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
