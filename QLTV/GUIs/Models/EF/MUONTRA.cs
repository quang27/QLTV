namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("MUONTRA")]
    public partial class MUONTRA
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        public int? SVId { get; set; }

        public int? SachCTId { get; set; }

        public DateTime? NgayMuon { get; set; }

        public DateTime? NgayTra { get; set; }

        [StringLength(50)]
        public string TinhTrangMuon { get; set; }

        [StringLength(50)]
        public string TinhTrangTra { get; set; }

        public int? NVMuonId { get; set; }

        public int? NVTraId { get; set; }

        public bool? Baomat { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual NHANVIEN NHANVIEN1 { get; set; }

        public virtual SACHCHITIET SACHCHITIET { get; set; }

        public virtual SINHVIEN SINHVIEN { get; set; }
    }
}
