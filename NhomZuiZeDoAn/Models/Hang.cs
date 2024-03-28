namespace NhomZuiZeDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Hang")]
    public partial class Hang
    {
        
        public Hang()
        {
            DongHoes = new HashSet<DongHo>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaHang { get; set; }

        [StringLength(50)]
        public string TenHang { get; set; }

        public virtual ICollection<DongHo> DongHoes { get; set; }
    }
}
