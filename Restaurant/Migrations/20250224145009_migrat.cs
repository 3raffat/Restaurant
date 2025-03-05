using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Restaurant.Migrations
{
    /// <inheritdoc />
    public partial class migrat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MasterCategoryMenus",
                columns: table => new
                {
                    MasterCategoryMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterCategoryMenuName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterCategoryMenus", x => x.MasterCategoryMenuId);
                });

            migrationBuilder.CreateTable(
                name: "MasterContactUsInformations",
                columns: table => new
                {
                    MasterContactUsInformationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterContactUsInformationIdesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterContactUsInformationImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterContactUsInformationRedirect = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterContactUsInformations", x => x.MasterContactUsInformationId);
                });

            migrationBuilder.CreateTable(
                name: "MasterFeedBacks",
                columns: table => new
                {
                    MasterFeedBackId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterFeedBackDesc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterFeedBackCustomerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterFeedBackCustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterFeedBacks", x => x.MasterFeedBackId);
                });

            migrationBuilder.CreateTable(
                name: "MasterMenus",
                columns: table => new
                {
                    MasterMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterMenuName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterMenuUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterMenus", x => x.MasterMenuId);
                });

            migrationBuilder.CreateTable(
                name: "MasterOffers",
                columns: table => new
                {
                    MasterOfferId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterOfferTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferBookNow = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterOfferImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterOffers", x => x.MasterOfferId);
                });

            migrationBuilder.CreateTable(
                name: "MasterPartners",
                columns: table => new
                {
                    MasterPartnerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterPartnerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterPartnerWebsiteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterPartners", x => x.MasterPartnerId);
                });

            migrationBuilder.CreateTable(
                name: "MasterServices",
                columns: table => new
                {
                    MasterServicesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterServicesTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterServicesImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterServices", x => x.MasterServicesId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSliders",
                columns: table => new
                {
                    MasterSliderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterSliderTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterSliderUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSliders", x => x.MasterSliderId);
                });

            migrationBuilder.CreateTable(
                name: "MasterSocialMedias",
                columns: table => new
                {
                    MasterSocialMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterSocialMediaImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MasterSocialMediaUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterSocialMedias", x => x.MasterSocialMediaId);
                });

            migrationBuilder.CreateTable(
                name: "MasterWorkingHours",
                columns: table => new
                {
                    MasterWorkingHoursId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterWorkingHoursName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterWorkingHoursTimeFormTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterWorkingHours", x => x.MasterWorkingHoursId);
                });

            migrationBuilder.CreateTable(
                name: "SystemSettings",
                columns: table => new
                {
                    SystemSettingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SystemSettingLogoImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingLogoImageUrl2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingCopyright = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingWelcomeNoteImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemSettingMapLocation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemSettings", x => x.SystemSettingId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionBookTables",
                columns: table => new
                {
                    TransactionBookTableId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionBookTableFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableMobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionBookTableDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionBookTables", x => x.TransactionBookTableId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionContactUs",
                columns: table => new
                {
                    TransactionContactUsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionContactUsFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsSubject = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TransactionContactUsMessage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionContactUs", x => x.TransactionContactUsId);
                });

            migrationBuilder.CreateTable(
                name: "TransactionNewsletters",
                columns: table => new
                {
                    TransactionNewsletterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionNewsletterEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransactionNewsletters", x => x.TransactionNewsletterId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "MasterItemMenus",
                columns: table => new
                {
                    MasterItemMenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MasterItemMenuTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterItemMenuBreef = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterItemMenuDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterItemMenuPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MasterItemMenuImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MasterItemMenuDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MasterCategoryMenuId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EditId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EditDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterItemMenus", x => x.MasterItemMenuId);
                    table.ForeignKey(
                        name: "FK_MasterItemMenus_MasterCategoryMenus_MasterCategoryMenuId",
                        column: x => x.MasterCategoryMenuId,
                        principalTable: "MasterCategoryMenus",
                        principalColumn: "MasterCategoryMenuId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MasterItemMenus_MasterCategoryMenuId",
                table: "MasterItemMenus",
                column: "MasterCategoryMenuId");
        }

        /// <inheritdoc />
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
                name: "MasterContactUsInformations");

            migrationBuilder.DropTable(
                name: "MasterFeedBacks");

            migrationBuilder.DropTable(
                name: "MasterItemMenus");

            migrationBuilder.DropTable(
                name: "MasterMenus");

            migrationBuilder.DropTable(
                name: "MasterOffers");

            migrationBuilder.DropTable(
                name: "MasterPartners");

            migrationBuilder.DropTable(
                name: "MasterServices");

            migrationBuilder.DropTable(
                name: "MasterSliders");

            migrationBuilder.DropTable(
                name: "MasterSocialMedias");

            migrationBuilder.DropTable(
                name: "MasterWorkingHours");

            migrationBuilder.DropTable(
                name: "SystemSettings");

            migrationBuilder.DropTable(
                name: "TransactionBookTables");

            migrationBuilder.DropTable(
                name: "TransactionContactUs");

            migrationBuilder.DropTable(
                name: "TransactionNewsletters");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "MasterCategoryMenus");
        }
    }
}
