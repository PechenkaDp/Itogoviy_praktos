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
using System.Windows.Shapes;
using Itogoviy_praktos.itogDataSetTableAdapters;

namespace Itogoviy_praktos
{
    /// <summary>
    /// Логика взаимодействия для Gotov.xaml
    /// </summary>
    public partial class Gotov : Window
    {
        personalTableAdapter pers = new personalTableAdapter();
        computer_caseTableAdapter Korpus = new computer_caseTableAdapter();
        CoolingTableAdapter Ohlad = new CoolingTableAdapter();
        DriveTableAdapter Disk = new DriveTableAdapter();
        MotherboardTableAdapter materinka = new MotherboardTableAdapter();
        PC_headsetTableAdapter garnitura = new PC_headsetTableAdapter();
        Power_SupplyTableAdapter blokPit = new Power_SupplyTableAdapter();
        ProcessorTableAdapter proc = new ProcessorTableAdapter();
        RAMTableAdapter oper = new RAMTableAdapter();
        SoftwareTableAdapter soft = new SoftwareTableAdapter();
        VieocardTableAdapter vid = new VieocardTableAdapter();
        KomputerTableAdapter komp = new KomputerTableAdapter();

        int kor_id;
        int Mat_id;
        int Blo_id;
        int VId_id;
        int Ope_id;
        int Pro_id;
        int proc_id;
        int ohl_id;
        int gar_id;
        int nak_id;
        int Sbor = 50;
        int id;


        public Gotov()
        {
            InitializeComponent();
            KorpC.ItemsSource = Korpus.GetData();
            KorpC.DisplayMemberPath = "case_id";
            MatC.ItemsSource = materinka.GetData();
            MatC.DisplayMemberPath = "mat_id";
            BPC.ItemsSource = blokPit.GetData();
            BPC.DisplayMemberPath = "bp_id";
            VidC.ItemsSource = vid.GetData();
            VidC.DisplayMemberPath = "video_id";
            OpC.ItemsSource = oper.GetData();
            OpC.DisplayMemberPath = "oper_id";
            PoC.ItemsSource = soft.GetData();
            PoC.DisplayMemberPath = "soft_id";
            ProcC.ItemsSource = proc.GetData();
            ProcC.DisplayMemberPath = "proc_id";
            OhC.ItemsSource = Ohlad.GetData();
            OhC.DisplayMemberPath = "Cooling_id";
            GarC.ItemsSource = garnitura.GetData();
            GarC.DisplayMemberPath = "gar_id";
            NakC.ItemsSource = Disk.GetData();
            NakC.DisplayMemberPath = "dr_id";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                if (globalVariables.ID == 1)
                {
                    AdminWindow adm = new AdminWindow();
                    adm.Show();
                    Close();
                }
                if (globalVariables.ID == 2)
                {
                    Sborka us = new Sborka();
                    us.Show();
                    Close();
                }

        }


        private void Dobav_Click(object sender, RoutedEventArgs e)
        {
            try
            {



                komp.InsertQuery(kor_id, Mat_id, Blo_id, VId_id, Ope_id, Pro_id, proc_id, ohl_id, gar_id, nak_id, Sbor);
                KompTabl.ItemsSource = komp.GetData();
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
                    object id = (KompTabl.SelectedItem as DataRowView).Row[0];
                    komp.DeleteQuery(Convert.ToInt32(id));
                    KompTabl.ItemsSource = komp.GetData();
                }
                else
                {
                    MessageBox.Show("Куда мы лезем?");
                }
            }
            catch
            {
                MessageBox.Show("Вы ввели что-то неправильно");
            }

        }

        private void Izmenenie_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (globalVariables.ID == 1)
                {
                    object Id = (KompTabl.SelectedItem as DataRowView).Row[0];

                    id = (int)Id;
                    if (id == 0)
                    {
                        MessageBox.Show("Сначала создайте сборку");
                    }
                    else
                    {
                        komp.UpdateQuery(kor_id, Mat_id, Blo_id, VId_id, Ope_id, Pro_id, proc_id, ohl_id, gar_id, nak_id, Sbor, Convert.ToInt32(Id));
                        KompTabl.ItemsSource = komp.GetData();
                    }
                }
                else
                {
                    MessageBox.Show("Куда мы лезем?");
                }
            }
            catch
            {
                MessageBox.Show("Вы ввели что-то неправильно");
            }

        }

        private void KorpC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object korp_id = (KorpC.SelectedItem as DataRowView).Row[0];
            kor_id = (int)korp_id;
        }

        private void MatC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object mat_id = (MatC.SelectedItem as DataRowView).Row[0];
            Mat_id = (int)mat_id;
        }

        private void BPC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object blokP_id = (BPC.SelectedItem as DataRowView).Row[0];
            Blo_id = (int)blokP_id;

        }

        private void VidC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object Vid_id = (VidC.SelectedItem as DataRowView).Row[0];
            VId_id = (int)Vid_id;
        }

        private void OpC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object Oper_id = (OpC.SelectedItem as DataRowView).Row[0];
            Ope_id = (int)Oper_id;
        }

        private void PoC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object Soft_id = (PoC.SelectedItem as DataRowView).Row[0];
            Pro_id = (int)Soft_id;
        }

        private void ProcC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object processor_id = (ProcC.SelectedItem as DataRowView).Row[0];
            proc_id = (int)processor_id;
        }

        private void OhC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object ohlad_id = (OhC.SelectedItem as DataRowView).Row[0];
            ohl_id = (int)ohlad_id;
        }

        private void GarC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object Garnitura_id = (GarC.SelectedItem as DataRowView).Row[0];
            gar_id = (int)Garnitura_id;
        }

        private void NakC_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            object nakop_id = (NakC.SelectedItem as DataRowView).Row[0];
            nak_id = (int)nakop_id;
        }
    }
}
