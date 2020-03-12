using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSLab01
{
    class HTMLGenerator
    {
        private int x;
        private int y;
        private string row;
        private string header;
        private string footer;
        private string filename;

        string txt;

        public HTMLGenerator(int x, int y, string row, string header, string footer, string filename)
        {
            this.x = x;
            this.y = y;
            this.row = row;
            this.header = header;
            this.footer = footer;
            this.filename = filename;
        }

        public void Addheader()
        {
            txt += "<th>" + header + "</th>";
        }
        public void Addfooter()
        {
            txt += "<td>" + footer + "</td>";
        }
        public void Addrow()
        {
            txt += "<td>" + row + "</td>";
        }

        public void Generate()
        {
            
            txt = "<!DOCTYPE html><html><body><table>";
            //    txt += "";
            //    txt += "<body>";
            //    txt += "<table>";
            x = x + 2;
            for (int i = 0; i < x; i++)
            {
                txt += "<tr>";
                for (int j = 0; j < y; j++)
                {
                    if(i==0)
                    {
                        Addheader();
                    }
                    else if(i == x-1)
                    {
                        Addfooter();
                    }
                    else
                    {
                        Addrow();
                    }
                }
                txt += "</tr>";
            }
            txt += "</table></body></html>";
            //string path = @"c:\Users\sumczan\Desktop\chaszlab01\" + filename + ".html";
            string path = System.IO.Directory.GetCurrentDirectory();
            path += filename + ".html";
            System.IO.File.WriteAllText(path, txt);
        }

        public void GenerateFromCSV()
        {
            string path = System.IO.Directory.GetCurrentDirectory() + "test.csv";
            System.IO.StreamReader file = new System.IO.StreamReader(path);

            List<string> lines = new List<string>();
            string line;
            int counter = 0;

            while ((line = file.ReadLine()) != null)
            {
                lines.Add(line);
                System.Console.WriteLine(lines[counter]);
                counter++;
            }

            string text;
            int done = 0;
            int temp1 = 0;
            int temp2 = 0;
            counter = 0;

            text = "<!DOCTYPE html><html><body><table>";
            for (int i = 0; i < lines.Count(); i++)
            {

                text += "<tr>";
                line = lines[i];
                while (done != -1)
                {
                    if (i == 0)
                    {
                        counter++;
                        text += "<th>";
                        if (temp1 == 0)
                        {
                            temp1 = line.IndexOf(',');
                            text += line.Substring(0, temp1);
                            System.Console.WriteLine(text);
                            temp1++;
                        }
                        else
                        {
                            temp2 = line.IndexOf(',', temp1);
                            if (temp2 == -1)
                            {
                                done = -1;
                                temp2 = line.Count();
                                text += line.Substring(temp1, temp2 - temp1);
                                text += "</th>";
                                x = counter;
                                y = lines.Count();
                                break;
                            }
                            text += line.Substring(temp1, temp2 - temp1);
                            temp1 = temp2 + 1;
                        }
                        text += "</th>";
                    }
                    else
                    {
                        text += "<td>";
                        if (temp1 == 0)
                        {
                            temp1 = line.IndexOf(',');
                            text += line.Substring(0, temp1);
                            temp1++;
                        }
                        else
                        {
                            temp2 = line.IndexOf(',', temp1);
                            if (temp2 == -1)
                            {
                                done = -1;
                                temp2 = line.Count();
                                text += line.Substring(temp1, temp2 - temp1);
                                break;
                            }
                            text += line.Substring(temp1, temp2 - temp1);
                            temp1 = temp2 + 1;
                        }
                        text += "</td>";
                    }
                    System.Console.WriteLine(text);
                }
                temp1 = 0;
                temp2 = 0;
                done = 0;
                text += "</tr>";
            }

            text += "</table></body></html>";
            path = System.IO.Directory.GetCurrentDirectory() + filename + ".html";
            System.IO.File.WriteAllText(path, text);
        }
    }
}
