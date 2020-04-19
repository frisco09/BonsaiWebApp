using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BonsaiWebApp.Models
{
    public class Category : EntityBase
    {

        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Deber indicar un nombre de categoria")]
        [StringLength(75, MinimumLength = 5, 
        ErrorMessage = "El nombre debe tener mas de 5 o al menos 50 caracteres")]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 25,
        ErrorMessage = "La descripcion debe tener mas de 25 o al menos 250 caracteres")]
        public string Description { get; set; }

        public bool Status { get; set; }

        public virtual ICollection<Bonsai> Bonsais { get; set; }

        public Category()
        {
            this.CreateAt = DateTime.Now;
        }
    }
}
