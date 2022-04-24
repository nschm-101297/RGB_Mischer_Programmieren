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
using System.Windows.Shapes;
using Color_Library;
using Microsoft.Win32;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace RGB_Mischer_Programmieren
{
    /// <summary>
    /// Interaktionslogik für Oeffnen.xaml
    /// </summary>
    public partial class Oeffnen : Window
    {
        ColorValues color;
        OpenFileDialog openColor;
        XmlSerializer deserialization;
        FileStream file;
        ObservableCollection<ColorValues> colorValues;
        public Oeffnen()
        {
            /*
             Link Aufbau System.Windows.Media
            https://docs.microsoft.com/de-de/dotnet/api/system.windows.media.color?view=windowsdesktop-6.0
             */
            InitializeComponent();
            color = (ColorValues)TryFindResource("color");
            var newColor = Properties.Settings.Default.BackgroundWindow;
            this.Background = new SolidColorBrush(new Color { A = newColor.A, B = newColor.B, R = newColor.R, G = newColor.G });
            openColor = new OpenFileDialog
            {
                InitialDirectory = Properties.Settings.Default.Pfad_Save,
            };
            btn_Weiter.IsEnabled = false;
        }

        private void btn_WeiterClick(object sender, RoutedEventArgs e)
        {
            ColorValues values = new ColorValues();
            if(lst_Color_Database.Visibility == Visibility.Visible
                &&
                lst_Color_Database.SelectedValue != null) { 
                values = (ColorValues)lst_Color_Database.SelectedItem;
                color = (ColorValues)TryFindResource("color");
                //color = (ColorValues)lst_Color_Database.SelectedItem;
                color.Red = values.Red;
                color.Green = values.Green;
                color.Blue = values.Blue;
                color.Transparency = values.Transparency;
                color.ColorName = values.ColorName;
                color.MyColorZeichenkette = values.MyColorZeichenkette;
                color.MyColor = values.MyColor;
                rb_Datenbank.IsChecked = false;
                this.Close();
            }
            if (rb_CSV.IsChecked == true)
                LoadCSVValues();
            else if (rb_Datenbank.IsChecked == true) { 
                LoadDBValues();
                rb_CSV.Visibility = Visibility.Collapsed;
                rb_Datenbank.Visibility = Visibility.Collapsed;
                rb_XML.Visibility = Visibility.Collapsed;
                lst_Color_Database.Visibility = Visibility.Visible;
            }
            else if(rb_XML.IsChecked == true) 
                LoadXMLValues();
        }

        private void btn_AbbrechenClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadCSVValues()
        {
            ShowEditor("txt");
            color = (ColorValues)TryFindResource("color");
            string[] values = File.ReadAllLines(Properties.Settings.Default.Pfad_Save);
            foreach(string data in values)
            {
                string[] values2 = data.Split(',');
                color.Transparency = Convert.ToByte(values2[0]);
                color.Red = Convert.ToByte(values2[1]);
                color.Green = Convert.ToByte(values2[2]);
                color.Blue = Convert.ToByte(values2[3]);
                color.ColorName = values2[4];
                color.MyColor = (Color)ColorConverter.ConvertFromString(values2[5]);
            }
            this.Close ();
        }

        private void LoadDBValues()
        {
            color = (ColorValues)TryFindResource("color");
            colorValues = new ObservableCollection<ColorValues>();
            using(var data = new Database_ColorValues())
            {
                var query = data.colorValues.ToList();
                foreach(var value in query)
                {
                    value.ChangeStringColor();
                    colorValues.Add(value);
                }
            }
            //this.Close();
            lst_Color_Database.ItemsSource = colorValues;
        }
        private void LoadXMLValues()
        {
            color = (ColorValues)TryFindResource("color");
            ShowEditor("xml");
            file = new FileStream(Properties.Settings.Default.Pfad_Save, FileMode.Open);
            deserialization = new XmlSerializer(typeof(ColorValues));
            ColorValues colorValues = (ColorValues)deserialization.Deserialize(file);
            //color = (ColorValues)deserialization.Deserialize(file);
            color.Red = colorValues.Red;
            color.Green = colorValues.Green;
            color.Blue = colorValues.Blue;
            color.Transparency = colorValues.Transparency;
            color.ColorName = colorValues.ColorName;
            color.MyColor = colorValues.MyColor;
            colorValues.MyColorZeichenkette = colorValues.MyColorZeichenkette;
            file.Close();
            this.Close();
        }
        private void ShowEditor(string datatype)
        {
            if (datatype == "txt")
            {
                openColor.Filter = "Text File (*.txt) | *.txt";
            }
            else
            {
                openColor.Filter = "XML Files (*.xml) | *.xml";
            }
            if (openColor.ShowDialog() == true)
            {
                Properties.Settings.Default.Pfad_Save = openColor.FileName;
                Properties.Settings.Default.Save();
            }
        }
        private void rb_Clicked(object sender, RoutedEventArgs e)
        {
            EvaluateRadioButtons();
        }

        private void EvaluateRadioButtons()
        {
            if (rb_CSV.IsChecked == true ||
                rb_Datenbank.IsChecked == true ||
                rb_XML.IsChecked == true)
                btn_Weiter.IsEnabled = true;
            else
                btn_Weiter.IsEnabled = false;
        }
    }
}
