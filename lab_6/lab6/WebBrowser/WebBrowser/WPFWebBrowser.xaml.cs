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
using System.ComponentModel;

namespace WebBrowser
{
    /// <summary>
    /// Interaction logic for WPFWebBrowser.xaml
    /// </summary>
    public partial class WPFWebBrowser : UserControl, INotifyPropertyChanged
    {
        public WPFWebBrowser()
        {
            InitializeComponent();
            this.DataContext = this;
        }


        public static readonly DependencyProperty HTMLStringProperty =
        DependencyProperty.Register("HTMLString", typeof(String),
         typeof(WPFWebBrowser), new PropertyMetadata(OnHTMLStringPropertyChanged));


        public string HTMLString
        {
            get { return GetValue(HTMLStringProperty).ToString(); }
            set
            {
                SetValue(HTMLStringProperty, value);
            }
        }

        public static void OnHTMLStringPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WPFWebBrowser control = d as WPFWebBrowser;
            control.OnPropertyChanged("HTMLString");
            control.changeContent();
        }

        private void changeContent()
        {
            //zmieniam zawartosc przegladarki
            webBrowserComponent.NavigateToString(HTMLString);
        }

        private void OnHTMLPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            webBrowserComponent.NavigateToString(HTMLString);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string html)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(html));
            }
        }

    }
}
