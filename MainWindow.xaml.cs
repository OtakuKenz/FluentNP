using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CustomNP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
            txt_FontSize.Text = txtBox.FontSize.ToString();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btn_Apply_Click(object sender, RoutedEventArgs e)
        {
            int x = 0;
            if(int.TryParse(txt_FontSize.Text,out x))
            {
                txtBox.FontSize = x;
            }
            else
            {
                MessageBox.Show("Invalid Font Size");
            }
        }

        private void btn_AlwaysOnTop_Click(object sender, RoutedEventArgs e)
        {
            if(this.Topmost==true)
            {
                this.Topmost = false;
                btn_AlwaysOnTop.Content = "Off";
            }
            else
            {
                this.Topmost = true;
                btn_AlwaysOnTop.Content = "On";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to close?","Close Confirmation", MessageBoxButton.YesNo)==MessageBoxResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
