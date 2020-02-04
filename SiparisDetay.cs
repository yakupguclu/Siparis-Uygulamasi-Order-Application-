using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeOrijinal
{
    public class SiparisDetay
    {
        public int Adet { get; set; }
        public int Vergi_Durumu { get; set; }

        public decimal Ara_Toplam(int temp1, int temp2)
        {
            decimal result = 0;
            result = (temp1 * temp2);
            return result;
        }
        public decimal Hesap_Agirligi()
        {
            return 0;
        }
    }
}
