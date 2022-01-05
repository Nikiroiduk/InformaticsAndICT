using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3_Copywriter
{
    public static class Settings
    {
        public static string CopyrightText = "©copyright";
        public static string CopyrightDirectory = Environment.CurrentDirectory;
        public static int CopyrightTextFontSize = 30;
        public static Brush CopyrightTextColor = Brushes.Red;
    }
}
