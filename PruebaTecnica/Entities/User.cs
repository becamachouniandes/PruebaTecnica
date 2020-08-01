using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PruebaTecnica.Entities
{
    public class UserModel
    {
        public int Id { get; set; }

        [DisplayName("Nombre")]
        [Required(ErrorMessage = "El nombre del usuario es requerida")]
        public string Name { get; set; }

        [DisplayName("Fecha de nacimiento")]
        [Required(ErrorMessage = "La fecha de cumpleaños es requerida")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [DisplayName("Genero")]
        [Required(ErrorMessage = "El genero es requerido")]
        public string Gender { get; set; }

        [DisplayName("Genero")]
        public string GenderName { get; set; }
    }


}
