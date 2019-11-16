using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TheGym_2.Models
{
    [Serializable]
    [KnownType(typeof(List<User>))]
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}