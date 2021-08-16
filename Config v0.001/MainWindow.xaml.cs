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
using Config_v0._001.Models;



namespace Config_v0._001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        lowSHNL lowSHNL_obj = new lowSHNL();
        
        

        public MainWindow()
        {
            
            
            InitializeComponent();

            lowSHNL_obj.radioRUNN_Method();
            



        }

    }

}
