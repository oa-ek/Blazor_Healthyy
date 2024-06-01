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
       
    }
}
