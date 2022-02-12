using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supervaga.Infra.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_document",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    file_name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    FileUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content_type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    file_size = table.Column<long>(type: "bigint", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_document", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    biography = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    provider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_ad",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    category = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    audience_gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2022, 2, 12, 7, 28, 26, 128, DateTimeKind.Local).AddTicks(9740)),
                    expires_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_freelance = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    salary_offer = table.Column<float>(type: "real", nullable: true),
                    user_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    application_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_ad", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_user_user_id",
                        column: x => x.user_id,
                        principalTable: "tb_user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_advantage",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ad_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_advantage", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_advantage_tb_ad_ad_id",
                        column: x => x.ad_id,
                        principalTable: "tb_ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_application",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    expires_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ad_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_application", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_application_ad_id_ad",
                        column: x => x.ad_id,
                        principalTable: "tb_ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_requirement",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ad_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    title = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_requirement", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_requirement_tb_ad_ad_id",
                        column: x => x.ad_id,
                        principalTable: "tb_ad",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tb_candidate",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    application_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_ad = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id_user = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    is_cv = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_candidate", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_candidate_tb_application_application_id",
                        column: x => x.application_id,
                        principalTable: "tb_application",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_ad_category",
                table: "tb_ad",
                column: "category");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ad_description",
                table: "tb_ad",
                column: "description");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ad_id",
                table: "tb_ad",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ad_title",
                table: "tb_ad",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_tb_ad_user_id",
                table: "tb_ad",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_advantage_ad_id",
                table: "tb_advantage",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_advantage_id",
                table: "tb_advantage",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_advantage_title",
                table: "tb_advantage",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_tb_application_ad_id",
                table: "tb_application",
                column: "ad_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tb_application_id",
                table: "tb_application",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_candidate_application_id",
                table: "tb_candidate",
                column: "application_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_candidate_id",
                table: "tb_candidate",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_candidate_id_user",
                table: "tb_candidate",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_tb_document_file_name",
                table: "tb_document",
                column: "file_name");

            migrationBuilder.CreateIndex(
                name: "IX_tb_document_id",
                table: "tb_document",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_requirement_ad_id",
                table: "tb_requirement",
                column: "ad_id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_requirement_id",
                table: "tb_requirement",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_requirement_title",
                table: "tb_requirement",
                column: "title");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_email",
                table: "tb_user",
                column: "email");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_id",
                table: "tb_user",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_tb_user_name",
                table: "tb_user",
                column: "name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_advantage");

            migrationBuilder.DropTable(
                name: "tb_candidate");

            migrationBuilder.DropTable(
                name: "tb_document");

            migrationBuilder.DropTable(
                name: "tb_requirement");

            migrationBuilder.DropTable(
                name: "tb_application");

            migrationBuilder.DropTable(
                name: "tb_ad");

            migrationBuilder.DropTable(
                name: "tb_user");
        }
    }
}
