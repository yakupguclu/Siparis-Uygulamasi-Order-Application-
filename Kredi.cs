using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
   public class Kredi:Odeme
    {
        public string KartNo { get; set; }
        public string KartTipi { get; set; }
        public string Tarih { get; set; }
        public string CVV { get; set; }

        public override decimal fiyat(decimal temp)
        {
            temp += temp * 0.02m;
            return base.fiyat(temp);
        }
    }
}
