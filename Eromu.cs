using System;
using System.Collections.Generic;
using System.Text;

namespace EromuApp
{
    internal class Eromu
    {
        public string Azonosito { get; set; }

        protected int kapacitasKW;

        public int KapacitasKW
        {
            get
            {
                return kapacitasKW;
            }
            set
            {
                if (value <= 0)
                {
                    kapacitasKW = 100;
                }
                else
                {
                    kapacitasKW = value;
                }
            }
        }

        private static int osszesEromuSzama;

        public static int OsszesEromuSzama { get { return osszesEromuSzama; } }

        public Eromu(string azonosito, int kapacitas)
        {
            this.Azonosito = azonosito;
            this.KapacitasKW = kapacitas;
            osszesEromuSzama++;
        }

        public virtual int NapiTermeles(int orakSzama)
        {
            return KapacitasKW * orakSzama;
        }

        public override string ToString()
        {
            return $"Erőmű {Azonosito} | Kapacitás: {KapacitasKW} kW";
        }


    }
}
