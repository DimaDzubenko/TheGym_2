using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TheGym_2.Models
{
    [Serializable]
    [KnownType(typeof(List<Gender>))]

    [KnownType(typeof(List<Trainer>))]
    [KnownType(typeof(List<Administrator>))]
    [KnownType(typeof(List<Client>))]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDay { get; set; }
        [Required]
        [StringLength(50)]
        public string Telephon { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(50)]
        public string Login { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }


        public virtual List<Trainer> Trainers { get; set; }
        public virtual List<Client> Clients { get; set; }
        public virtual List<Administrator> Administrators { get; set; }
    }
}