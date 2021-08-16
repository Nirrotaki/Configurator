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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Config_v0._001;

namespace Config_v0._001.Models
{
    

    class lowSHNL
    {

        MainWindow mainWindow = new MainWindow();

        

        public void radioRUNN_Method(object sender, RoutedEventArgs e)
        {
            ComboBox msgBoxSHNL = (sender)ComboBox;

            if (mainWindow.radioRUNN.IsChecked == true)
            {
                MessageBox.Show("check");
            }


        }

    }

    class lowSHO
    {



    }

    class RUNN
    {



    }






}
