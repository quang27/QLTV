namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NHANVIEN")]
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            MUONTRA = new HashSet<MUONTRA>();
            MUONTRA1 = new HashSet<MUONTRA>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [StringLength(10)]
        public string Pass { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(11)]
        public string SDT { get; set; }

        [StringLength(250)]
        public string Anh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONTRA> MUONTRA { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONTRA> MUONTRA1 { get; set; }
    }
}
