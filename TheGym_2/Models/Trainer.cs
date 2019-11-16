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
    [KnownType(typeof(List<Specialization>))]
    [KnownType(typeof(List<StatusTrainer>))]
    [KnownType(typeof(List<TrainerSchedule>))]
    public class Trainer
    {
        public int Id { get; set; }
        [Required]
        public DateTime StartWorkDay { get; set; }
        [Required]
        public DateTime EndtWorkDay { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required]
        public int SpecializationId { get; set; }
        public virtual Specialization Specialization { get; set; }

        [Required]
        public int StatusTrainerId { get; set; }
        public virtual StatusTrainer StatusTrainer { get; set; }

        public virtual List<TrainerSchedule> TrainerSchedules { get; set; }
    }
}