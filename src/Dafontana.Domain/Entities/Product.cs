using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain.Entities
{
    [Table("Producto")]
    public partial class Product
    {
        public Product()
        {
            DetailSale = new HashSet<DetailSale>();
        }

        [Key]
        [Column("ID_Producto")]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Codigo")]
        public string Code { get; set; }

        [Column("ID_Marca")]
        public long TrademarkId { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Modelo")]
        public string Model { get; set; }

        [Column("Costo_Unitario")]
        public int UnitCost { get; set; }

        [ForeignKey(nameof(TrademarkId))]
        [InverseProperty(nameof(Entities.Trademark.Producto))]
        public virtual Trademark Trademark { get; set; }

        [InverseProperty("Product")]
        public virtual ICollection<DetailSale> DetailSale { get; set; }
    }
}
