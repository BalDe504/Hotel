using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Uslugi
    {
        public Uslugi()
        {
            WykupioneUslugis = new HashSet<WykupioneUslugi>();
        }

        public int IdUslugi { get; set; }
        public string Nazwa { get; set; } = null!;
        public int Cena { get; set; }

        public virtual ICollection<WykupioneUslugi> WykupioneUslugis { get; set; }
    }
}
