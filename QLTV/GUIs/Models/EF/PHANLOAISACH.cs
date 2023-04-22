namespace GUIs.Models.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PHANLOAISACH")]
    public partial class PHANLOAISACH
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string TenPhanLoai { get; set; }

        public virtual SACH SACH { get; set; }
    }
}
