using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Color_Library
{
    public class Database_ColorValues : DbContext
    {
        //Link EntityFramework
        //https://www.youtube.com/watch?v=KBaTQ0GVUXQ
        //Muss das in Projekt hinzufügen unter PropertyGroup, Doppelklick auf Projektnamen
        //<StartWorkingDirectory>$(MsBuildProjectDirectory)</StartWorkingDirectory>
        public DbSet<ColorValues> colorValues { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //string path = @"D:\Projekte_Informatik\C#\Projekte\RGB_Mischer_Programmieren\Color_Library\bin\Debug\net6.0\datenbank.db";
            string path = @"D:\Projekte_Informatik\C#\Projekte\RGB_Mischer_Programmieren\RGB_Mischer_Programmieren\RGB_Mischer_Programmieren\bin\Debug\net6.0-windows\datenbank.db";
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite($"Data Source={path}");
            
           
        }
    }
}
