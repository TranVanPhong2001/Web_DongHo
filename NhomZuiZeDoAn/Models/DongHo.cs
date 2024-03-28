namespace NhomZuiZeDoAn.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DongHo")]
    public partial class DongHo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Ten { get; set; }

        public int? Hang { get; set; }

        public decimal? Gia { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        [StringLength(50)]
        public string XuatXu { get; set; }

        [StringLength(50)]
        public string GioiTinh { get; set; }

        public virtual Hang Hangss { get; set; }
    }
}
