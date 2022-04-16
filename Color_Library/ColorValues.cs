using System.Windows.Media;
using System.Windows;
using System;

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
        public Byte Red { get; set; }
        public Byte Green { get; set; }
        public Byte Blue { get; set; }
        public Byte Transparency { get; set; }
        public string ColorName { get; set; }
        public Color MyColor { get; set; }
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
        #endregion
    }
}