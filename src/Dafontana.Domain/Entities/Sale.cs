using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain.Entities
{
    [Table("Venta")]
    public partial class Sale
    {
        public Sale()
        {
            DetailSale = new HashSet<DetailSale>();
        }

        [Key]
        [Column("ID_Venta")]
        public long Id { get; set; }

        public int Total { get; set; }
        [Column("Fecha", TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column("ID_Local")]
        public long LocalId { get; set; }

        [ForeignKey(nameof(LocalId))]
        [InverseProperty(nameof(Entities.Store.Sale))]
        public virtual Store Store { get; set; }
        [InverseProperty("Sale")]
        public virtual ICollection<DetailSale> DetailSale { get; set; }
    }
}
