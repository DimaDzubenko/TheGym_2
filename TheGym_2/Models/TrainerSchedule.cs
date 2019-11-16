using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TheGym_2.Models
{
    [Serializable]
    [KnownType(typeof(List<Trainer>))]
    [KnownType(typeof(List<HallGym>))]

    public class TrainerSchedule
    {
        public int Id { get; set; }

        [Required]
        public DateTime StartWorkout { get; set; }
        [Required]
        public DateTime EndWorkout { get; set; }

        [Required]
        public int TrainerId { get; set; }
        public virtual Trainer Trainer { get; set; }

        [Required]
        public int HallGymId { get; set; }
        public virtual HallGym HallGym { get; set; }
    }
}