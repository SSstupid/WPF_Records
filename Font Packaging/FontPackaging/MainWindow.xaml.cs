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

namespace FontPackaging
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();           
        }
   
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            myTextBlock.FontFamily = new FontFamily(new Uri("pack://application:,,,/"), "./Resource/#Athletic Outfit"); //코드에서 글꼴 참조

            // 지정위치의 모든 글꼴 반환.
            System.Collections.Generic.ICollection<FontFamily> fontFamilies = Fonts.GetFontFamilies(new Uri("pack://application:,,,/Resource/#"));
            foreach (FontFamily fontFamily in fontFamilies)
            {
                string[] familyName = fontFamily.Source.Split('#');
                FontList.Items.Add(familyName[familyName.Length - 1]);
            }

            foreach (Typeface typeface in Fonts.GetTypefaces(new Uri("pack://application:,,,/Resource/#")))
            {
                myTextBlock.Text = typeface.ToString();
            }
        }
    }
}
