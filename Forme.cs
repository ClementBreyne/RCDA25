using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPModule2
{
    public abstract class Forme
    {
       public abstract double Aire { get; }
        public abstract double perimetre { get; }
        public override string ToString()
        {
            return $"Aire = {Aire}" + Environment.NewLine + $"Perimetre = {perimetre}" + Environment.NewLine;
        }

    }
}
