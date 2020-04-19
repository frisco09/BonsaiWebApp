
using System;
using System.ComponentModel.DataAnnotations;

namespace BonsaiWebApp.Models
{
    public class Bonsai : EntityBase
    {

        public int BonsaiId { get; set; }

        public string Code { get; set; }

        [StringLength(150, MinimumLength = 5,
        ErrorMessage = "El nombre debe tener mas de 5 o al menos 150 caracteres")]
        [Required(ErrorMessage = "Deber indicar un nombre de bonsai")]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 25,
        ErrorMessage = "La descripcion debe tener mas de 25 o al menos 250 caracteres")]
        public string Description { get; set; }

        [Required (ErrorMessage ="Deber seleccionar una categoria para el bonsai")]
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }


        public Bonsai()
        {
            this.CreateAt = DateTime.Now;
        }
    }
}
