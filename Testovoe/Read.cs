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
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Team team= new Team();
                    team.RK = line.Substring(0, line.IndexOf('\t'));
                    if(team.RK != "Климов Сергей Александрович")
                    {
                        team.Otv = team.RK;
                    }
                    else
                    {
                        team.Otv = line.Substring(line.IndexOf('\t') + 1, ((line.IndexOf('.') + 2) - line.IndexOf('\t')));
                    }
                    count = (line.ToCharArray().Where(c => c == ';').Count() + 1) - line.ToCharArray().Where(c => c == '(').Count();
                    Db_CMD cmd = new Db_CMD();
                    cmd.addRKK(team.Otv, count);
                }
            }
        }

        public void readObr(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                int count = 0;
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    Team team = new Team();
                    team.RK = line.Substring(0, line.IndexOf('\t'));
                    if (team.RK != "Климов Сергей Александрович")
                    {
                        team.Otv = team.RK;
                    }
                    else
                    {
                        team.Otv = line.Substring(line.IndexOf('\t') + 1, ((line.IndexOf('.') + 2) - line.IndexOf('\t')));
                    }
                    count = (line.ToCharArray().Where(c => c == ';').Count() + 1) - line.ToCharArray().Where(c => c == '(').Count();
                    Db_CMD cmd = new Db_CMD();
                    cmd.addObr(team.Otv, count);
                }
            }
        }

    }
}
