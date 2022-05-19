using System;
using System.Windows;

namespace WPF_Start
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Cus cus = new Cus("홍길동", 17);
        public MainWindow()
        {
            InitializeComponent();
            
            ViewData(cus);

            cus.PropertyChanged += Cus_PropertyChanged;
        }

        private void Cus_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            //if(e.PropertyName != null) // swich 이용해서 Age. Name에 따라 줄 수 있슴.
            {
                txtAge.Text = cus.Age.ToString();
                txtName.Text = cus.Name.ToString();
            }
        }

        private Cus GetData()
        {
            var cus = new Cus("홍길동", 17);
            return cus;
        }

        private void ViewData(Cus Cus1)
        {
            txtName.Text = cus.Name;
            txtAge.Text = cus.Age.ToString();
        }

        private void btnYear_Click(object sender, RoutedEventArgs e)
        {
            DateTime dt = DateTime.Now;
            int year = dt.Year - Convert.ToInt32(txtAge.Text) + 1;

            MessageBox.Show("당신의 출생년도는 " + year + " 입니다");
            
        }

        private void btnAddAge_Click(object sender, RoutedEventArgs e)
        {
            cus.Age++;
        }

        private void btnSubAge_Click(object sender, RoutedEventArgs e)
        {
            cus.Age--;
            MessageBox.Show("떡국을 뺏겼습니다. T..T");
        }
    }
}
