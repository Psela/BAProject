﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class BAProjectEntities : DbContext
    {
        public BAProjectEntities()
            : base("name=BAProjectEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<cours> courses { get; set; }
        public virtual DbSet<grades_database> grades_database { get; set; }
        public virtual DbSet<type_of_users> type_of_users { get; set; }
        public virtual DbSet<user> users { get; set; }
    }
}
