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
        public string[] cellsNomCurrent_Ar;
        public string[] QauntityAV_Ar;
        public string AV_04 = "Литой корпус";
        public string AV_6 = "Воздушный корпус";


        public MainWindow()
        {



            InitializeComponent();



        }

        // РадиоБаттон при переключании на РУВН
        private void radioRUVN_Checked(object sender, RoutedEventArgs e)
        {

            ChoiseTypeCells_text.Text = "Тип ячеек " + radioRUVN.Content; // Присваиваю значение текста для выбора типа ячеек

            switch (radioRUVN.IsChecked) // если РУВН выбран, то высвечиваю комбобоксы
            {
                case true:
                    ChoiseTypeCells.Visibility = Visibility.Visible;
                    ChoiseTypeCells_text.Visibility = Visibility.Visible;
                    ChoiseTypeCells.ItemsSource = cellsRUVN_Ar;
                    return;

                case false:
                    ChoiseTypeCells.Visibility = Visibility.Hidden;
                    ChoiseTypeCells_text.Visibility = Visibility.Hidden;
                    return;

            }

        }

        private void radioRUNN_Checked(object sender, RoutedEventArgs e)
        {

            ChoiseTypeCells_text.Text = "Тип ячеек " + radioRUNN.Content; // Присваиваю значение текста для выбора типа ячеек

            switch (radioRUNN.IsChecked) // если РУВН выбран, то высвечиваю комбобоксы
            {
                case true:
                    ChoiseTypeCells.Visibility = Visibility.Visible;
                    ChoiseTypeCells_text.Visibility = Visibility.Visible;
                    ChoiseTypeCells.ItemsSource = cellsRUNN_Ar;
                    return;

                case false:
                    ChoiseTypeCells.Visibility = Visibility.Hidden;
                    ChoiseTypeCells_text.Visibility = Visibility.Hidden;
                    return;

            }

        }

        // Тип ячеек РУВН
        private void ChoiseTypeCells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // когда высвечивается тип ячеек РУВН

            if (ChoiseTypeCells.ItemsSource == cellsRUVN_Ar)
            {
                ChoiseSchemeCells.Visibility = Visibility.Visible; // Высвечиваю выбор схемы
                ChoiseSchemeCells_text.Visibility = Visibility.Visible; // Высвечиваю выбор схемы текст
                ChoiseSchemeCells_text.Text = "Выберите схему " + Convert.ToString(ChoiseTypeCells.SelectedItem); // Присваиваю значения схемы к тексту

                switch (ChoiseTypeCells.SelectedIndex) // При выборе ячейки РУВН (КСО, КРУ)
                {
                    case 0:
                        ChoiseSchemeCells.ItemsSource = cellsRUVN_KCO_393_Ar; //Присваиваю массив КСО-393
                        return;
                    case 1:
                        ChoiseSchemeCells.ItemsSource = cellsRUVN_KRU_VLT_Ar; //Присваиваю массив КРУ-ВЛТ
                        return;
                }

            }

            // когда высвечивается тип ячеек РУНН

            if (ChoiseTypeCells.ItemsSource == cellsRUNN_Ar)
            {
                ChoiseSchemeCells.Visibility = Visibility.Visible; // Высвечиваю выбор схемы
                ChoiseSchemeCells_text.Visibility = Visibility.Visible; // Высвечиваю выбор схемы текст
                ChoiseSchemeCells_text.Text = "Выберите схему " + Convert.ToString(ChoiseTypeCells.SelectedItem); // Присваиваю значения схемы к тексту

                switch (ChoiseTypeCells.SelectedIndex) // При выборе ячейки РУНН (ШНВ, ЩО-70)
                {
                    case 0:
                        ChoiseSchemeCells.ItemsSource = cellsRUNN_SHNV_Ar; //Присваиваю массив ШНВ
                        return;
                    case 1:
                        ChoiseSchemeCells.ItemsSource = cellsRUNN_SHO_Ar; //Присваиваю массив ЩО-70
                        return;
                }

            }


        }
        private void ChoiseSchemeCells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            // При выборе типа ячеек РУВН, РУНН, нужно выбрать специалицию


            if (ChoiseSchemeCells.ItemsSource == cellsRUNN_SHNV_Ar) // При выборе ШНВ присваиваю значения в массив
            {
                switch (ChoiseSchemeCells.SelectedIndex)
                {
                    case (0):
                        ChoiseSpecCells.Visibility = Visibility.Visible; // Высвечиваю комбобокс с назначением
                        ChoiseSpecCells_text.Visibility = Visibility.Visible; // Высвечиваю текст с назначением
                        ChoiseSpecCells_text.Text = "Выберите номинальный ток"; // Присваиваю значение в текст

                        cellsNomCurrent_Ar = new string[4]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = "800 A";
                        cellsNomCurrent_Ar[1] = "1250 A";
                        cellsNomCurrent_Ar[2] = "1600 A";
                        cellsNomCurrent_Ar[3] = "2500 A";

                        ChoiseSpecCells.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    case (1):
                        ChoiseSpecCells.Visibility = Visibility.Visible; // Высвечиваю комбобокс с назначением
                        ChoiseSpecCells_text.Visibility = Visibility.Visible; // Высвечиваю текст с назначением
                        ChoiseSpecCells_text.Text = "Выберите тип АВ"; // Присваиваю значение в текст

                        cellsNomCurrent_Ar = new string[2]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = AV_04;
                        cellsNomCurrent_Ar[1] = AV_6;

                        ChoiseSpecCells.ItemsSource = cellsNomCurrent_Ar;

                        return;
                    case (2):
                        ChoiseSpecCells.Visibility = Visibility.Visible; // Высвечиваю комбобокс с назначением
                        ChoiseSpecCells_text.Visibility = Visibility.Visible; // Высвечиваю текст с назначением
                        ChoiseSpecCells_text.Text = "Выберите номинальный ток"; // Присваиваю значение в текст

                        cellsNomCurrent_Ar = new string[4]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = "800 A";
                        cellsNomCurrent_Ar[1] = "1250 A";
                        cellsNomCurrent_Ar[2] = "1600 A";
                        cellsNomCurrent_Ar[3] = "2500 A";

                        ChoiseSpecCells.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    default:
                        ChoiseSpecCells.Visibility = Visibility.Hidden; // Скрываю комбобокс с назначением
                        ChoiseSpecCells_text.Visibility = Visibility.Hidden; // Скрываю текст с назначением
                        return;


                }


            }






        }

        private void ChoiseSpecCells_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiseSchemeCells.ItemsSource == cellsRUNN_SHNV_Ar && ChoiseSchemeCells.SelectedIndex == 1) // При выборе ШНЛ дополняю конфигуратор на емкость ячейки
            {

                switch (ChoiseSpecCells.SelectedIndex)
                {
                    case (0): // при выборе литово корпуса
                        ChoiseNomCurrent.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_text.Visibility = Visibility.Visible;
                        doubleCheck_AV.Visibility = Visibility.Hidden;
                        doubleCheck_AV_text.Visibility = Visibility.Hidden;
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Hidden;
                        ChoiseNomCurrent_doubleCheck_text.Visibility = Visibility.Hidden;
                        QuantitydoubleCheck_AV.Visibility = Visibility.Hidden;
                        QuantitydoubleCheck_AV_text.Visibility = Visibility.Hidden;

                        ChoiseNomCurrent_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "100A";
                        cellsNomCurrent_Ar[1] = "250A";
                        cellsNomCurrent_Ar[2] = "400A";
                        cellsNomCurrent_Ar[3] = "630A";

                        ChoiseNomCurrent.ItemsSource = cellsNomCurrent_Ar;

                        return;

                    case (1): // при выборе воздушного корпуса
                        ChoiseNomCurrent.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_text.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "800A";
                        cellsNomCurrent_Ar[1] = "1250A";
                        cellsNomCurrent_Ar[2] = "1600A";
                        cellsNomCurrent_Ar[3] = "2000A";

                        ChoiseNomCurrent.ItemsSource = cellsNomCurrent_Ar;

                        return;

                    default:
                        ChoiseNomCurrent.Visibility = Visibility.Hidden;
                        ChoiseNomCurrent_text.Visibility = Visibility.Hidden;
                        return;


                }
            }
            else
            {
                ChoiseNomCurrent.Visibility = Visibility.Hidden;
                ChoiseNomCurrent_text.Visibility = Visibility.Hidden;

            }
        }

        private void ChoiseNomCurrent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ChoiseSchemeCells.ItemsSource == cellsRUNN_SHNV_Ar && ChoiseSpecCells.SelectedIndex == 0)
            {
                QantityAV.SelectedItem = 1;

                switch (ChoiseNomCurrent.SelectedIndex)
                {
                    case (0): //При выборе литого автомата 100А
                        QauntityAV_Ar = new string[7];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";
                        QauntityAV_Ar[4] = "5 шт.";
                        QauntityAV_Ar[5] = "6 шт.";
                        QauntityAV_Ar[6] = "7 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (1): //При выборе литого автомата 250А
                        QauntityAV_Ar = new string[7];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";
                        QauntityAV_Ar[4] = "5 шт.";
                        QauntityAV_Ar[5] = "6 шт.";
                        QauntityAV_Ar[6] = "7 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (2): //При выборе литого автомата 400А
                        QauntityAV_Ar = new string[6];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";
                        QauntityAV_Ar[4] = "5 шт.";
                        QauntityAV_Ar[5] = "6 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (3): //При выборе литого автомата 630А
                        QauntityAV_Ar = new string[6];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";
                        QauntityAV_Ar[4] = "5 шт.";
                        QauntityAV_Ar[5] = "6 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    default:
                        QantityAV.Visibility = Visibility.Hidden;
                        QantityAV_text.Visibility = Visibility.Hidden;
                        return;
                }


            }
            else
            {
                QantityAV.Visibility = Visibility.Hidden;
                QantityAV_text.Visibility = Visibility.Hidden;
            }

            if (ChoiseSchemeCells.ItemsSource == cellsRUNN_SHNV_Ar && ChoiseSpecCells.SelectedIndex == 1)
            {
                QantityAV.SelectedItem = "Выбрать";

                switch (ChoiseNomCurrent.SelectedIndex)
                {
                    case (0): //При выборе воздушного автомата 800А
                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (1): //При выборе воздушного автомата 1250А
                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (2): //При выборе воздушного автомата 1600А
                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (3): //При выборе литого автомата 630А
                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QantityAV.Visibility = Visibility.Visible;
                        QantityAV_text.Visibility = Visibility.Visible;
                        QantityAV_text.Text = "Количество автоматов, шт";
                        QantityAV.ItemsSource = QauntityAV_Ar;
                        return;

                    default:
                        QantityAV.Visibility = Visibility.Hidden;
                        QantityAV_text.Visibility = Visibility.Hidden;
                        return;
                }


            }


        }

        // При выборе выоздушного автомата, выводим дополнительные литые автоматы

        private void QantityAV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

            if (ChoiseSchemeCells.ItemsSource == cellsRUNN_SHNV_Ar && ChoiseSpecCells.SelectedIndex == 1 && ChoiseSpecCells.SelectedIndex == 1)
            {

                switch (QantityAV.SelectedIndex)
                {
                    case (0):
                        doubleCheck_AV.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Text = "Дополнительные АВ: ";

                        cellsNomCurrent_Ar = new string[1]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = AV_04;

                        doubleCheck_AV.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    case (1):
                        doubleCheck_AV.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Text = "Дополнительные АВ: ";

                        cellsNomCurrent_Ar = new string[1]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] =AV_04;

                        doubleCheck_AV.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    case (2):
                        doubleCheck_AV.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Text = "Дополнительные АВ: ";

                        cellsNomCurrent_Ar = new string[1]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = AV_04;

                        doubleCheck_AV.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    case (3):
                        doubleCheck_AV.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Visibility = Visibility.Visible;
                        doubleCheck_AV_text.Text = "Дополнительные АВ: ";

                        cellsNomCurrent_Ar = new string[1]; // Задаю новую длину массива

                        cellsNomCurrent_Ar[0] = AV_04;

                        doubleCheck_AV.ItemsSource = cellsNomCurrent_Ar;
                        return;
                    default:
                        doubleCheck_AV.Visibility = Visibility.Hidden;
                        doubleCheck_AV_text.Visibility = Visibility.Hidden;

                        return;

                }

            }




        }

        // Двойная проверка на ШНЛ с воздушником
        private void doubleCheck_AV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(doubleCheck_AV.SelectedIndex == 0)
            {

                switch (QantityAV.SelectedIndex)
                {
                    case (0):
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_doubleCheck_text.Visibility = Visibility.Visible;

                        ChoiseNomCurrent_doubleCheck_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "100A";
                        cellsNomCurrent_Ar[1] = "250A";
                        cellsNomCurrent_Ar[2] = "400A";
                        cellsNomCurrent_Ar[3] = "630A";

                        ChoiseNomCurrent_doubleCheck.ItemsSource = cellsNomCurrent_Ar;
                        return;

                    case (1):
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_doubleCheck_text.Visibility = Visibility.Visible;

                        ChoiseNomCurrent_doubleCheck_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "100A";
                        cellsNomCurrent_Ar[1] = "250A";
                        cellsNomCurrent_Ar[2] = "400A";
                        cellsNomCurrent_Ar[3] = "630A";

                        ChoiseNomCurrent_doubleCheck.ItemsSource = cellsNomCurrent_Ar;
                        return;

                    case (2):
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_doubleCheck_text.Visibility = Visibility.Visible;

                        ChoiseNomCurrent_doubleCheck_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "100A";
                        cellsNomCurrent_Ar[1] = "250A";
                        cellsNomCurrent_Ar[2] = "400A";
                        cellsNomCurrent_Ar[3] = "630A";

                        ChoiseNomCurrent_doubleCheck.ItemsSource = cellsNomCurrent_Ar;
                        return;

                    case (3):
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Visible;
                        ChoiseNomCurrent_doubleCheck_text.Visibility = Visibility.Visible;

                        ChoiseNomCurrent_doubleCheck_text.Text = "Укажите номинальный ток";

                        cellsNomCurrent_Ar = new string[4];

                        cellsNomCurrent_Ar[0] = "100A";
                        cellsNomCurrent_Ar[1] = "250A";
                        cellsNomCurrent_Ar[2] = "400A";
                        cellsNomCurrent_Ar[3] = "630A";

                        ChoiseNomCurrent_doubleCheck.ItemsSource = cellsNomCurrent_Ar;
                        return;

                    default:
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Hidden;
                        ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Hidden;
                        return;

                }

                
            }
            else
            {

                ChoiseNomCurrent_doubleCheck.Visibility = Visibility.Hidden;
            }
        }

        private void ChoiseNomCurrent_doubleCheck_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(doubleCheck_AV.SelectedIndex == 0)
            {
                QuantitydoubleCheck_AV.Visibility = Visibility.Visible;
                QuantitydoubleCheck_AV_text.Visibility = Visibility.Visible;
                QuantitydoubleCheck_AV_text.Text = "Количество автоматов, шт";

                switch (ChoiseNomCurrent.SelectedIndex, QantityAV.SelectedIndex, ChoiseNomCurrent_doubleCheck.SelectedIndex)
                {
                    case (0,0,0):

                        QauntityAV_Ar = new string[4];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0,0,1):

                        QauntityAV_Ar = new string[4];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";
                        QauntityAV_Ar[3] = "4 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0, 0, 2):

                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0, 0, 3):

                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;
                    case (0, 1, 0):

                        QauntityAV_Ar = new string[4];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0, 1, 1):

                        QauntityAV_Ar = new string[4];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";
                        QauntityAV_Ar[2] = "3 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0, 1, 2):

                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;

                    case (0, 1, 3):

                        QauntityAV_Ar = new string[3];

                        QauntityAV_Ar[0] = "1 шт.";
                        QauntityAV_Ar[1] = "2 шт.";

                        QuantitydoubleCheck_AV.ItemsSource = QauntityAV_Ar;
                        return;
                  
                    case (0, 2, 0):

                        QuantitydoubleCheck_AV.Visibility = Visibility.Collapsed;
                        QuantitydoubleCheck_AV_text.Visibility = Visibility.Collapsed;
                        return;

                }

            }

        }



        private void QuantitydoubleCheck_AV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

    }

}
