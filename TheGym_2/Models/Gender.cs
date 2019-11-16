﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TheGym_2.Models
{
    [Serializable]
    [KnownType(typeof(List<User>))]

    public class Gender
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public virtual List<User> Users { get; set; }
    }
}