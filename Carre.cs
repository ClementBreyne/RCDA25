using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Carre : Forme
    {
        public int Longueur { get; set; }

        public override double Aire => Longueur * Longueur;

        public override double perimetre => Longueur * 4;

        public override string ToString()
        {
            return $"Carre de côté {Longueur}"+Environment.NewLine+ base.ToString();
        }


    }
}
