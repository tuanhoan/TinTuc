namespace TinTuc.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Tintuc")]
    public partial class Tintuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTin { get; set; }

        [StringLength(200)]
        public string Tieudetin { get; set; }

        [Column(TypeName = "ntext")]
        public string Noidungtin { get; set; }

        public int? Maloai { get; set; }

        public virtual Theloaitin Theloaitin { get; set; }
    }
}
