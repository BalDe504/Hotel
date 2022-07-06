using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Klienci
    {
        public Klienci()
        {
            Pobyties = new HashSet<Pobyty>();
            WykupioneUslugis = new HashSet<WykupioneUslugi>();
        }

        public int IdKlienta { get; set; }
        public string Imie { get; set; } = null!;
        public string Nazwisko { get; set; } = null!;
        public string Telefon { get; set; } = null!;

        public virtual ICollection<Pobyty> Pobyties { get; set; }
        public virtual ICollection<WykupioneUslugi> WykupioneUslugis { get; set; }


    }
}
