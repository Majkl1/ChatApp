﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatAppCoreMVC.Models.DBContext
{
    public partial class ChatAppDBCervinkaContext : DbContext
    {
        public ChatAppDBCervinkaContext()
        {
        }

        public ChatAppDBCervinkaContext(DbContextOptions<ChatAppDBCervinkaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=147.230.21.34;Initial Catalog=ChatAppDBCervinka;User ID=student;Password=student");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Message__0A1524C0FDC7B060");

                entity.HasIndex(e => e.IdMessage)
                    .HasName("UQ__Message__0A1524C176BDDE17")
                    .IsUnique();

                entity.Property(e => e.IdMessage).HasColumnName("Id_message");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdUserFrom).HasColumnName("Id_userFrom");

                entity.Property(e => e.IdUserTo).HasColumnName("Id_userTo");

                entity.HasOne(d => d.IdUserFromNavigation)
                    .WithMany(p => p.MessageIdUserFromNavigation)
                    .HasForeignKey(d => d.IdUserFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Id_user__3C69FB99");

                entity.HasOne(d => d.IdUserToNavigation)
                    .WithMany(p => p.MessageIdUserToNavigation)
                    .HasForeignKey(d => d.IdUserTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Id_user__3D5E1FD2");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__B607F248D45880A2");

                entity.HasIndex(e => e.IdUser)
                    .HasName("UQ__User__B607F24945218627")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__User__536C85E40B84E26E")
                    .IsUnique();

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
