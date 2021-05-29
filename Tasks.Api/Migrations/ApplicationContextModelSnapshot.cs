﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasks.Api.Data;

namespace Tasks.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Tasks.Api.Entities.Room", b =>
                {
                    b.Property<Guid>("RoomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("RoomDescription")
                        .HasColumnType("text");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoomId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Tasks.Api.Entities.RoomRole", b =>
                {
                    b.Property<Guid>("RoomRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("RoomRoleDescription")
                        .HasColumnType("text");

                    b.Property<string>("RoomRoleName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoomRoleId");

                    b.ToTable("RoomRoles");
                });

            modelBuilder.Entity("Tasks.Api.Entities.RoomTask", b =>
                {
                    b.Property<Guid>("RoomTaskId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeadlineTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Details")
                        .HasColumnType("text");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<string>("TaskContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TaskCreationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("TaskCreatorId")
                        .HasColumnType("uuid");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoomTaskId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TaskCreatorId");

                    b.ToTable("RoomTasks");
                });

            modelBuilder.Entity("Tasks.Api.Entities.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Tasks.Api.Entities.UserInTheRoom", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoomId", "UserId");

                    b.HasIndex("RoomRoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInTheRoom");
                });

            modelBuilder.Entity("Tasks.Api.Entities.RoomTask", b =>
                {
                    b.HasOne("Tasks.Api.Entities.Room", "Room")
                        .WithMany("RoomTasks")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasks.Api.Entities.User", "TaskCreator")
                        .WithMany()
                        .HasForeignKey("TaskCreatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("TaskCreator");
                });

            modelBuilder.Entity("Tasks.Api.Entities.UserInTheRoom", b =>
                {
                    b.HasOne("Tasks.Api.Entities.Room", "Room")
                        .WithMany("UsersInRoom")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasks.Api.Entities.RoomRole", "RoomRole")
                        .WithMany("UserInRooms")
                        .HasForeignKey("RoomRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasks.Api.Entities.User", "User")
                        .WithMany("UserInTheRooms")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Room");

                    b.Navigation("RoomRole");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasks.Api.Entities.Room", b =>
                {
                    b.Navigation("RoomTasks");

                    b.Navigation("UsersInRoom");
                });

            modelBuilder.Entity("Tasks.Api.Entities.RoomRole", b =>
                {
                    b.Navigation("UserInRooms");
                });

            modelBuilder.Entity("Tasks.Api.Entities.User", b =>
                {
                    b.Navigation("UserInTheRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
