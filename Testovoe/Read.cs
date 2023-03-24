using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class Read
    {
        public void readRKK(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                string str;
                string str1 = " ";
                while ((line = reader.ReadLine()) != null)
                {
                    Team team = new Team();
                    team.RK = line.Substring(0, line.IndexOf('\t'));
                    if(team.RK != "Климов Сергей Александрович")
                    {
                        str = line.Substring(0, line.IndexOf('\t'));
                        for (int i = 0; i < str.Count(); i++)
                        {
                            char s = str[i];
                            if (char.IsUpper(s) == true)
                            {
                                StringBuilder sb = new StringBuilder(str1);
                                sb.Append(s);
                                sb.Append('.');
                                str1 = sb.ToString();
                            }
                        }
                        str1 = str1.Remove(1, 2);
                        team.Otv = team.RK.ToString().Substring(0, line.IndexOf(' ')) + str1;
                        str1 = " ";
                    }
                    else
                    {
                        team.Otv = line.Substring(line.IndexOf('\t') + 1, ((line.IndexOf('.') + 2) - line.IndexOf('\t')));
                    }
                    Db_CMD cmd = new Db_CMD();
                    cmd.addRKK(team.Otv);
                }
            }
        }

        public void readObr(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                string str;
                string str1 = " ";
                while ((line = reader.ReadLine()) != null)
                {
                    Team team = new Team();
                    team.RK = line.Substring(0, line.IndexOf('\t'));
                    if (team.RK != "Климов Сергей Александрович")
                    {
                        str = line.Substring(0, line.IndexOf('\t'));
                        for (int i = 0; i < str.Count(); i++)
                        {
                            char s = str[i];
                            if (char.IsUpper(s) == true)
                            {
                                StringBuilder sb = new StringBuilder(str1);
                                sb.Append(s);
                                sb.Append('.');
                                str1 = sb.ToString();
                            }
                        }
                        str1 = str1.Remove(1, 2);
                        team.Otv = team.RK.ToString().Substring(0, line.IndexOf(' ')) + str1;
                        str1 = " ";
                    }
                    else
                    {
                        team.Otv = line.Substring(line.IndexOf('\t') + 1, ((line.IndexOf('.') + 2) - line.IndexOf('\t')));
                    }
                    Db_CMD cmd = new Db_CMD();
                    cmd.addObr(team.Otv);
                }
            }
        }
    }
}
