using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public class Triangle : Forme
    {
        public int A;
        public int B;
        public int C;
        private double P => (A + B + C) /2d;

        public override double Aire => Math.Sqrt(P*(P - A) * (P - B) * (P - C));

        public override double perimetre => A+B+C;

        public override string ToString()
        {
            return $"Je suis un triangle de côté A ={A}, B ={B}, C ={C}" +Environment.NewLine +  base.ToString();
        }



    }
}
