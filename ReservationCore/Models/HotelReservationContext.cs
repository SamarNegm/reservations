﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ReservationCore.Models
{
    public partial class HotelReservationContext : DbContext
    {
        public HotelReservationContext()
        {
        }

        public HotelReservationContext(DbContextOptions<HotelReservationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MealPlan> MealPlan { get; set; }
        public virtual DbSet<Reservation> Reservation { get; set; }
        public virtual DbSet<RoomType> RoomType { get; set; }
        public virtual DbSet<SeaonsRoomPrice> SeaonsRoomPrice { get; set; }
        public virtual DbSet<Season> Season { get; set; }
        public virtual DbSet<SeasonsMealPrice> SeasonsMealPrice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(entity =>
            {
                entity.HasOne(d => d.Meal)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.MealId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_MealPlan");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_RoomType");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.Reservation)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reservation_Season");
            });

            modelBuilder.Entity<SeaonsRoomPrice>(entity =>
            {
                entity.HasKey(e => new { e.RoomId, e.SeasonId });

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.SeaonsRoomPrice)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeaonsRoomPrice_RoomType");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SeaonsRoomPrice)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeaonsRoomPrice_Season");
            });

            modelBuilder.Entity<SeasonsMealPrice>(entity =>
            {
                entity.HasKey(e => new { e.MealPlanId, e.SeasonId });

                entity.HasOne(d => d.MealPlan)
                    .WithMany(p => p.SeasonsMealPrice)
                    .HasForeignKey(d => d.MealPlanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonsMealPrice_MealPlan");

                entity.HasOne(d => d.Season)
                    .WithMany(p => p.SeasonsMealPrice)
                    .HasForeignKey(d => d.SeasonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SeasonsMealPrice_Season");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}