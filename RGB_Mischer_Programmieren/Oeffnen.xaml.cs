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
            openColor = new OpenFileDialog
            {
                InitialDirectory = Properties.Settings.Default.Pfad_Save,
            };
            //lst_Color_Database.ItemsSource = colorValues;
        }

        private void btn_WeiterClick(object sender, RoutedEventArgs e)
        {
            if(lst_Color_Database.Visibility == Visibility.Visible
                &&
                lst_Color_Database.SelectedValue != null) { 
                color = (ColorValues)lst_Color_Database.SelectedItem;
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
            ShowEditor("xml");
            file = new FileStream(Properties.Settings.Default.Pfad_Save, FileMode.Open);
            deserialization = new XmlSerializer(typeof(ColorValues));
            color = (ColorValues)deserialization.Deserialize(file);
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
    }
}
