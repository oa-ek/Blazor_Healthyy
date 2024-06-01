using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Healthy.Shared
{
    public class Recipe : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public string? Instructons { get; set; } = string.Empty;
        public string? ImagePath { get; set; } = "/img/recipes/no_photo.jpg";
     

        [NotMapped]
        public IFormFile? ImageFile { get; set; }


        [ForeignKey(nameof(CategoryId))]
        public Guid? CategoryId { get; set; }


        [ForeignKey(nameof(IngredientId))]
        public Guid? IngredientId { get; set; }

        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
    }
}
