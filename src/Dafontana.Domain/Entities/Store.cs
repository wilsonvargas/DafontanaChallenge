using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Dafontana.Domain.Entities
{
    [Table("Local")]
    public partial class Store
    {
        public Store()
        {
            Sale = new HashSet<Sale>();
        }

        [Key]
        [Column("ID_Local")]
        public long Id { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Nombre")]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        [Column("Direccion")]
        public string Address { get; set; }

        [InverseProperty("Store")]
        public virtual ICollection<Sale> Sale { get; set; }
    }
}
