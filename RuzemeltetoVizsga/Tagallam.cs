using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuzemeltetoVizsga
{
    class Tagallam
    {
        string nev;
        DateTime csatlakozas;

        public Tagallam(string beolvasottSor)
        {
            string[] daraboltSor = beolvasottSor.Split(';');
            nev = daraboltSor[0];
            csatlakozas = Convert.ToDateTime(daraboltSor[1]);
        }

        public string Nev { get => nev; set => nev = value; }
        public DateTime Csatlakozas { get => csatlakozas; set => csatlakozas = value; }
    }
}
