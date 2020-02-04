using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
    public class Urun
    {
        public decimal Kargo_Agirligi { get; set; }
        public string UrunAd { get; set; }

        public decimal Urun_Fiyati(int temp1,int temp2)
        {
            int Vergi = 118;
            decimal result = 0;
            result = (temp1 * temp2 * Vergi) / 100;
            return result;
        }
        public decimal TumToplam { get; set; }

        public decimal Urun_Agirlik()
        {
            return 0; 
        }
        public decimal Kargo_Agirlik_Hesapla(int temp)
        {
            decimal result = 0;
            result = this.Kargo_Agirligi + temp;
            return result;
        }
    }
}
