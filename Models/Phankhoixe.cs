namespace WedBH.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phankhoixe")]
    public partial class Phankhoixe
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Phankhoixe()
        {
            Baohiems = new HashSet<Baohiem>();
        }

        [Key]
        [StringLength(10)]
        public string MAPK { get; set; }

        [Column("PHANKHOIXE")]
        [Required]
        [StringLength(70)]
        public string PHANKHOIXE1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Baohiem> Baohiems { get; set; }
    }
}
