using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Pokoje
    {
        public Pokoje()
        {
            Pobyties = new HashSet<Pobyty>();
        }

        public int IdPokoju { get; set; }
        public int NumerPokoju { get; set; }
        public int IloscOsob { get; set; }
        public double Cena { get; set; }

        public virtual ICollection<Pobyty> Pobyties { get; set; }
    }
}
