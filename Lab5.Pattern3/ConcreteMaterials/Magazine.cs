using Lab5.Pattern3.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.ConcreteMaterials
{
    public class Magazine: PrintedMaterial
    {
        public string CompanyName { get; set; }

        public override string ToString()
        {
            return $"\tMagazine Name: {Name}, Company Name: {CompanyName}";
        }
    }
}
