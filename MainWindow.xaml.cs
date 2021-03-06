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
        private string? fileName;
        // If the attenuation have been changed.
        private bool fileChanged = false;

        // Serial com
        private SerialCom EqCom = new SerialCom();
        // If the app should auto send new atten
        private bool autoSendOn = false;

        public MainWindow()
        {
            InitializeComponent();
            _ = ConvertAttenuations(attenuations);
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
            // Update label contents.
            UpdateAllContents();
            // File is no longer changed but new.
            fileChanged = false;
            fileName = null;
        }
        private void Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
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
                        SaveFile();
                        break;
                    case MessageBoxResult.No:
                        break;
                    default:
                        return;
                }
            }
            // Successfully completed program.
            Environment.Exit(0);
        }
        private void Select_Click(object sender, RoutedEventArgs e)
        {
            // Show new window.
            SelectPort spw = new SelectPort();
            // Give it the serial com
            spw.EqCom = EqCom;
            spw.Show();
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            // Disable auto send.
            autoSendOn = false;
            AutoSendButton.IsChecked = false;
            // Send attenuations.
            SendAttenuations();
        }


        private void Auto_Send_Click(object sender, RoutedEventArgs e)
        {
            // Toggle auto send.
            autoSendOn = !autoSendOn;
            AutoSendButton.IsChecked = autoSendOn;
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
            // If auto send, send.
            if (autoSendOn)
            {
                SendAttenuations();
            }
            else
            {
                _ = ConvertAttenuations(attenuations);
            }
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
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Attenuations";
            dialog.DefaultExt = ".eqdat";
            dialog.Filter = "Equalizer Data File (.eqdat)|*.eqdat";

            // Show open file dialog box
            bool? dialogResult = dialog.ShowDialog();

            // Process open file dialog box results
            if (dialogResult == true)
            {
                // Open document
                string filename = dialog.FileName;
                if (fileName != null)
                {
                    OpenFileNamed(filename);
                }
            }
        }

        private void OpenFileNamed(string filename)
        {
            try
            {
                // Read from eqdat file.
                string[] attenuationStrings = System.IO.File.ReadAllLines(filename);
                // Check number of lines
                int len = attenuationStrings.Length;
                if (len != BAND_NUM)
                {
                    // Incorrect file length.
                    string messageBoxText = "Error: incorrect file length, expected: <" + BAND_NUM + ">, was: <" + len + ">.";
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
                        string messageBoxText = "Error: incorrect file content at line <" + i + ">.";
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
                // Update label contents.
                UpdateAllContents();
                // File is no longer changed nor new.
                fileChanged = false;
                fileName = filename;
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

        private void SaveFile()
        {
            if (fileName == null)
            {
                // Configure save file dialog box
                var dialog = new Microsoft.Win32.SaveFileDialog();
                dialog.FileName = "Attenuations";
                dialog.DefaultExt = ".eqdat";
                dialog.Filter = "Equalizer Data File (.eqdat)|*.eqdat";

                // Show save file dialog box
                bool? result = dialog.ShowDialog();

                // Process save file dialog box results
                if (result == true)
                {
                    // Save document
                    fileName = dialog.FileName;
                }
            }

            // Check if file has been changed or is new
            if (fileChanged)
            {
                // Convert all attenuations to strings.
                string[] attenuationStrings = new string[BAND_NUM];
                for (int i = 0; i < BAND_NUM; ++i)
                {
                    attenuationStrings[i] = attenuations[i].ToString();
                }
                // File is no longer changed nor new.
                fileChanged = false;
                // Write to eqdat file.
                if (fileName != null)
                {
                    File.WriteAllLines(fileName, attenuationStrings);
                }
            }
        }
        private void SendAttenuations()
        {
            string data = ConvertAttenuations(attenuations);
            EqCom.Send(data);
        }
        public string ConvertAttenuations(double[] atten)
        {
            short intAtten;
            char[] dataAtten = new char[2 * atten.Length];
            string readableData = "";

            for (int i = 0; i < atten.Length; ++i)
            {
                intAtten = Convert.ToInt16(atten[i] * 16384.0);
                dataAtten[2 * i] = Convert.ToChar(intAtten >> 8);
                dataAtten[2 * i + 1] = Convert.ToChar(intAtten);
                readableData += intAtten.ToString("X") + " ";
            }
            if (SerialOutput != null)
            {
                SerialOutput.Content = readableData;
            }
            string data = new string(dataAtten);

            return data;
        }

    }
}
