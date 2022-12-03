using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilities
{
    public class FileReader
    {
        public static string ReadAllText(string path)
        {
            string text;

            if(File.Exists(path))
            {
                text = File.ReadAllText(path);
            }
            else
            {
                throw new FileNotFoundException();
            }

            return text;
        }
    }
}
