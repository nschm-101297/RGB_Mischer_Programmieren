using System.Windows.Media;
using System.Windows;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Color_Library
{
    public class ColorValues
    {
        #region Definition Konstruktor
        public ColorValues()
        {
            Red = 0;
            Green = 0;
            Blue = 0;
            Transparency = 0;
            ColorName = "";
        }
        #endregion

        #region Definition Eigenschaften
        [Key]
        public int ID { get; set; }
        public Byte Red { get; set; }
        public Byte Green { get; set; }
        public Byte Blue { get; set; }
        public Byte Transparency { get; set; }
        public string ColorName { get; set; }
        public string MyColorZeichenkette { get; set; }
        [NotMapped]
        private Color _myColor;
        [NotMapped]
        public Color MyColor { get
            {
                return _myColor;
            }
            set
            {
                _myColor = value;
                MyColorZeichenkette = _myColor.ToString();
            }
        }
        #endregion

        #region Definition Methoden
        public override string ToString()
        {
            string values = this.Transparency.ToString() + ","
                + this.Red.ToString() + "," + this.Green.ToString() + ","
                + this.Blue.ToString() + "," +  this.ColorName + "," 
                + this.MyColor.ToString();
            return values;
        }

        public void ChangeStringColor()
        {
            this.MyColor = (Color)ColorConverter.ConvertFromString(MyColorZeichenkette);
        }
        #endregion
    }
}