using System;

namespace clsTablolar
{
    public class csStokTedarik : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }


        private int _HizliSatisButonID;
        private string _ButonAdi;
        private decimal _ButonTop;
        private decimal _ButonLeft;
        private decimal _ButonWidth;
        private decimal _ButonHeith;
        private int _YapacagiIslem;

        public int HizliSatisButonID
        {
            get { return _HizliSatisButonID; }
            set { _HizliSatisButonID = value; }
        }
        public string ButonAdi
        {
            get { return _ButonAdi; }
            set { _ButonAdi = value; }
        }
        public decimal ButonTop
        {
            get { return _ButonTop; }
            set { _ButonTop = value; }
        }
        public decimal ButonLeft
        {
            get { return _ButonLeft; }
            set { _ButonLeft = value; }
        }
        public decimal ButonWidth
        {
            get { return _ButonWidth; }
            set { _ButonWidth = value; }
        }
        public decimal ButonHeith
        {
            get { return _ButonHeith; }
            set { _ButonHeith = value; }
        }
        public int YapacagiIslem
        {
            get { return _YapacagiIslem; }
            set { _YapacagiIslem = value; }
        }
    }
}
