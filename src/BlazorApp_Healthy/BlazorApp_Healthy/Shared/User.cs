using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp_Healthy.Shared
{
    public class User : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public string? FullName { get; set; }
        public virtual ICollection<Recipe> RecipesAuthor { get; set; } = new HashSet<Recipe>();
        public virtual ICollection<Recipe> RecipesClient { get; set; } = new HashSet<Recipe>();
    }
}
