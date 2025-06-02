using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityStaffManagement
{
    public interface IZamYap
    {
        void ZamYap();
    }

    public abstract class Personel
    {
        public string Ad { get; set; }
        public string Soyad { get; set; }

        public abstract decimal MaasHesapla();

        public override string ToString()
        {
            return $"{GetType().Name} - {Ad} {Soyad}";
        }
    }

    public abstract class AkademikPersonel : Personel
    {
        public int DersSaati { get; set; }
    }

    public abstract class IdariPersonel : Personel
    {
    }

    public class Professor : AkademikPersonel, IZamYap
    {
        private decimal tabanMaas = 200000;

        public override decimal MaasHesapla() => tabanMaas + (DersSaati * 3000);

        public void ZamYap()
        {
            tabanMaas *= 1.2m;
            DersSaati = (int)(DersSaati * 1.5);
        }
    }

    public class Docent : AkademikPersonel, IZamYap
    {
        private decimal tabanMaas = 160000;

        public override decimal MaasHesapla() => tabanMaas + (DersSaati * 2000);

        public void ZamYap()
        {
            tabanMaas *= 1.2m;
            DersSaati = (int)(DersSaati * 1.5);
        }
    }

    public class DrOgrUyesi : AkademikPersonel, IZamYap
    {
        private decimal tabanMaas = 130000;

        public override decimal MaasHesapla() => tabanMaas + (DersSaati * 1000);

        public void ZamYap()
        {
            tabanMaas *= 1.2m;
            DersSaati = (int)(DersSaati * 1.5);
        }
    }

    public class ArasGor : AkademikPersonel
    {
        public override decimal MaasHesapla() => 100000;
    }

    public class Memur : IdariPersonel, IZamYap
    {
        private decimal maas = 90000;

        public override decimal MaasHesapla() => maas;

        public void ZamYap()
        {
            maas *= 1.3m;
        }
    }

    public class TeknikPersonel : IdariPersonel, IZamYap
    {
        private decimal maas = 96000;

        public override decimal MaasHesapla() => maas;

        public void ZamYap()
        {
            maas *= 1.3m;
        }
    }
}