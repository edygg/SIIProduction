using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SII.Models
{
    [Table("barreras")]
    public class Barrier : BaseModel
    {
        [Column("barrera")]
        [StringLength(16, ErrorMessage = "Ingrese un nombre de máximo 16 caracteres.", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s]{3,16}$", ErrorMessage = "Ingrese un nombre que contenga de 3 a 16 caracteres letras o números.")]
        public String Name { get; set; }

        [Column("descripcion")]
        [StringLength(128, ErrorMessage = "Ingrese una descripción de máximo 128 caracteres.", MinimumLength = 5)]
        [Display(Name = "Descripción")]
        [Required]
        [RegularExpression(@"^[A-za-z0-9\s]{5,128}$", ErrorMessage = "Ingrese una descripción que contenga de 5 a 128 caracteres letras o números.")]
        public String Description { get; set; }

        [Column("ip")]
        [StringLength(15, ErrorMessage = "La dirección IP ingresada en inválida.", MinimumLength = 7)]
        [Display(Name = "Dirección IP")]
        [Required]
        [RegularExpression(@"^((25[0-5])|(2[0-4][0-9])|([01]?[0-9][0-9]?))[\.]((25[0-5])|(2[0-4][0-9])|([01]?[0-9][0-9]?))[\.]((25[0-5])|(2[0-4][0-9])|([01]?[0-9][0-9]?))[\.]((25[0-5])|(2[0-4][0-9])|([01]?[0-9][0-9]?))$", ErrorMessage = "La dirección IP ingresada en inválida.")]
        public String IpAddress { get; set; }

        [Column("puerto")]
        [Required]
        [Range(1, 65535, ErrorMessage = "Ingrese un número entre 1 y 65535.")]
        [Display(Name = "Puerto")]
        public int Port { get; set; }

        [Column("activo")]
        [Display(Name = "Activo")]
        public bool Activate { get; set; }

        [Display(Name = "Campus")]
        public int CampusId { get; set; }

        [Column("AutorizaDocentes")]
        [Display(Name = "Permite docentes")]
        public bool AllowTeachers { get; set; }

        [Column("AutorizaAdministrativos")]
        [Display(Name = "Permite funcionarios administrativos")]
        public bool AllowAdministrative { get; set; }

        [Column("AutorizaAlumnos")]
        [Display(Name = "Permite alumnos")]
        public bool AllowStudents { get; set; }
    }
}