using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain.Entities
{
    [Table("VentaDetalle")]
    public partial class DetailSale
    {
        [Key]
        [Column("ID_VentaDetalle")]
        public long Id { get; set; }

        [Column("ID_Venta")]
        public long SaleId { get; set; }

        [Column("Precio_Unitario")]
        public int UnitPrice { get; set; }

        [Column("Cantidad")]
        public int Amount { get; set; }

        [Column("TotalLinea")]
        public int Total { get; set; }

        [Column("ID_Producto")]
        public long ProductId { get; set; }

        [ForeignKey(nameof(ProductId))]
        [InverseProperty(nameof(Entities.Product.DetailSale))]
        public virtual Product Product { get; set; }

        [ForeignKey(nameof(SaleId))]
        [InverseProperty(nameof(Entities.Sale.DetailSale))]
        public virtual Sale Sale { get; set; }
    }
}
