using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
   public  class Cek:Odeme
    {
        public string CekSahibi { get; set; }
        public string BasımTarihi { get; set; }
       
        public string CekNo { get; set; }

        public override decimal fiyat(decimal temp)
        {
            temp +=  temp * 0.18m;
            return base.fiyat(temp);
        }

    }
}
