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

namespace RGB_Mischer_Programmieren
{
    /// <summary>
    /// Interaktionslogik für Speichern.xaml
    /// </summary>
    public partial class Speichern : Window
    {
        public Speichern()
        {
            /*
             Eigenschaft IsCancel bei Button Abbrechen bewirkt dass Form geschlossen ohne Ereignishandler
             + Drücken ESC-Taste
             */
            InitializeComponent();
        }

        private void OnSaveCSV(object sender, RoutedEventArgs e)
        {

        }

        private void OnSaveDatenbank(object sender, RoutedEventArgs e)
        {

        }

        private void OnSaveXML(object sender, RoutedEventArgs e)
        {

        }

        private void btn_WeiterClick(object sender, RoutedEventArgs e)
        {

        }

    }
}
