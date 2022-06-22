using Lab5.Pattern3.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Pattern3.ConcreteMaterials
{
    public class Newspaper : PrintedMaterial
    {
        public string EditorName { get; set; }

        public override string ToString()
        {
            return $"\tNewspaper Name: {Name}, Editor Name: {EditorName}";
        }
    }
}
