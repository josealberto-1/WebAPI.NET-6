using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NetCorePlantillas.Models
{


    public class Plantilla
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Contenido { get; set; }
        public string Tipo { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

      
    }


}