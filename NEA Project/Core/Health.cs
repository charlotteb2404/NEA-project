using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace NEA_Project.Core
{
    public class Health
    {
        protected int _health;
        public virtual void SetHealth(int health)
        {
            _health = 6;
           
        }
        public virtual int GetHealth()
        {
            return _health;
        }
    }
}
