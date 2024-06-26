﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BlazorApp_Healthy.Shared
{
    public class Category : IEntity<Guid>
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string TitleCategory { get; set; }



        public virtual ICollection<Recipe> Recipes { get; set; } = new HashSet<Recipe>();
    }
}
