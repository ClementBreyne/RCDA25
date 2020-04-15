using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Cercle : Forme
    {
        public int Rayon;

        public override double Aire => Rayon*Math.PI;

        public override double perimetre => 2*Math.PI*Rayon;

        public override string ToString()
        {
            return $"Cercle de rayon {Rayon}"+ Environment.NewLine+ base.ToString();
        }
    }
}
