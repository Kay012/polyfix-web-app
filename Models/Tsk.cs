using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PolyFix.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Poly.Models
{
    public class Tsk
    {
        [Key]
        public int TskId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field is required")]
        public string Name { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string Description { get; set; }
        public DateTime DateDue { get; set; }
        
        public bool isComplete { get; set; }
       
        public bool Form1 { get; set; }
        public bool Form2 { get; set; }
        public bool Form3 { get; set; }
       
        [Column(TypeName = "varchar(800)")]
        public string Comment { get; set; }

        public Guid UserCreated { get; set; }

        public string UserCreatedName { get; set; }

        public string UsersAssigned { get; set; }

        [Required]
        public int ProjectId { get; set; }
        public Project ProjectRef { get; set; }

        public virtual ICollection<UserTask> UserTask { get; set; }


    }

    public class UserTask
    {
        [Key]
        [Column(Order = 1)]
        public string UserId { get; set; }
        public PolyFixAppUser User { get; set; }


        [Key]
        [Column(Order = 2)]
        public int TskId { get; set; }
        public Tsk Tsk { get; set; }


    }


}
