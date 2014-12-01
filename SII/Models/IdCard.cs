using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SII.Models
{
    [Table("CNE")]
    public class IdCard
    {
        [Key]
        [Column("IDENTIDAD", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Id { get; set; }

        [Column("PNOMBRE", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String FirstName { get; set; }

        [Column("SNOMBRE", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String MiddleName { get; set; }

        [Column("PAPELLIDO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String FirstLastName { get; set; }

        [Column("SAPELLIDO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String SecondLastName { get; set; }

        [Column("SEXO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Gender { get; set; }

        [Column("DEPTO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Province { get; set; }

        [Column("MUNI", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Town { get; set; }

        [Column("POBLADO", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Populated { get; set; }

        [Column("AREA", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Area { get; set; }

        [Column("SECTOR", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Sector { get; set; }

        [Column("MESA", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Table { get; set; }

        [Column("LINEA", TypeName = "VARCHAR")]
        [StringLength(50)]
        public String Line { get; set; }
    }
}