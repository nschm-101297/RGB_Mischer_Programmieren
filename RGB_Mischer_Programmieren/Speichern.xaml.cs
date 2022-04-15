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
using System.IO;
using System.Xml.Serialization;
using Color_Library;
using Microsoft.Win32;

namespace RGB_Mischer_Programmieren
{
    /// <summary>
    /// Interaktionslogik für Speichern.xaml
    /// </summary>
    public partial class Speichern : Window
    {
        ColorValues color;
        SaveFileDialog saveColor;
        XmlSerializer colorSerializer;
        FileStream colorStream;
        StringBuilder colorCSV;
        public Speichern()  
        {
            /*
             Eigenschaft IsCancel bei Button Abbrechen bewirkt dass Form geschlossen ohne Ereignishandler
             + Drücken ESC-Taste
             */
            InitializeComponent();
            color = (ColorValues)TryFindResource("color");
            saveColor = new SaveFileDialog
            {
                InitialDirectory = Properties.Settings.Default.Pfad_Save,
            };
        }

    public Speichern(ColorValues savingColor) : this()
        {
            //InitializeComponent();
            color = savingColor;
            saveColor = new SaveFileDialog
            {
                InitialDirectory = Properties.Settings.Default.Pfad_Save,
            };
        }

        private void OnSaveCSV()
        {
            showExplorer("txt");
            colorCSV = new StringBuilder();
            colorCSV.Clear();
            colorCSV.AppendLine(color.ToString());
            File.WriteAllText(Properties.Settings.Default.Pfad_Save, colorCSV.ToString());
        }

        private void OnSaveDatenbank()
        {

        }

        private void OnSaveXML()
        {
            showExplorer("xml");
            colorSerializer = new XmlSerializer(typeof(ColorValues));
            colorStream = new FileStream(Properties.Settings.Default.Pfad_Save, FileMode.Create);
            colorSerializer.Serialize(colorStream, color);
            colorStream.Close();
        }

        private void btn_WeiterClick(object sender, RoutedEventArgs e)
        {
            if (ch_SaveCSV.IsChecked == true)
                OnSaveCSV();
            else if (ch_SaveDatenbank.IsChecked == true)
                OnSaveDatenbank();
            else if (ch_SaveXML.IsChecked == true)
                OnSaveXML();

            this.Close();
        }

        private void showExplorer(string datatype)
        {
            if(datatype == "txt")
            {
                saveColor.Filter = "Text File (*.txt) | *.txt";
                saveColor.FileName = "Color.txt";
            }
            else
            {
                saveColor.Filter = "XML Files (*.xml) | *.xml";
                saveColor.FileName = "Color.xml";
            }
            if (saveColor.ShowDialog() == true)
            {
                Properties.Settings.Default.Pfad_Save = saveColor.FileName;
                Properties.Settings.Default.Save();
            }
        }

        private void btn_AbbrechenClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
