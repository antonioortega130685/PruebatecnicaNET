using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Cliente
    {
        //el id
        public int id {get;set;}

        //los campos requeridos
        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Apellido { get; set; }

        //al dni se le otorga un rango para que no pueda ser negativo, ni exceder de los 50 millones, que hasta ahora creo que no se ha llegado a ese número
        [Required]
        [RangeAttribute(0,50000000)]
        public int DNI { get; set; }

        //el correo electronico no es requerido, pero al ser ingresado, debe estar correcto, y esto se logra gracias al emailaddress
        [EmailAddress]
        public string Email { get; set; }
    }
}