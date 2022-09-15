using Microsoft.AspNetCore.Http;
using PolyFix.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Poly.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage ="This field is Required")]
        [Display(Name = "Project Name")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        [Column(TypeName = "varchar(250)")]
        public string Location { get; set; }
        public IList<Tsk> Tsks { get; set; }
        [Display(Name = "Project Picture")]
        public string ProjectImage { get; set; }

        public virtual ICollection<UserProject> UserProject { get; set; }

        [Required(ErrorMessage = "This field is Required")]
        [Display(Name = "Project Name")]
        public Guid UserCreated { get; set; }

        public string UserCreatedName { get; set; }

        public string UsersAssigned { get; set; }

        public bool isArchived { get; set; }
    }


    public class UserProject
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public PolyFixAppUser User { get; set; }


        [Key]
        [Column(Order = 2)]
        public int ProjectId { get; set; }      
        public Project Project { get; set; }

        

    
    }






}
