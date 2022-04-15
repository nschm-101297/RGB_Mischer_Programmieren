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
        public Oeffnen()
        {
            InitializeComponent();
            color = (ColorValues)TryFindResource("color");
            openColor = new OpenFileDialog
            {
                InitialDirectory = Properties.Settings.Default.Pfad_Save,
            };
        }

        private void btn_WeiterClick(object sender, RoutedEventArgs e)
        {
            if (rb_CSV.IsChecked == true)
                LoadCSVValues();
            else if (rb_Datenbank.IsChecked == true)
                LoadDBValues();
            else
                LoadXMLValues();
        }

        private void btn_AbbrechenClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void LoadCSVValues()
        {
            ShowEditor("txt");
        }

        private void LoadDBValues()
        {

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
                openColor.FileName = "Color.txt";
            }
            else
            {
                openColor.Filter = "XML Files (*.xml) | *.xml";
                openColor.FileName = "Color.xml";
            }
            if (openColor.ShowDialog() == true)
            {
                Properties.Settings.Default.Pfad_Save = openColor.FileName;
                Properties.Settings.Default.Save();
            }
        }
    }
}
