using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Newtonsoft.Json;


#nullable disable

namespace Freelance_bot
{
    public partial class Freelance_botContext : DbContext
    {
        public Freelance_botContext()
        {
        }

        public Freelance_botContext(DbContextOptions<Freelance_botContext> options)
            : base(options)
        {
        }


        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<ErrorTransaction> ErrorTransactions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Orderstransaction> Orderstransactions { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Transactionlist> Transactionlists { get; set; }
        public virtual DbSet<TransactionsView> TransactionsViews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public class Test_Function
        {
            public int user_id { get; set; }

        }

        public virtual DbSet<Test_Function> Test_Func { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var text = File.ReadAllText("configDB.json");
            var config = JsonConvert.DeserializeObject<Dictionary<string, string>>(text);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql(config["DefaultConnection"]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.HasAnnotation("Relational:Collation", "Russian_Ukraine.1251");


            modelBuilder.Entity<Test_Function>(
            eb =>
            {
                eb.HasNoKey();
            });

            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.CardNumber)
                    .HasName("pk_card");

                entity.ToTable("card");

                entity.Property(e => e.CardNumber).HasColumnName("card_number");

                entity.Property(e => e.CardCountry).HasColumnName("card_country");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DateCard).HasColumnName("date_card");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.PriorityCurrency).HasColumnName("priority_currency");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.ChatId)
                    .HasName("pk_chat_id");

                entity.ToTable("chat");

                entity.Property(e => e.ChatId)
                    .ValueGeneratedNever()
                    .HasColumnName("chat_id");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.MediaMessageUrl).HasColumnName("media_message_url");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.TakenOrderId).HasColumnName("taken_order_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<ErrorTransaction>(entity =>
            {
                entity.HasKey(e => e.ErrorCode)
                    .HasName("pk_error_code");

                entity.ToTable("error_transaction");

                entity.Property(e => e.ErrorCode)
                    .ValueGeneratedNever()
                    .HasColumnName("error_code");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.DescriptionError).HasColumnName("description_error");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedNever()
                    .HasColumnName("order_id");

                entity.Property(e => e.BetCost).HasColumnName("bet_cost");

                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasColumnName("category");

                entity.Property(e => e.ChatId).HasColumnName("chat_id");

                entity.Property(e => e.CostValue).HasColumnName("cost_value");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.CreatorId).HasColumnName("creator_id");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.MediaMessageUrl).HasColumnName("media_message_url");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .HasColumnName("status")
                    .HasDefaultValueSql("1");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.WorkerId).HasColumnName("worker_id");

                entity.HasOne(d => d.Chat)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ChatId)
                    .HasConstraintName("fk_chat_id");
            });

            modelBuilder.Entity<Orderstransaction>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("orderstransactions");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.StatusOfTr)
                    .HasMaxLength(1)
                    .HasColumnName("status_of_tr");

                entity.Property(e => e.TypeOfTr)
                    .HasMaxLength(1)
                    .HasColumnName("type_of_tr");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.TransactionId)
                    .HasName("pk_transaction_id");

                entity.ToTable("transactions");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("transaction_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status");

                entity.Property(e => e.TypeOfTransaction)
                    .HasMaxLength(1)
                    .HasColumnName("type_of_transaction");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("fk_order_id");
            });

            modelBuilder.Entity<Transactionlist>(entity =>
            {
                entity.ToTable("transactionlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasColumnName("card_number");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.Transaction)
                    .WithMany(p => p.Transactionlists)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("fk_transaction_id");
            });

            modelBuilder.Entity<TransactionsView>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("transactions_view");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status");

                entity.Property(e => e.TransactionId).HasColumnName("transaction_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserName).HasColumnName("user_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("pk_patient");

                entity.ToTable("users");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("user_id");

                entity.Property(e => e.Balance).HasColumnName("balance");

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("created_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.FullName).HasColumnName("full_name");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updated_at")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("user_name");
            });



            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
