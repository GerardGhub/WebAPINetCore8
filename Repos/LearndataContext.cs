using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPINetCore8.Repos.Models;

namespace WebAPINetCore8.Repos;

public partial class LearndataContext : DbContext
{
    public LearndataContext()
    {
    }

    public LearndataContext(DbContextOptions<LearndataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCustomer> TblCustomers { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblProductimage> TblProductimages { get; set; }

    public virtual DbSet<TblRefreshtoken> TblRefreshtokens { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LPE-0069\\SQLEXPRESS2014;Database=test_db;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
