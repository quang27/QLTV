namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACH")]
    public partial class SACH
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACH()
        {
            SACHCHITIET = new HashSet<SACHCHITIET>();
            TACGIASACH = new HashSet<TACGIASACH>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [StringLength(150)]
        public string TenSach { get; set; }

        public int? NXBId { get; set; }

        public int? PhanLoaiId { get; set; }

        public int? GiaTien { get; set; }

        [StringLength(350)]
        public string AnhBia { get; set; }

        public string Tomtat { get; set; }

        [Column(TypeName = "text")]
        public string Noi_dung { get; set; }

        public virtual NHAXUATBAN NHAXUATBAN { get; set; }

        public virtual PHANLOAISACH PHANLOAISACH { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SACHCHITIET> SACHCHITIET { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TACGIASACH> TACGIASACH { get; set; }
    }
}
