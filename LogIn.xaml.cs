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
    /// Логика взаимодействия для LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        personalTableAdapter pers = new personalTableAdapter();
        public LogIn()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string log = Login.Text;
            string pas = Password.Password;
            int prov = 0;

            var allLogins = pers.GetData().Rows;


            for (int i = 0; i < allLogins.Count; i++)
            {
                if (String.IsNullOrEmpty(log) || String.IsNullOrEmpty(pas))
                {
                    MessageBox.Show("Вы не вели значения логина или пароля");
                    return;
                }
                if (allLogins[i][1].ToString() == log && allLogins[i][3].ToString() == pas)
                {
                    prov = prov + 1;
                    int roleID = (int)allLogins[i][2];
                    globalVariables.ID = roleID;
                    switch (roleID)
                    {
                        case 1: 
                            AdminWindow adminWin = new AdminWindow();
                            adminWin.Show();
                            Close();
                            break;
                        case 2:
                            UserWindow user = new UserWindow();
                            user.Show();
                            Close();
                            break;
                    }
                
                }
                

            }
            if (prov == 0)
                {
                MessageBox.Show("Вы ввели что-то не правильно");

                }

        }

    }
}
