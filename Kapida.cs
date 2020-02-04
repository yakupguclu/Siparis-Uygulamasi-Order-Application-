using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
   public class Kapıda:Odeme
    {
         public string adres { get; set; }

        public override decimal fiyat(decimal temp)
        {
            return base.fiyat(temp);
        }


    }
}
