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
using System.IO;

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

        // If the attenuation is fresh.
        private bool newFile = true;
        // If the attenuation have been changed.
        private bool fileChanged = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// External Triggers
        /// </summary>
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
        private void New_Click(object sender, RoutedEventArgs e)
        {
            // Clears all attenuations.
            for (int i = 0; i < BAND_NUM; ++i)
            {
                attenuations[i] = 0;
            }
            // File is no longer changed but new.
            fileChanged = false;
            newFile = true;
            // Update label contents.
            UpdateAllContents();
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveToFile();
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (fileChanged)
            {
                string messageBoxText = "Do you want to save changes?";
                string caption = "Word Processor";
                MessageBoxButton button = MessageBoxButton.YesNoCancel;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result;

                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

                switch (result)
                {
                    case MessageBoxResult.Yes:
                        // Save to file.
                        SaveToFile();
                        // Successfully completed program.
                        Environment.Exit(0);
                        break;
                    case MessageBoxResult.No:
                        // Successfully completed program.
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            }
        }

        /// <summary>
        /// Helper Functions
        /// </summary>
        private void SliderValueChanged(int bandNo, double newValue)
        {
            // Store the attenuation.
            attenuations[bandNo] = newValue;
            // Update label.
            UpdateLabelContentFor(bandNo);
            // File has been changed.
            fileChanged = true;
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
                    // Unknown label, do nothing.
                    break;
            }
        }
        private void UpdateSliderValueFor(int bandNo)
        {
            switch (bandNo)
            {
                case 0:
                    Slider0.Value = attenuations[0];
                    break;
                case 1:
                    Slider1.Value = attenuations[1];
                    break;
                case 2:
                    Slider2.Value = attenuations[2];
                    break;
                case 3:
                    Slider3.Value = attenuations[3];
                    break;
                case 4:
                    Slider4.Value = attenuations[4];
                    break;
                case 5:
                    Slider5.Value = attenuations[5];
                    break;
                case 6:
                    Slider6.Value = attenuations[6];
                    break;
                case 7:
                    Slider7.Value = attenuations[7];
                    break;
                case 8:
                    Slider8.Value = attenuations[8];
                    break;
                case 9:
                    Slider9.Value = attenuations[9];
                    break;
                case 10:
                    Slider10.Value = attenuations[10];
                    break;
                case 11:
                    Slider11.Value = attenuations[11];
                    break;
                case 12:
                    Slider12.Value = attenuations[12];
                    break;
                default:
                    // Unknown label, do nothing.
                    break;
            }
        }
        private void UpdateAllContents()
        {
            for (int i = 0; i < BAND_NUM; ++i)
            {
                UpdateSliderValueFor(i);
                UpdateLabelContentFor(i);
            }
        }
        private void OpenFile()
        {
            try
            {
                // Read from eqdat file.
                string[] attenuationStrings = System.IO.File.ReadAllLines("attenuations.eqdat");
                // Check number of lines
                int len = attenuationStrings.Length;
                if (len != BAND_NUM)
                {
                    // Incorrect file length.
                    string messageBoxText = "Error: incorrect file length, expected: <" + BAND_NUM +">, was: <" + len + ">.";
                    string caption = "Error";
                    MessageBoxButton button = MessageBoxButton.OK;
                    MessageBoxImage icon = MessageBoxImage.Error;
                    MessageBoxResult result;
                    result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                    // Stop opening file.
                    return;
                }
                // Overwrite all attenuations.
                double[] attenuationBuf = new double[BAND_NUM];
                for (int i = 0; i < BAND_NUM; ++i)
                {
                    // Try parse double from input.
                    if (!(Double.TryParse(attenuationStrings[i], out attenuationBuf[i])))
                    {
                        // Incorrect file content.
                        string messageBoxText = "Error: incorrect file content at line <" + i +">.";
                        string caption = "Error";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Error;
                        MessageBoxResult result;
                        result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                        // Stop parsing file.
                        return;
                    }
                }
                attenuations = attenuationBuf;
                // File is no longer changed nor new.
                fileChanged = false;
                newFile = false;
                // Update label contents.
                UpdateAllContents();
                // Finished opening file.
                return;
            }
            catch (Exception)
            {
                // Incorrect file content.
                string messageBoxText = "Error: failed to open file.";
                string caption = "Error";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Error;
                MessageBoxResult result;
                result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                // Stop opening file.
                return;
            }
        }
        private void SaveToFile()
        {
            // Check if file has been changed or is new
            if (fileChanged || newFile)
            {
                // Convert all attenuations to strings.
                string[] attenuationStrings = new string[BAND_NUM];
                for (int i = 0; i < BAND_NUM; ++i)
                {
                    attenuationStrings[i] = attenuations[i].ToString();
                }
                // File is no longer changed nor new.
                fileChanged = false;
                newFile = false;
                // Write to eqdat file.
                File.WriteAllLines("attenuations.eqdat", attenuationStrings);
            }
        }
    }
}
