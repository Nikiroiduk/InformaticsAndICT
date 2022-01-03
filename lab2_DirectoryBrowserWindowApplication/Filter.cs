using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2_DirectoryBrowserWindowApplication
{
    public static class Filter
    {
        public static List<string> imgFiles = new List<string>() { "jpg", "png", "gif", "tiff", "bmp" };
        public static List<string> officeFiles = new List<string>() { "xls", "xlsx", "doc", "docx", "pdf", "txt" };
        public static List<string> archivesFiles = new List<string>() { "zip", "rar", "7z", "z01", "gz", "zipx", "tgz" };
        public static List<string> exedllFiles = new List<string>() { "exe", "dll" };
    }
}
