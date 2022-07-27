using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_Core6_Api.Models
{
    public class SuperHero
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }
        
        [StringLength(50)]
        public String? FirstName { get; set; }

          [StringLength(50)]
        public string? LastName { get; set; }

          [StringLength(50)]
        public string? Place { get; set; }
    }
}