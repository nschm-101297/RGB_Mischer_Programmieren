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
using System.Globalization;
using Color_Library;
using System.Configuration;
using System.Collections.Specialized;


namespace RGB_Mischer_Programmieren
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ColorValues color;
        Speichern speichern;
        Oeffnen oeffnen;
        Binding backgroundWindow;
        bool valueChangedBlocked = false;
        public MainWindow()
        {
            InitializeComponent(); 
            color = (ColorValues)TryFindResource("color");
            rc_Finished_Color.Fill = colorChanged();
            txt_FinishedCommand.Text = FinishedCommand();
            var newColor = Properties.Settings.Default.BackgroundWindow;
            this.Background = new SolidColorBrush(new Color { A = newColor.A, B = newColor.B, R = newColor.R, G = newColor.G });
            backgroundWindow = new Binding();
        }

        private void SetBinding()
        {

        }

        private void sl_Red_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            /*
             https://stackoverflow.com/questions/5641078/convert-from-color-to-brush
             https://docs.microsoft.com/de-de/dotnet/api/system.drawing.solidbrush.-ctor?view=dotnet-plat-ext-6.0
             FromArgb: Erster Parameter Transparenz, zweiter Wert Rot, dritter Parameter Wert Grün, vierter Parameter Wert Blau
            https://stackoverflow.com/questions/4615779/converting-system-windows-media-color-to-system-drawing-color
            TickFrequency bei Slider ist Schrittweite
             */
            if (rc_Finished_Color.Visibility == Visibility.Visible)
            {
                rc_Finished_Color.Fill = colorChanged();
            }
            else if(c_Finished_Color.Visibility == Visibility.Visible)
            {
                c_Finished_Color.Fill = colorChanged();
            }
            else
            {
                tr_Finished_Color.Fill = colorChanged();
            }
        }

        private void sl_Green_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rc_Finished_Color.Visibility == Visibility.Visible)
            {
                rc_Finished_Color.Fill = colorChanged();
            }
            else if (c_Finished_Color.Visibility == Visibility.Visible)
            {
                c_Finished_Color.Fill = colorChanged();
            }
            else
            {
                tr_Finished_Color.Fill = colorChanged();
            }
        }

        private void sl_Blue_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rc_Finished_Color.Visibility == Visibility.Visible)
            {
                rc_Finished_Color.Fill = colorChanged();
            }
            else if (c_Finished_Color.Visibility == Visibility.Visible)
            {
                c_Finished_Color.Fill = colorChanged();
            }
            else
            {
                tr_Finished_Color.Fill = colorChanged();
            }
        }
        private void sl_Trans_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (rc_Finished_Color.Visibility == Visibility.Visible)
            {
                rc_Finished_Color.Fill = colorChanged();
            }
            else if (c_Finished_Color.Visibility == Visibility.Visible)
            {
                c_Finished_Color.Fill = colorChanged();
            }
            else
            {
                tr_Finished_Color.Fill = colorChanged();
            }
        }
        private void btn_Rectangle_Click(object sender, RoutedEventArgs e)
        {
            rc_Finished_Color.Visibility = Visibility.Visible;
            c_Finished_Color.Visibility = Visibility.Hidden;
            tr_Finished_Color.Visibility = Visibility.Hidden;
            rc_Finished_Color.Fill = colorChanged();
            txt_FinishedCommand.Text = FinishedCommand();
        }

        private void btn_Circle_Click(object sender, RoutedEventArgs e)
        {
            rc_Finished_Color.Visibility = Visibility.Hidden;
            c_Finished_Color.Visibility = Visibility.Visible;
            tr_Finished_Color.Visibility = Visibility.Hidden;
            c_Finished_Color.Fill = colorChanged();
            txt_FinishedCommand.Text = FinishedCommand();
        }

        private void btn_Triangle_Click(object sender, RoutedEventArgs e)
        {
            rc_Finished_Color.Visibility = Visibility.Hidden;
            c_Finished_Color.Visibility = Visibility.Hidden;
            tr_Finished_Color.Visibility = Visibility.Visible;
            tr_Finished_Color.Fill = colorChanged();
            txt_FinishedCommand.Text = FinishedCommand();
        }
        private SolidColorBrush colorChanged()
        {
            SolidColorBrush newColor = null;
            if (valueChangedBlocked == false)
            {
                if (color == null)
                    color = new ColorValues();
                color.Red = Convert.ToByte(sl_Red.Value);
                color.Green = Convert.ToByte(sl_Green.Value);
                color.Blue = Convert.ToByte(sl_Blue.Value);
                color.Transparency = Convert.ToByte(sl_Trans.Value);
                color.MyColor = Color.FromArgb(color.Transparency, color.Red, color.Green, color.Blue);
                newColor = new SolidColorBrush(color.MyColor);
            }
            //newColor = new SolidColorBrush(color.MyColor);
            return newColor;
        }

        private void CopyContent_Click(object sender, RoutedEventArgs e)
        {
            txt_FinishedCommand.Focus();
            txt_FinishedCommand.SelectAll();
            txt_FinishedCommand.Copy();
        }

        private string FinishedCommand()
        {
            string finishedCommand = "";
            string command = "";
            if(rc_Finished_Color.Visibility == Visibility.Visible)
            {
                finishedCommand = "<Rectangle Height=\"" + rc_Finished_Color.Height.ToString() +
                    "\" Width=\"" + rc_Finished_Color.Width.ToString() + "\" Stroke=\"" + 
                    rc_Finished_Color.Stroke.ToString() + "\" StrokeThickness=\"" + 
                    rc_Finished_Color.StrokeThickness.ToString() + "\" Margin=\"" + 
                    rc_Finished_Color.Margin.ToString() + "\" Fill=\"" + rc_Finished_Color.Fill.ToString() +
                    "\"/>";
            }
            else if(c_Finished_Color.Visibility == Visibility.Visible)
            {
                finishedCommand = "<Ellipse Height=\"" + c_Finished_Color.Height.ToString() +
                    "\" Width=\"" + c_Finished_Color.Width.ToString() + "\" Stroke=\"" +
                    c_Finished_Color.Stroke.ToString() + "\" StrokeThickness=\"" +
                    c_Finished_Color.StrokeThickness.ToString() + "\" Margin=\"" +
                    c_Finished_Color.Margin.ToString() + "\" Fill=\"" + c_Finished_Color.Fill.ToString() +
                    "\"/>";
            }
            else
            {
                command = "<Polygone Points=\"" + tr_Finished_Color.Points.ToString() +
                   "\" Stroke=\"" +
                   tr_Finished_Color.Stroke.ToString() + "\" StrokeThickness=\"" +
                   tr_Finished_Color.StrokeThickness.ToString() + "\" Margin=\"" +
                   tr_Finished_Color.Margin.ToString() + "\" Fill=\"" + tr_Finished_Color.Fill.ToString() +
                   "\"/>";
                finishedCommand = command.Replace(';', ',');
            }
            return finishedCommand;
        }

        private void ValuesSaving(object sender, RoutedEventArgs e)
        {
            /*
            Muss Instanz hier aufrufen, weil beim Schließen des Fensters die Ressource freigegeben wird;
            anders wäre, wenn über Visibility arbeiten würde
             */
            string message = "Der Speichervorgang kann nicht ausgeführt werden!\nEs wurde kein Name" +
                " für die Farbe vergeben.";
            string caption = "Fehler speichern";
            if (txt_NameColor.Text == "")
            {
                MessageBox.Show(message, caption, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            color.ColorName = txt_NameColor.Text;
            speichern = new Speichern();
            speichern.speichernFenster.ShowDialog();
        }

        private void ChangeBackgroundColor(object sender, RoutedEventArgs e)
        {
            //https://microsoft-programmierer.de/Net-Framework/WPF/Controls-Elements/WPF_colon_-Background-zur-Laufzeit-%C3%A4ndern?2010
            Properties.Settings.Default.BackgroundWindow = System.Drawing.Color.FromArgb(color.Transparency,
              color.Red, color.Green, color.Blue);
            Properties.Settings.Default.Save();
            this.Background = new SolidColorBrush(Color.FromArgb(color.Transparency, color.Red, color.Green, color.Blue));
        }

        private void ChangeFontColor(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Foreground = System.Drawing.Color.FromArgb(color.Transparency,
                color.Red, color.Green, color.Blue);
            Properties.Settings.Default.Save();
        }

        private void ChangeBackgroundColorControls(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Background = System.Drawing.Color.FromArgb(color.Transparency,
               color.Red, color.Green, color.Blue);
            Properties.Settings.Default.BackgroundButton = System.Drawing.Color.FromArgb(color.Transparency,
               color.Red, color.Green, color.Blue);
            Properties.Settings.Default.Save();
        }

        private void ValuesOpening(object sender, RoutedEventArgs e)
        {
            valueChangedBlocked = true;
            oeffnen = new Oeffnen();
            oeffnen.oeffnenFenster.ShowDialog();
            color = null;
            color = (ColorValues)TryFindResource("color");
            //txt_Red.Text = color.Red.ToString();
            //txt_Green.Text = color.Green.ToString();
            //txt_Blue.Text = color.Blue.ToString();
            //txt_Trans.Text = color.Transparency.ToString();
            txt_NameColor.Text = color.ColorName;
            sl_Red.Value = color.Red;
            sl_Green.Value = color.Green;
            sl_Blue.Value = color.Blue;
            sl_Trans.Value = color.Transparency;
            valueChangedBlocked = false;
            if (rc_Finished_Color.Visibility == Visibility.Visible)
                rc_Finished_Color.Fill = colorChanged();
            else if (c_Finished_Color.Visibility == Visibility.Visible)
                c_Finished_Color.Fill = colorChanged();
            else
                tr_Finished_Color.Fill= colorChanged();

        }
    }
}
