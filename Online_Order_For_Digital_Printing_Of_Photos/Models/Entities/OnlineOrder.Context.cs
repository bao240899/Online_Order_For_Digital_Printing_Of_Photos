﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Online_Order_For_Digital_Printing_Of_Photos.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class OnlineOrderEntities : DbContext
    {
        public OnlineOrderEntities()
            : base("name=OnlineOrderEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Feedback> Feedback { get; set; }
        public virtual DbSet<OrderDetail> OrderDetail { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PhotoFormat> PhotoFormat { get; set; }
        public virtual DbSet<Photos> Photos { get; set; }
        public virtual DbSet<Price> Price { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Format> Format { get; set; }
    }
}