﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GroupFinder.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GROUP_FINDEREntities : DbContext
    {
        public GROUP_FINDEREntities()
            : base("name=GROUP_FINDEREntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassMateFood> ClassMateFoods { get; set; }
        public virtual DbSet<ClassMate> ClassMates { get; set; }
        public virtual DbSet<ClassMateVacation> ClassMateVacations { get; set; }
        public virtual DbSet<Food> Foods { get; set; }
        public virtual DbSet<IdealSaturdayClassMate> IdealSaturdayClassMates { get; set; }
        public virtual DbSet<IdealSaturday> IdealSaturdays { get; set; }
        public virtual DbSet<SongGenre> SongGenres { get; set; }
        public virtual DbSet<Vacation> Vacations { get; set; }

        public System.Data.Entity.DbSet<GroupFinder.Models.Questions> Questions { get; set; }
    }
}
