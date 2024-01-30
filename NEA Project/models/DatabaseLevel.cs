using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEA_Project.models
{
    public class DatabaseLevel
    {
        public int  id { get; set; }
        public int LevelNumber { get; set; }
        public string MapSource { get; set; }
        public int NumberOfPolice { get; set; }
        public int Difficulty { get; set; }
        public int NumberOfCoins { get; set; }
    }
}
