using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using JuansList.Data;

namespace JuansList.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20161214154416_updatingModelsMigration")]
    partial class updatingModelsMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("JuansList.Models.Album", b =>
                {
                    b.Property<int>("AlbumId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("AlbumId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("JuansList.Models.AlbumImages", b =>
                {
                    b.Property<int>("AlbumImagesId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.HasKey("AlbumImagesId");

                    b.HasIndex("AlbumId");

                    b.ToTable("AlbumImages");
                });

            modelBuilder.Entity("JuansList.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator<string>("Discriminator").HasValue("ApplicationUser");
                });

            modelBuilder.Entity("JuansList.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("JuansList.Models.Coupon", b =>
                {
                    b.Property<int>("CouponId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("CouponId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("Coupon");
                });

            modelBuilder.Entity("JuansList.Models.Estimate", b =>
                {
                    b.Property<int>("EstimateId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerUserId")
                        .IsRequired();

                    b.Property<DateTime>("DateEnd");

                    b.Property<DateTime>("DateStart");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int?>("Price")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("EstimateId");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("Estimate");
                });

            modelBuilder.Entity("JuansList.Models.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CustomerUserId")
                        .IsRequired();

                    b.Property<DateTime>("DateStamp");

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("MessageId");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("Message");
                });

            modelBuilder.Entity("JuansList.Models.Review", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Communication");

                    b.Property<string>("CustomerUserId")
                        .IsRequired();

                    b.Property<DateTime>("Date");

                    b.Property<int>("Efficiency");

                    b.Property<int>("Profesionalism");

                    b.Property<int>("Quality");

                    b.Property<string>("Reply")
                        .IsRequired();

                    b.Property<string>("Text")
                        .IsRequired();

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("ReviewId");

                    b.HasIndex("CustomerUserId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("JuansList.Models.VendorCategory", b =>
                {
                    b.Property<int>("VendorCategoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryId");

                    b.Property<string>("VendorUserId")
                        .IsRequired();

                    b.HasKey("VendorCategoryId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VendorUserId");

                    b.ToTable("VendorCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("JuansList.Models.CustomerUser", b =>
                {
                    b.HasBaseType("JuansList.Models.ApplicationUser");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("ProfileImage");

                    b.Property<int?>("Rating");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<int>("Zip");

                    b.ToTable("CustomerUser");

                    b.HasDiscriminator().HasValue("CustomerUser");
                });

            modelBuilder.Entity("JuansList.Models.VendorUser", b =>
                {
                    b.HasBaseType("JuansList.Models.ApplicationUser");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("CompanyName")
                        .IsRequired();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("EmailAddress")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("ProfileImage");

                    b.Property<int?>("Rating");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<int>("Zip");

                    b.ToTable("VendorUser");

                    b.HasDiscriminator().HasValue("VendorUser");
                });

            modelBuilder.Entity("JuansList.Models.Album", b =>
                {
                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany()
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.AlbumImages", b =>
                {
                    b.HasOne("JuansList.Models.Album")
                        .WithMany("Images")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.Coupon", b =>
                {
                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany()
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.Estimate", b =>
                {
                    b.HasOne("JuansList.Models.CustomerUser", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany()
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.Message", b =>
                {
                    b.HasOne("JuansList.Models.CustomerUser", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany()
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.Review", b =>
                {
                    b.HasOne("JuansList.Models.CustomerUser", "CustomerUser")
                        .WithMany()
                        .HasForeignKey("CustomerUserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany()
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("JuansList.Models.VendorCategory", b =>
                {
                    b.HasOne("JuansList.Models.Category", "Category")
                        .WithMany("VendorCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuansList.Models.VendorUser", "VendorUser")
                        .WithMany("VendorCategories")
                        .HasForeignKey("VendorUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("JuansList.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("JuansList.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("JuansList.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
