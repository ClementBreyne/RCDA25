using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Rectangle : Forme
    {
        public int Longueur { get; set; }
        public int Largeur { get; set; }
        public override double Aire => (Longueur*Largeur);

        public override double perimetre => (Longueur+Largeur)*2;

        public override string ToString()
        {
            return $"Rectangle de longueur {Longueur} et de largeur {Largeur}"+ Environment.NewLine+ base.ToString();
        }

    }
}
