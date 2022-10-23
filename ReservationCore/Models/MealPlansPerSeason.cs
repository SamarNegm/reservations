﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ReservationCore.Models
{
    [Table("meal_plans_per_season")]
    public partial class MealPlansPerSeason
    {
        [Key]
        [Column("meal_plan_id")]
        public int MealPlanId { get; set; }
        [Key]
        [Column("season_id")]
        public int SeasonId { get; set; }
        [Column("meal_price")]
        public double MealPrice { get; set; }

        [ForeignKey("MealPlanId")]
        [InverseProperty("MealPlansPerSeason")]
        public virtual MealPlans MealPlan { get; set; }
        [ForeignKey("SeasonId")]
        [InverseProperty("MealPlansPerSeason")]
        public virtual Season Season { get; set; }
    }
}