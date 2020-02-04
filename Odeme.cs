using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
    public abstract class Odeme
    {
        public  decimal Fiyat { get; set; }
        
        public virtual decimal fiyat(decimal temp)
        {
            this.Fiyat=temp;
            return Fiyat;
        }
        
    }
}
