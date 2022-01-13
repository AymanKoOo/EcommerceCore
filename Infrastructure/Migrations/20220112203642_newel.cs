using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class newel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Zipcode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });

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
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PictureId = table.Column<int>(type: "int", nullable: false),
                    ParentCategoryId = table.Column<int>(type: "int", nullable: false),
                    MetaDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MetaTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShowOnHomepage = table.Column<bool>(type: "bit", nullable: false),
                    IncludeInTopMenu = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdminComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DiscountTypeId = table.Column<int>(type: "int", nullable: false),
                    UsePercentage = table.Column<bool>(type: "bit", nullable: false),
                    DiscountPercentage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MaximumDiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RequiresCouponCode = table.Column<bool>(type: "bit", nullable: false),
                    CouponCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Picture = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pictures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeoFilename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AltAttribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TitleAttribute = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsNew = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "productAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "specificationAttributeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationAttributeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OldPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitsInStock = table.Column<int>(type: "int", nullable: true),
                    HasDiscountsApplied = table.Column<bool>(type: "bit", nullable: false),
                    Star = table.Column<double>(type: "float", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categoryPictures",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoryPictures", x => new { x.categoryID, x.PictureId });
                    table.ForeignKey(
                        name: "FK_categoryPictures_Categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categoryPictures_pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "categorySpecificationGroups",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeGroupId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorySpecificationGroups", x => new { x.CategoryId, x.SpecificationAttributeGroupId });
                    table.ForeignKey(
                        name: "FK_categorySpecificationGroups_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_categorySpecificationGroups_specificationAttributeGroups_SpecificationAttributeGroupId",
                        column: x => x.SpecificationAttributeGroupId,
                        principalTable: "specificationAttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "specificationAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeGroupId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_specificationAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_specificationAttributes_specificationAttributeGroups_SpecificationAttributeGroupId1",
                        column: x => x.SpecificationAttributeGroupId1,
                        principalTable: "specificationAttributeGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerCurrencyCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentMethodSystemName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderSubtotalInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderSubtotalExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderSubTotalDiscountInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderSubTotalDiscountExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderShippingInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderShippingExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethodAdditionalFeeInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethodAdditionalFeeExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderDiscount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OrderTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RefundedAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaidDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShippingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    customerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ShippingAddressId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Address_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "Address",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_customerId",
                        column: x => x.customerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CartItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "discountProducts",
                columns: table => new
                {
                    DiscountsId = table.Column<int>(type: "int", nullable: false),
                    ProductsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_discountProducts", x => new { x.ProductsId, x.DiscountsId });
                    table.ForeignKey(
                        name: "FK_discountProducts_discounts_DiscountsId",
                        column: x => x.DiscountsId,
                        principalTable: "discounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_discountProducts_products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productAttributeMappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    ProductAttributeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributeMappings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productAttributeMappings_productAttributes_ProductAttributeId",
                        column: x => x.ProductAttributeId,
                        principalTable: "productAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productAttributeMappings_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productPictures",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PictureId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productPictures", x => new { x.ProductId, x.PictureId });
                    table.ForeignKey(
                        name: "FK_productPictures_pictures_PictureId",
                        column: x => x.PictureId,
                        principalTable: "pictures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productPictures_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecificationAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    specificationAttributeId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecificationAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecificationAttributeOptions_specificationAttributes_specificationAttributeId1",
                        column: x => x.specificationAttributeId1,
                        principalTable: "specificationAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "orderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UnitPriceInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UnitPriceExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PriceExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmountInclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountAmountExclTax = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalProductCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_orderItems_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orderNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orderNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_orderNotes_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    TotalWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ShippedDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeliveryDateUtc = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedOnUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipments_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productAttributeOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
                    ColorSquaresRgb = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PriceAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WeightAdjustment = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ImageSquaresPictureId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PicturePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductAttributeMappingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productAttributeOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_productAttributeOptions_productAttributeMappings_ProductAttributeMappingId",
                        column: x => x.ProductAttributeMappingId,
                        principalTable: "productAttributeMappings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductSpecificationAttribute",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    SpecificationAttributeOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSpecificationAttribute", x => new { x.ProductId, x.SpecificationAttributeOptionId });
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSpecificationAttribute_SpecificationAttributeOptions_SpecificationAttributeOptionId",
                        column: x => x.SpecificationAttributeOptionId,
                        principalTable: "SpecificationAttributeOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "shipmentItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentId = table.Column<int>(type: "int", nullable: false),
                    OrderItem = table.Column<int>(type: "int", nullable: false),
                    orderItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shipmentItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_shipmentItems_orderItems_orderItemId",
                        column: x => x.orderItemId,
                        principalTable: "orderItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_shipmentItems_shipments_ShipmentId",
                        column: x => x.ShipmentId,
                        principalTable: "shipments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_AspNetUsers_ShippingAddressId",
                table: "AspNetUsers",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_categoryPictures_PictureId",
                table: "categoryPictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_categorySpecificationGroups_SpecificationAttributeGroupId",
                table: "categorySpecificationGroups",
                column: "SpecificationAttributeGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_discountProducts_DiscountsId",
                table: "discountProducts",
                column: "DiscountsId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_OrderId",
                table: "orderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_orderItems_ProductId",
                table: "orderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_orderNotes_OrderId",
                table: "orderNotes",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerId",
                table: "Orders",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingAddressId",
                table: "Orders",
                column: "ShippingAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_productAttributeMappings_ProductAttributeId",
                table: "productAttributeMappings",
                column: "ProductAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_productAttributeMappings_ProductId",
                table: "productAttributeMappings",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_productAttributeOptions_ProductAttributeMappingId",
                table: "productAttributeOptions",
                column: "ProductAttributeMappingId");

            migrationBuilder.CreateIndex(
                name: "IX_productPictures_PictureId",
                table: "productPictures",
                column: "PictureId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSpecificationAttribute_SpecificationAttributeOptionId",
                table: "ProductSpecificationAttribute",
                column: "SpecificationAttributeOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_shipmentItems_orderItemId",
                table: "shipmentItems",
                column: "orderItemId");

            migrationBuilder.CreateIndex(
                name: "IX_shipmentItems_ShipmentId",
                table: "shipmentItems",
                column: "ShipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_shipments_OrderId",
                table: "shipments",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecificationAttributeOptions_specificationAttributeId1",
                table: "SpecificationAttributeOptions",
                column: "specificationAttributeId1");

            migrationBuilder.CreateIndex(
                name: "IX_specificationAttributes_SpecificationAttributeGroupId1",
                table: "specificationAttributes",
                column: "SpecificationAttributeGroupId1");
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
                name: "CartItems");

            migrationBuilder.DropTable(
                name: "categoryPictures");

            migrationBuilder.DropTable(
                name: "categorySpecificationGroups");

            migrationBuilder.DropTable(
                name: "discountProducts");

            migrationBuilder.DropTable(
                name: "orderNotes");

            migrationBuilder.DropTable(
                name: "productAttributeOptions");

            migrationBuilder.DropTable(
                name: "productPictures");

            migrationBuilder.DropTable(
                name: "ProductSpecificationAttribute");

            migrationBuilder.DropTable(
                name: "shipmentItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "discounts");

            migrationBuilder.DropTable(
                name: "productAttributeMappings");

            migrationBuilder.DropTable(
                name: "pictures");

            migrationBuilder.DropTable(
                name: "SpecificationAttributeOptions");

            migrationBuilder.DropTable(
                name: "orderItems");

            migrationBuilder.DropTable(
                name: "shipments");

            migrationBuilder.DropTable(
                name: "productAttributes");

            migrationBuilder.DropTable(
                name: "specificationAttributes");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "specificationAttributeGroups");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}
