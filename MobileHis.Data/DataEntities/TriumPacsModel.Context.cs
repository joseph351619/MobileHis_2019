﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MobileHis.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class pacs_serverEntities : DbContext
    {
        public pacs_serverEntities()
            : base("name=pacs_serverEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<dicom_detail> dicom_detail { get; set; }
        public virtual DbSet<scheduled_action_item_code> scheduled_action_item_code { get; set; }
        public virtual DbSet<worklist> worklist { get; set; }
    }
}
