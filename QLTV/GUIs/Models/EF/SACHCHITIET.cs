namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SACHCHITIET")]
    public partial class SACHCHITIET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SACHCHITIET()
        {
            MUONTRA = new HashSet<MUONTRA>();
        }

        [Key]
        public int MaCT { get; set; }

        public int MaSach { get; set; }

        [StringLength(100)]
        public string Tinhtrang { get; set; }

        public DateTime? Ngay_nhap { get; set; }

        public int? NamXb { get; set; }

        [StringLength(20)]
        public string MaCode { get; set; }
        public bool? Trangthai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MUONTRA> MUONTRA { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
