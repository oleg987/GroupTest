﻿// <auto-generated />
using GroupTest;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GroupTest.Migrations
{
    [DbContext(typeof(GroupContext))]
    [Migration("20240131154547_AddStudentGroup")]
    partial class AddStudentGroup
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FlowGroup", b =>
                {
                    b.Property<int>("FlowsId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupsId")
                        .HasColumnType("integer");

                    b.HasKey("FlowsId", "GroupsId");

                    b.HasIndex("GroupsId");

                    b.ToTable("FlowGroup");
                });

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.HasKey("StudentId", "GroupId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupStudent");
                });

            modelBuilder.Entity("GroupTest.DbViews.StudentGroupView", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.ToTable((string)null);

                    b.ToView("GroupStudentsView", (string)null);
                });

            modelBuilder.Entity("GroupTest.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AcademicGroupId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AcademicGroupId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("GroupTest.Entities.StudyUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("character varying(13)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("StudyUnits");

                    b.HasDiscriminator<string>("Discriminator").HasValue("StudyUnit");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("StudentGroupView", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<int>("StudentId")
                        .HasColumnType("integer");

                    b.HasKey("GroupId", "StudentId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentGroupView");
                });

            modelBuilder.Entity("GroupTest.Entities.Flow", b =>
                {
                    b.HasBaseType("GroupTest.Entities.StudyUnit");

                    b.HasDiscriminator().HasValue("Flow");
                });

            modelBuilder.Entity("GroupTest.Entities.Group", b =>
                {
                    b.HasBaseType("GroupTest.Entities.StudyUnit");

                    b.HasDiscriminator().HasValue("Group");
                });

            modelBuilder.Entity("GroupTest.Entities.AcademicFlow", b =>
                {
                    b.HasBaseType("GroupTest.Entities.Flow");

                    b.HasDiscriminator().HasValue("AcademicFlow");
                });

            modelBuilder.Entity("GroupTest.Entities.AcademicGroup", b =>
                {
                    b.HasBaseType("GroupTest.Entities.Group");

                    b.Property<int>("InstituteId")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("AcademicGroup");
                });

            modelBuilder.Entity("GroupTest.Entities.StudyGroup", b =>
                {
                    b.HasBaseType("GroupTest.Entities.Group");

                    b.Property<int>("ComponentId")
                        .HasColumnType("integer");

                    b.HasDiscriminator().HasValue("StudyGroup");
                });

            modelBuilder.Entity("GroupTest.Entities.SubGroup", b =>
                {
                    b.HasBaseType("GroupTest.Entities.Group");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.HasIndex("ParentId");

                    b.HasDiscriminator().HasValue("SubGroup");
                });

            modelBuilder.Entity("FlowGroup", b =>
                {
                    b.HasOne("GroupTest.Entities.Flow", null)
                        .WithMany()
                        .HasForeignKey("FlowsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupTest.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupStudent", b =>
                {
                    b.HasOne("GroupTest.Entities.StudyGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupTest.Entities.SubGroup", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupTest.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupTest.Entities.Student", b =>
                {
                    b.HasOne("GroupTest.Entities.AcademicGroup", "AcademicGroup")
                        .WithMany("Students")
                        .HasForeignKey("AcademicGroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AcademicGroup");
                });

            modelBuilder.Entity("StudentGroupView", b =>
                {
                    b.HasOne("GroupTest.Entities.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GroupTest.Entities.Student", null)
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GroupTest.Entities.SubGroup", b =>
                {
                    b.HasOne("GroupTest.Entities.AcademicGroup", "Parent")
                        .WithMany("SubGroups")
                        .HasForeignKey("ParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("GroupTest.Entities.AcademicGroup", b =>
                {
                    b.Navigation("Students");

                    b.Navigation("SubGroups");
                });
#pragma warning restore 612, 618
        }
    }
}
