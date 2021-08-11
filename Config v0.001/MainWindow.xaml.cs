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



namespace Config_v0._001
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] cellsRUVN_Ar = { "КСО", "КРУ-VLT" };
        string[] cellsRUNN_Ar = { "ШНВ", "ЩО-70" };
        string[] cellsRUVN_KRU_VLT_Ar = { "КРУ-VLT1", "КРУ-VLT2", "КРУ-VLT3", "КРУ-VLT4", "КРУ-VLT5" };
        string[] cellsRUVN_KCO_393_Ar = { "KCO-393_1", "KCO-393_2", "KCO-393_3", "KCO-393_4", "KCO-393_5" };
        string[] cellsRUNN_SHNV_Ar = { "ШНВ", "ШНЛ", "ШНС" };
        string[] cellsRUNN_SHO_Ar = { "ЩО-70_1", "ЩО-70_2", "ЩО-70_3", "ЩО-70_4", "ЩО-70_5" };


        public MainWindow()
        {



            InitializeComponent();



        }

        private void radioRUVN_Checked(object sender, RoutedEventArgs e)
        {
            if(radioRUVN.IsChecked == true)
            {
                comboBoxChoiseCell.Visibility = Visibility.Visible;
                comboBoxChoiseCell.ItemsSource = cellsRUVN_Ar;
                textBlock_nameCells.Visibility = Visibility.Visible;
                textBlock_nameCells.Text = "Тип ячеек " + Convert.ToString(radioRUVN.Content);

            }
        }

        private void radioRUNN_Checked(object sender, RoutedEventArgs e)
        {
            if (radioRUNN.IsChecked == true)
            {
                comboBoxChoiseCell.Visibility = Visibility.Visible;
                comboBoxChoiseCell.ItemsSource = cellsRUNN_Ar;
                textBlock_nameCells.Visibility = Visibility.Visible;
                textBlock_nameCells.Text = "Тип ячеек " + Convert.ToString(radioRUNN.Content);

            }

        }

        private void comboBoxChoiseCell_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if(comboBoxChoiseCell.ItemsSource == cellsRUVN_Ar)
            {
                string choiseValue = Convert.ToString(comboBoxChoiseCell.SelectedItem);

                switch (comboBoxChoiseCell.SelectedIndex)
                {

                    case 0:
                        typeCells.Visibility = Visibility.Visible;
                        textBlock_typeCells.Visibility = Visibility.Visible;
                        typeCells.ItemsSource = cellsRUVN_KCO_393_Ar;
                        break;

                    case 1:
                        typeCells.Visibility = Visibility.Visible;
                        textBlock_typeCells.Visibility = Visibility.Visible;
                        typeCells.ItemsSource = cellsRUVN_KRU_VLT_Ar;
                        break;

                    default:
                        typeCells.Visibility = Visibility.Hidden;
                        textBlock_typeCells.Visibility = Visibility.Hidden;
                        break;
                }

            }
            else if (comboBoxChoiseCell.ItemsSource == cellsRUNN_Ar)
            {
                string choiseValue = Convert.ToString(comboBoxChoiseCell.SelectedItem);

                switch (comboBoxChoiseCell.SelectedIndex)
                {

                    case 0:
                        typeCells.Visibility = Visibility.Visible;
                        textBlock_typeCells.Visibility = Visibility.Visible;
                        typeCells.ItemsSource = cellsRUNN_SHNV_Ar;
                        break;

                    case 1:
                        typeCells.Visibility = Visibility.Visible;
                        textBlock_typeCells.Visibility = Visibility.Visible;
                        typeCells.ItemsSource = cellsRUNN_SHO_Ar;
                        break;

                    default:
                        typeCells.Visibility = Visibility.Hidden;
                        textBlock_typeCells.Visibility = Visibility.Hidden;
                        break;


                }

            }

        }

        private void typeCells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string choiseValue = Convert.ToString(typeCells.SelectedItem);
            var choiseArray = typeCells.ItemsSource;
            


            if(typeCells.ItemsSource == choiseArray && choiseArray == cellsRUVN_KCO_393_Ar)
            {


                switch (typeCells.SelectedIndex)
                {

                    case (0):
                        cellsImages.Visibility = Visibility.Visible;
                        //cellsImages.Source = new BitmapImage(new Uri(@"../img/Screenshot_3.png", UriKind.Relative));

                        return;

                    case (1):
                        cellsImages.Visibility = Visibility.Visible;
                        cellsImages.Source = new BitmapImage(new Uri(@"https://po-velta.ru/images/cat/rubrics/full_205c75c19479721a52c62756406f0f52.png"));
                        return;

                    case (2):
                        cellsImages.Visibility = Visibility.Visible;
                        cellsImages.Source = new BitmapImage(new Uri(@"https://po-velta.ru/images/cat/rubrics/e3ff928347c32c295c52de62de094230.png"));
                        return;

                    case (3):
                        cellsImages.Visibility = Visibility.Visible;
                        cellsImages.Source = new BitmapImage(new Uri(@"https://po-velta.ru/images/cat/rubrics/befb569c53ee792fd4530de974fedadf.png"));
                        return;

                    default:
                        cellsImages.Visibility = Visibility.Hidden;
                        cellsImages.Source = new BitmapImage(new Uri(@"https://po-velta.ru/favicon.ico"));
                        return;

                }
            }





        }
    }

}
