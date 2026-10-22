using System;
using System.Collections.Generic;
using System.Text;

namespace EromuApp
{
    internal class Szelgenerator : Eromu
    {
        public int Toronymagassag { get; set; }

        public Szelgenerator(string azonosito, int kapacitas, int toronymagassag) :base(azonosito, kapacitas)
        {
            this.Toronymagassag = toronymagassag;
        }

        public override int NapiTermeles(int orakSzama)
        {
            return base.NapiTermeles(orakSzama) + Toronymagassag * 10 * orakSzama;
        }

        public override string ToString()
        {
            return base.ToString() + $"  | Toronymagasság: {Toronymagassag} m";
        }
    }
}
