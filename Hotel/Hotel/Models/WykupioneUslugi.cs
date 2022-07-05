using System;
using System.Collections.Generic;

namespace Hotel.Models
{
    public partial class WykupioneUslugi
    {
        public int Id { get; set; }
        public int IdKlienta { get; set; }
        public int IdUslugi { get; set; }

        public virtual Klienci IdKlientaNavigation { get; set; } = null!;
        public virtual Uslugi IdUslugiNavigation { get; set; } = null!;
    }
}
