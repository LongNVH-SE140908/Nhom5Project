﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectNhom5
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class QLSVienEntities : DbContext
    {
        public QLSVienEntities()
            : base("name=QLSVienEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DKIEN> DKIENs { get; set; }
        public virtual DbSet<HPHAN> HPHANs { get; set; }
        public virtual DbSet<KHOA> KHOAs { get; set; }
        public virtual DbSet<KQUA> KQUAs { get; set; }
        public virtual DbSet<MHOC> MHOCs { get; set; }
        public virtual DbSet<SVIEN> SVIENs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
    }
}