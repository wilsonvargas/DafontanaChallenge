using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain.Entities
{
    [Table("Marca")]
    public partial class Trademark
    {
        public Trademark()
        {
            Producto = new HashSet<Product>();
        }

        [Key]
        [Column("ID_Marca")]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Nombre")]
        public string Name { get; set; }

        [InverseProperty("Trademark")]
        public virtual ICollection<Product> Producto { get; set; }
    }
}
