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

namespace EqApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The total number of bands, 13
        private const int BAND_NUM = 13;
        // Stores the attenuation of each band
        private double[] attenuations = new double[BAND_NUM];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SliderValueChanged(int bandNo, double newValue)
        {
            // store the attenuation
            attenuations[bandNo] = newValue * 0.1;
            // update label
            UpdateLabelContentFor(bandNo);
        }

        private void UpdateLabelContentFor(int bandNo)
        {
            switch (bandNo)
            {
                case 0:
                    Slider0Label.Content = String.Format("{0:0.00}", attenuations[0]);
                    break;
                case 1:
                    Slider1Label.Content = String.Format("{0:0.00}", attenuations[1]);
                    break;
                case 2:
                    Slider2Label.Content = String.Format("{0:0.00}", attenuations[2]);
                    break;
                case 3:
                    Slider3Label.Content = String.Format("{0:0.00}", attenuations[3]);
                    break;
                case 4:
                    Slider4Label.Content = String.Format("{0:0.00}", attenuations[4]);
                    break;
                case 5:
                    Slider5Label.Content = String.Format("{0:0.00}", attenuations[5]);
                    break;
                case 6:
                    Slider6Label.Content = String.Format("{0:0.00}", attenuations[6]);
                    break;
                case 7:
                    Slider7Label.Content = String.Format("{0:0.00}", attenuations[7]);
                    break;
                case 8:
                    Slider8Label.Content = String.Format("{0:0.00}", attenuations[8]);
                    break;
                case 9:
                    Slider9Label.Content = String.Format("{0:0.00}", attenuations[9]);
                    break;
                case 10:
                    Slider10Label.Content = String.Format("{0:0.00}", attenuations[10]);
                    break;
                case 11:
                    Slider11Label.Content = String.Format("{0:0.00}", attenuations[11]);
                    break;
                case 12:
                    Slider12Label.Content = String.Format("{0:0.00}", attenuations[12]);
                    break;
                default:
                    // unknown label
                    break;
            }
        }

        private void Slider0ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(0, e.NewValue);
        }
        private void Slider1ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(1, e.NewValue);
        }
        private void Slider2ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(2, e.NewValue);
        }
        private void Slider3ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(3, e.NewValue);
        }
        private void Slider4ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(4, e.NewValue);
        }
        private void Slider5ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(5, e.NewValue);
        }
        private void Slider6ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(6, e.NewValue);
        }
        private void Slider7ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(7, e.NewValue);
        }
        private void Slider8ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(8, e.NewValue);
        }
        private void Slider9ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(9, e.NewValue);
        }
        private void Slider10ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(10, e.NewValue);
        }
        private void Slider11ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(11, e.NewValue);
        }
        private void Slider12ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            SliderValueChanged(12, e.NewValue);
        }
    }
}
