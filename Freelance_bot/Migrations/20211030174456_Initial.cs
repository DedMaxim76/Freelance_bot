using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Freelance_bot.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "card",
                columns: table => new
                {
                    card_number = table.Column<string>(type: "text", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    date_card = table.Column<int>(type: "integer", nullable: true),
                    priority_currency = table.Column<string>(type: "text", nullable: true),
                    card_country = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_card", x => x.card_number);
                });

            migrationBuilder.CreateTable(
                name: "chat",
                columns: table => new
                {
                    chat_id = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    status = table.Column<int>(type: "integer", nullable: false, defaultValueSql: "1"),
                    media_message_url = table.Column<string>(type: "text", nullable: true),
                    taken_order_id = table.Column<long>(type: "bigint", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_chat_id", x => x.chat_id);
                });

            migrationBuilder.CreateTable(
                name: "error_transaction",
                columns: table => new
                {
                    error_code = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    description_error = table.Column<string>(type: "text", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_error_code", x => x.error_code);
                });

            migrationBuilder.CreateTable(
                name: "orderstransactions",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    type_of_tr = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true),
                    status_of_tr = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "transactions_view",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    user_name = table.Column<string>(type: "text", nullable: true),
                    balance = table.Column<decimal>(type: "numeric", nullable: true),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    status = table.Column<char>(type: "character(1)", maxLength: 1, nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<long>(type: "bigint", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    full_name = table.Column<string>(type: "text", nullable: true),
                    balance = table.Column<decimal>(type: "numeric", nullable: false),
                    rating = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_patient", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    creator_id = table.Column<long>(type: "bigint", nullable: false),
                    worker_id = table.Column<long>(type: "bigint", nullable: true),
                    chat_id = table.Column<long>(type: "bigint", nullable: true),
                    status = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false, defaultValueSql: "1"),
                    category = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    media_message_url = table.Column<string>(type: "text", nullable: true),
                    cost_value = table.Column<int>(type: "integer", nullable: true),
                    bet_cost = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.order_id);
                    table.ForeignKey(
                        name: "fk_chat_id",
                        column: x => x.chat_id,
                        principalTable: "chat",
                        principalColumn: "chat_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactions",
                columns: table => new
                {
                    transaction_id = table.Column<int>(type: "integer", nullable: false),
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type_of_transaction = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    status = table.Column<char>(type: "character(1)", maxLength: 1, nullable: false),
                    order_id = table.Column<long>(type: "bigint", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_transaction_id", x => x.transaction_id);
                    table.ForeignKey(
                        name: "fk_order_id",
                        column: x => x.order_id,
                        principalTable: "orders",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transactionlist",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    card_number = table.Column<string>(type: "text", nullable: false),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transactionlist", x => x.id);
                    table.ForeignKey(
                        name: "fk_transaction_id",
                        column: x => x.transaction_id,
                        principalTable: "transactions",
                        principalColumn: "transaction_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_orders_chat_id",
                table: "orders",
                column: "chat_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactionlist_transaction_id",
                table: "transactionlist",
                column: "transaction_id");

            migrationBuilder.CreateIndex(
                name: "IX_transactions_order_id",
                table: "transactions",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "card");

            migrationBuilder.DropTable(
                name: "error_transaction");

            migrationBuilder.DropTable(
                name: "orderstransactions");

            migrationBuilder.DropTable(
                name: "transactionlist");

            migrationBuilder.DropTable(
                name: "transactions_view");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "transactions");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "chat");
        }
    }
}
