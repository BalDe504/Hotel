using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class Pobyty
    {
        public int Id { get; set; }
        public int IdKlienta { get; set; }
        public int IdPokoju { get; set; }
        public DateTime DataPrzyjazdu { get; set; }
        public bool ZakonczonyPobyt { get; set; }

        public virtual Klienci IdKlientaNavigation { get; set; } = null!;
        public virtual Pokoje IdPokojuNavigation { get; set; } = null!;
    }
}
