using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Testovoe
{
    internal class Team
    {
        public string RK { get; set; }
        public string Otv { get; set; }
        public int Count { get; set;}

        public Team(string rk_, string otv_, int count_)
        {
            RK= rk_;
            Otv= otv_;
            Count= count_;
        }

        public Team()
        {
            RK = "";
            Otv = "";
            Count = 0;
        }

    }
}
