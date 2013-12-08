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
using System.Windows.Controls;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for WPFWebBrowser.xaml
    /// </summary>
    public partial class WPFWebBrowser : UserControl
    {
        public WPFWebBrowser()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty CurrentTimeProperty =
        DependencyProperty.Register("HTML", typeof(String),
         typeof(WPFWebBrowser), new PropertyMetadata(OnHTMLPropertyChanged));

        public String HTML { get; set; }

        public static void OnHTMLPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Console.WriteLine("Odswierzam kontrolke");

            var mainWindow = new MainWindow();
            //mainWindow.WebBrowserControl.se
        }

    }
}
