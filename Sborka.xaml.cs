using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для Sborka.xaml
    /// </summary>
    public partial class Sborka : Window
    {
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
        public Sborka()
        {
            InitializeComponent();
            ViborTabl.Items.Add("Охлаждение");
            ViborTabl.Items.Add("Корпус");
            ViborTabl.Items.Add("Блок питания");
            ViborTabl.Items.Add("Процессор");
            ViborTabl.Items.Add("Материнская плата");
            ViborTabl.Items.Add("Видеокарта");
            ViborTabl.Items.Add("Оперативная память");
            ViborTabl.Items.Add("Гарнитура");
            ViborTabl.Items.Add("Накопитель");
            ViborTabl.Items.Add("Операционная система");
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Gotov gotov = new Gotov();
            gotov.Show();
            Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void ViborTabl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((string)(ViborTabl.SelectedValue) == "Корпус")
            {
                TablitsaShow.Content = new Tablichki();



            }

            if ((string)(ViborTabl.SelectedValue) == "Гарнитура")
            {
                TablitsaShow.Content = new Garnitura();
            }

            if ((string)(ViborTabl.SelectedValue) == "Оперативная память")
            {
                TablitsaShow.Content = new Oper();
            }

            if ((string)(ViborTabl.SelectedValue) == "Накопитель")
            {
                TablitsaShow.Content = new Drive();
            }

            if ((string)(ViborTabl.SelectedValue) == "Операционная система")
            {
                TablitsaShow.Content = new Soft();
            }

            if ((string)(ViborTabl.SelectedValue) == "Видеокарта")
            {
                TablitsaShow.Content = new Videocard();
            }

            if ((string)(ViborTabl.SelectedValue) == "Материнская плата")
            {
                TablitsaShow.Content = new Motherboard();
            }

            if ((string)(ViborTabl.SelectedValue) == "Процессор")
            {
                TablitsaShow.Content = new Processor();
            }

            if ((string)(ViborTabl.SelectedValue) == "Блок питания")
            {
                TablitsaShow.Content = new Power();
            }

            if ((string)(ViborTabl.SelectedValue) == "Охлаждение")
            {
                TablitsaShow.Content = new Ohlad();
            }
        }
    }
}
