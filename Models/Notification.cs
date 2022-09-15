using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PolyFix.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PolyFix.Models
{
    public class Notification
    {
        public int id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field is required")]
        public string FromUserId { get; set; }
        public string ToUserId { get; set; }

        public string FromUserName { get; set; }
        public string ToUserName { get; set; }

        public string NotiType { get; set; }
        public string NotiHeader { get; set; }
        [Column(TypeName = "varchar(500)")]
        public string NotiBody { get; set; }
        public string NotiMessage { get; set; }
        public string Url { get; set; }
        
        
        public DateTime DateCreated { get; set; }
        public bool isRead { get; set; }
    }
}
