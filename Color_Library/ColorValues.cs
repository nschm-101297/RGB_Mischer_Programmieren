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
    }
}