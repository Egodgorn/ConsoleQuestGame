using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Game2
{
    class MapLoader
    {
        public string[,] LoadMap(string _path)
        {
            string[,] txtmap = new string[19, 35];
            using (StreamReader sr = new StreamReader(_path))
            {
                int i = 0;
                string line ;
                do
                {
                    line = sr.ReadLine();
                    if (line != null)
                    {
                        for (int j = 0; j < line.Length; j++)
                        {
                            txtmap[i, j] = Convert.ToString(line[j]);
                        }
                        i++;
                    }

                }
                while (line != null);
                
            }
            return txtmap;
        }
    }
}
