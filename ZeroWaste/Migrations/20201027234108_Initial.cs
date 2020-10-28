using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace ZeroWaste.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    PublicationDate = table.Column<DateTime>(nullable: false),
                    MainText = table.Column<int>(nullable: false),
                    PictureLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NutritionalTypes",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionalTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ZWMembers",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DoB = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<string>(nullable: true),
                    PictureLink = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZWMembers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 256, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 256, nullable: false),
                    RoleId = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(maxLength: 256, nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 256, nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Allergies",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    ZWMemberID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergies", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Allergies_ZWMembers_ZWMemberID",
                        column: x => x.ZWMemberID,
                        principalTable: "ZWMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    PictureLink = table.Column<string>(nullable: true),
                    ZWMemberID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Ingredients_ZWMembers_ZWMemberID",
                        column: x => x.ZWMemberID,
                        principalTable: "ZWMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    ExecTime = table.Column<int>(nullable: false),
                    PrepTime = table.Column<int>(nullable: false),
                    Portions = table.Column<int>(nullable: false),
                    PictureLink1 = table.Column<string>(nullable: true),
                    PictureLink2 = table.Column<string>(nullable: true),
                    Simplicity = table.Column<int>(nullable: false),
                    PreparationMethod = table.Column<int>(nullable: false),
                    ZWMemberID = table.Column<long>(nullable: true),
                    ZWMemberID1 = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipies_ZWMembers_ZWMemberID",
                        column: x => x.ZWMemberID,
                        principalTable: "ZWMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipies_ZWMembers_ZWMemberID1",
                        column: x => x.ZWMemberID1,
                        principalTable: "ZWMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true),
                    AllergyID = table.Column<long>(nullable: true),
                    IngredientID = table.Column<long>(nullable: true),
                    IngredientID1 = table.Column<long>(nullable: true),
                    NewsID = table.Column<long>(nullable: true),
                    RecipieId = table.Column<long>(nullable: true),
                    ZWMemberID = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Keywords_Allergies_AllergyID",
                        column: x => x.AllergyID,
                        principalTable: "Allergies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Keywords_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Keywords_Ingredients_IngredientID1",
                        column: x => x.IngredientID1,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Keywords_News_NewsID",
                        column: x => x.NewsID,
                        principalTable: "News",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Keywords_Recipies_RecipieId",
                        column: x => x.RecipieId,
                        principalTable: "Recipies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Keywords_ZWMembers_ZWMemberID",
                        column: x => x.ZWMemberID,
                        principalTable: "ZWMembers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipieIngredient",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    IngredientID = table.Column<long>(nullable: true),
                    Amount = table.Column<float>(nullable: false),
                    Unit = table.Column<string>(nullable: true),
                    RecipieId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipieIngredient", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipieIngredient_Ingredients_IngredientID",
                        column: x => x.IngredientID,
                        principalTable: "Ingredients",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipieIngredient_Recipies_RecipieId",
                        column: x => x.RecipieId,
                        principalTable: "Recipies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipieNutritionalType",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    NutrionalTypeID = table.Column<long>(nullable: true),
                    NutrionalValue = table.Column<float>(nullable: false),
                    RecipieId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipieNutritionalType", x => x.ID);
                    table.ForeignKey(
                        name: "FK_RecipieNutritionalType_NutritionalTypes_NutrionalTypeID",
                        column: x => x.NutrionalTypeID,
                        principalTable: "NutritionalTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipieNutritionalType_Recipies_RecipieId",
                        column: x => x.RecipieId,
                        principalTable: "Recipies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Allergies_ZWMemberID",
                table: "Allergies",
                column: "ZWMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_ZWMemberID",
                table: "Ingredients",
                column: "ZWMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_AllergyID",
                table: "Keywords",
                column: "AllergyID");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_IngredientID",
                table: "Keywords",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_IngredientID1",
                table: "Keywords",
                column: "IngredientID1");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_NewsID",
                table: "Keywords",
                column: "NewsID");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_RecipieId",
                table: "Keywords",
                column: "RecipieId");

            migrationBuilder.CreateIndex(
                name: "IX_Keywords_ZWMemberID",
                table: "Keywords",
                column: "ZWMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipieIngredient_IngredientID",
                table: "RecipieIngredient",
                column: "IngredientID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipieIngredient_RecipieId",
                table: "RecipieIngredient",
                column: "RecipieId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipieNutritionalType_NutrionalTypeID",
                table: "RecipieNutritionalType",
                column: "NutrionalTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_RecipieNutritionalType_RecipieId",
                table: "RecipieNutritionalType",
                column: "RecipieId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipies_ZWMemberID",
                table: "Recipies",
                column: "ZWMemberID");

            migrationBuilder.CreateIndex(
                name: "IX_Recipies_ZWMemberID1",
                table: "Recipies",
                column: "ZWMemberID1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Keywords");

            migrationBuilder.DropTable(
                name: "RecipieIngredient");

            migrationBuilder.DropTable(
                name: "RecipieNutritionalType");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Allergies");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "NutritionalTypes");

            migrationBuilder.DropTable(
                name: "Recipies");

            migrationBuilder.DropTable(
                name: "ZWMembers");
        }
    }
}
