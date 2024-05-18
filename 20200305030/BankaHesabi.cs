using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20200305030
{
    public class BankaHesabi
    {
        private decimal toplamGelenPara;
        private decimal toplamGidenPara;

        public BankaHesabi()
        {
            toplamGelenPara = 0;
            toplamGidenPara = 0;
        }

        public void ParaGelisi(decimal miktar)
        {
            toplamGelenPara += miktar;
        }

        public void ParaGidis(decimal miktar)
        {
            toplamGidenPara += miktar;
        }

        public decimal ToplamGelenPara()
        {
            return toplamGelenPara;
        }

        public decimal ToplamGidenPara()
        {
            return toplamGidenPara;
        }

        public decimal Bakiye()
        {
            return toplamGelenPara - toplamGidenPara;
        }
    }

}
