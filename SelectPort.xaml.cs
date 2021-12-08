using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EqApp
{
    /// <summary>
    /// Interaction logic for SelectPort.xaml
    /// </summary>
    public partial class SelectPort : Window
    {
        // Serial com
        public SerialCom EqCom;
        public SelectPort()
        {
            InitializeComponent();
            string[] ports = SerialCom.GetAvaliablePorts();
            foreach (var port in ports)
            {
                NameBox.Items.Add(port);
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (NameBox.SelectedIndex == -1)
            {
                string messageBoxText = "Port Name Not Specified.";
                string caption = "Incomplete Port";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBox.Show(messageBoxText, caption, button, icon);
                return;
            }
            if (EqCom != null)
            {
                EqCom.SetPortName(NameBox.SelectedItem.ToString());
            }
            // close the form
            this.Close();
        }
    }
}
