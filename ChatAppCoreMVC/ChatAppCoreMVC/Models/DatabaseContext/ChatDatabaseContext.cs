using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ChatAppCoreMVC.Models.DatabaseContext
{
    public partial class ChatDatabaseContext : DbContext
    {
        public ChatDatabaseContext()
        {
        }

        public ChatDatabaseContext(DbContextOptions<ChatDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BelongsTo> BelongsTo { get; set; }
        public virtual DbSet<Friendship> Friendship { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<GroupMessage> GroupMessage { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=ChatDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BelongsTo>(entity =>
            {
                entity.HasKey(e => new { e.IdUser, e.IdGroup })
                    .HasName("PK__BelongsT__FE5869F7D1DFB5E6");

                entity.Property(e => e.IdUser).HasColumnName("Id_user");

                entity.Property(e => e.IdGroup).HasColumnName("Id_group");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.BelongsTo)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BelongsTo__Id_gr__398D8EEE");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.BelongsTo)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BelongsTo__Id_us__37A5467C");
            });

            modelBuilder.Entity<Friendship>(entity =>
            {
                entity.HasKey(e => e.IdFriendship)
                    .HasName("PK__Friendsh__54DFD09EA30ED9CD");

                entity.HasIndex(e => e.IdFriendship)
                    .HasName("UQ__Friendsh__54DFD09F5662A086")
                    .IsUnique();

                entity.Property(e => e.IdFriendship).HasColumnName("Id_friendship");

                entity.Property(e => e.IdUser1).HasColumnName("Id_user1");

                entity.Property(e => e.IdUser2).HasColumnName("Id_user2");

                entity.HasOne(d => d.IdUser1Navigation)
                    .WithMany(p => p.FriendshipIdUser1Navigation)
                    .HasForeignKey(d => d.IdUser1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Friendshi__Id_us__34C8D9D1");

                entity.HasOne(d => d.IdUser2Navigation)
                    .WithMany(p => p.FriendshipIdUser2Navigation)
                    .HasForeignKey(d => d.IdUser2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Friendshi__Id_us__35BCFE0A");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.IdGroup)
                    .HasName("PK__Group__85F9BBF55975E9A5");

                entity.HasIndex(e => e.IdGroup)
                    .HasName("UQ__Group__85F9BBF46B86ECC8")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("UQ__Group__737584F676B95D8F")
                    .IsUnique();

                entity.Property(e => e.IdGroup).HasColumnName("Id_group");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<GroupMessage>(entity =>
            {
                entity.HasKey(e => e.IdGroupMessage)
                    .HasName("PK__GroupMes__5C5A93A4CD365CB8");

                entity.HasIndex(e => e.IdGroupMessage)
                    .HasName("UQ__GroupMes__5C5A93A58CC3991A")
                    .IsUnique();

                entity.Property(e => e.IdGroupMessage).HasColumnName("Id_groupMessage");

                entity.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("text");

                entity.Property(e => e.IdGroup).HasColumnName("Id_group");

                entity.Property(e => e.IdUserFrom).HasColumnName("Id_userFrom");

                entity.HasOne(d => d.IdGroupNavigation)
                    .WithMany(p => p.GroupMessage)
                    .HasForeignKey(d => d.IdGroup)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupMess__Id_gr__3A81B327");

                entity.HasOne(d => d.IdUserFromNavigation)
                    .WithMany(p => p.GroupMessage)
                    .HasForeignKey(d => d.IdUserFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GroupMess__Id_us__38996AB5");
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage)
                    .HasName("PK__Message__0A1524C0D5DB4260");

                entity.HasIndex(e => e.IdMessage)
                    .HasName("UQ__Message__0A1524C19BE106FB")
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
                    .HasConstraintName("FK__Message__Id_user__33D4B598");

                entity.HasOne(d => d.IdUserToNavigation)
                    .WithMany(p => p.MessageIdUserToNavigation)
                    .HasForeignKey(d => d.IdUserTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Message__Id_user__36B12243");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__User__B607F2482F7AAD3F");

                entity.HasIndex(e => e.IdUser)
                    .HasName("UQ__User__B607F249F05E8D02")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("UQ__User__536C85E4563F614E")
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
