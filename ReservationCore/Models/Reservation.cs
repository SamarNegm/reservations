// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationCore.Models
{
    public partial class Reservation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        public int Adults { get; set; }
        public int? Child { get; set; }
        [Required]

        public int RoomId { get; set; }
        [Required]

        public int MealId { get; set; }
        [Required]

        public int SeasonId { get; set; }
        [Column(TypeName = "date")]
        public DateTime Checkin { get; set; }
        [Column(TypeName = "date")]
        public DateTime Checkout { get; set; }

        [ForeignKey("MealId")]
        [InverseProperty("Reservation")]
        public virtual MealPlan Meal { get; set; }
        [ForeignKey("RoomId")]
        [InverseProperty("Reservation")]
        public virtual RoomType Room { get; set; }
        [ForeignKey("SeasonId")]
        [InverseProperty("Reservation")]
        public virtual Season Season { get; set; }
    }
}