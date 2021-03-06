// <auto-generated />
using System;
using Freelance_bot;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Freelance_bot.Migrations
{
    [DbContext(typeof(Freelance_botContext))]
    partial class Freelance_botContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Russian_Ukraine.1251")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Freelance_bot.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<string>("CardCountry")
                        .HasColumnType("text")
                        .HasColumnName("card_country");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int?>("DateCard")
                        .HasColumnType("integer")
                        .HasColumnName("date_card");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("PriorityCurrency")
                        .HasColumnType("text")
                        .HasColumnName("priority_currency");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.HasKey("CardNumber")
                        .HasName("pk_card");

                    b.ToTable("card");
                });

            modelBuilder.Entity("Freelance_bot.Chat", b =>
                {
                    b.Property<long>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_id");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("MediaMessageUrl")
                        .HasColumnType("text")
                        .HasColumnName("media_message_url");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("status")
                        .HasDefaultValueSql("1");

                    b.Property<long?>("TakenOrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("taken_order_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("ChatId")
                        .HasName("pk_chat_id");

                    b.ToTable("chat");
                });

            modelBuilder.Entity("Freelance_bot.ErrorTransaction", b =>
                {
                    b.Property<int>("ErrorCode")
                        .HasColumnType("integer")
                        .HasColumnName("error_code");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("DescriptionError")
                        .HasColumnType("text")
                        .HasColumnName("description_error");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("ErrorCode")
                        .HasName("pk_error_code");

                    b.ToTable("error_transaction");
                });

            modelBuilder.Entity("Freelance_bot.Order", b =>
                {
                    b.Property<long>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<int?>("BetCost")
                        .HasColumnType("integer")
                        .HasColumnName("bet_cost");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("category");

                    b.Property<long?>("ChatId")
                        .HasColumnType("bigint")
                        .HasColumnName("chat_id");

                    b.Property<int?>("CostValue")
                        .HasColumnType("integer")
                        .HasColumnName("cost_value");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long>("CreatorId")
                        .HasColumnType("bigint")
                        .HasColumnName("creator_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("MediaMessageUrl")
                        .HasColumnType("text")
                        .HasColumnName("media_message_url");

                    b.Property<string>("Status")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)")
                        .HasColumnName("status")
                        .HasDefaultValueSql("1");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<long?>("WorkerId")
                        .HasColumnType("bigint")
                        .HasColumnName("worker_id");

                    b.HasKey("OrderId");

                    b.HasIndex("ChatId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("Freelance_bot.Orderstransaction", b =>
                {
                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<char?>("StatusOfTr")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("status_of_tr");

                    b.Property<char?>("TypeOfTr")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("type_of_tr");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.ToTable("orderstransactions");
                });

            modelBuilder.Entity("Freelance_bot.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_id");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long?>("OrderId")
                        .HasColumnType("bigint")
                        .HasColumnName("order_id");

                    b.Property<char>("Status")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("status");

                    b.Property<char>("TypeOfTransaction")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("type_of_transaction");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("TransactionId")
                        .HasName("pk_transaction_id");

                    b.HasIndex("OrderId");

                    b.ToTable("transactions");
                });

            modelBuilder.Entity("Freelance_bot.Transactionlist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("card_number");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_id");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("TransactionId");

                    b.ToTable("transactionlist");
                });

            modelBuilder.Entity("Freelance_bot.TransactionsView", b =>
                {
                    b.Property<decimal?>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<decimal?>("Balance")
                        .HasColumnType("numeric")
                        .HasColumnName("balance");

                    b.Property<char?>("Status")
                        .HasMaxLength(1)
                        .HasColumnType("character(1)")
                        .HasColumnName("status");

                    b.Property<int?>("TransactionId")
                        .HasColumnType("integer")
                        .HasColumnName("transaction_id");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<string>("UserName")
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.ToTable("transactions_view");
                });

            modelBuilder.Entity("Freelance_bot.User", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint")
                        .HasColumnName("user_id");

                    b.Property<decimal>("Balance")
                        .HasColumnType("numeric")
                        .HasColumnName("balance");

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Rating")
                        .HasColumnType("numeric")
                        .HasColumnName("rating");

                    b.Property<DateTime?>("UpdatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.HasKey("UserId")
                        .HasName("pk_patient");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Freelance_bot.Order", b =>
                {
                    b.HasOne("Freelance_bot.Chat", "Chat")
                        .WithMany("Orders")
                        .HasForeignKey("ChatId")
                        .HasConstraintName("fk_chat_id");

                    b.Navigation("Chat");
                });

            modelBuilder.Entity("Freelance_bot.Transaction", b =>
                {
                    b.HasOne("Freelance_bot.Order", "Order")
                        .WithMany("Transactions")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("fk_order_id");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Freelance_bot.Transactionlist", b =>
                {
                    b.HasOne("Freelance_bot.Transaction", "Transaction")
                        .WithMany("Transactionlists")
                        .HasForeignKey("TransactionId")
                        .HasConstraintName("fk_transaction_id");

                    b.Navigation("Transaction");
                });

            modelBuilder.Entity("Freelance_bot.Chat", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Freelance_bot.Order", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("Freelance_bot.Transaction", b =>
                {
                    b.Navigation("Transactionlists");
                });
#pragma warning restore 612, 618
        }
    }
}
