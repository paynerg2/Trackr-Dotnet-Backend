// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Trackr.Data;

#nullable disable

namespace Trackr.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220606190332_AddUserRelationships")]
    partial class AddUserRelationships
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Trackr.Models.Application", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("AdditionalSkillsMet")
                        .HasColumnType("int");

                    b.Property<int?>("AdditionalSkillsTotal")
                        .HasColumnType("int");

                    b.Property<bool>("ArbitraryRelocation")
                        .HasColumnType("bit");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyLinkedIn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateApplicationSent")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatePosted")
                        .HasColumnType("datetime2");

                    b.Property<int>("DegreeLevel")
                        .HasColumnType("int");

                    b.Property<int>("ExpectedSalary")
                        .HasColumnType("int");

                    b.Property<string>("Field")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("GivenReferral")
                        .HasColumnType("bit");

                    b.Property<string>("JobDescriptionLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainSkill")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RequiredSkillsMet")
                        .HasColumnType("int");

                    b.Property<int?>("RequiredSkillsTotal")
                        .HasColumnType("int");

                    b.Property<int>("Response")
                        .HasColumnType("int");

                    b.Property<bool>("Temp")
                        .HasColumnType("bit");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("Trackr.Models.Contact", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Contact");
                });

            modelBuilder.Entity("Trackr.Models.Interview", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Company")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("FollowUpSent")
                        .HasColumnType("bit");

                    b.Property<string>("InterviewType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Offer")
                        .HasColumnType("int");

                    b.Property<int>("Response")
                        .HasColumnType("int");

                    b.Property<int>("Round")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ContactId");

                    b.HasIndex("UserId");

                    b.ToTable("Interview");
                });

            modelBuilder.Entity("Trackr.Models.Settings", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("DefaultListDisplayType")
                        .HasColumnType("int");

                    b.Property<bool>("IsDarkMode")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Settings");
                });

            modelBuilder.Entity("Trackr.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CloudinaryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SettingsId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("SettingsId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Trackr.Models.Application", b =>
                {
                    b.HasOne("Trackr.Models.User", null)
                        .WithMany("Applications")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Trackr.Models.Contact", b =>
                {
                    b.HasOne("Trackr.Models.User", null)
                        .WithMany("Contacts")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Trackr.Models.Interview", b =>
                {
                    b.HasOne("Trackr.Models.Application", null)
                        .WithMany("Interviews")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("Trackr.Models.Contact", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId");

                    b.HasOne("Trackr.Models.User", null)
                        .WithMany("Interviews")
                        .HasForeignKey("UserId");

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("Trackr.Models.User", b =>
                {
                    b.HasOne("Trackr.Models.Settings", "Settings")
                        .WithMany()
                        .HasForeignKey("SettingsId");

                    b.Navigation("Settings");
                });

            modelBuilder.Entity("Trackr.Models.Application", b =>
                {
                    b.Navigation("Interviews");
                });

            modelBuilder.Entity("Trackr.Models.User", b =>
                {
                    b.Navigation("Applications");

                    b.Navigation("Contacts");

                    b.Navigation("Interviews");
                });
#pragma warning restore 612, 618
        }
    }
}
