﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tasks.Api.Data;

namespace Tasks.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210516164803_TaskDetailsCanNowBeNull")]
    partial class TaskDetailsCanNowBeNull
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.5")
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

                    b.Property<Guid?>("TaskCreatorRoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("TaskCreatorUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("TaskName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RoomTaskId");

                    b.HasIndex("RoomId");

                    b.HasIndex("TaskCreatorRoomId", "TaskCreatorUserId");

                    b.ToTable("RoomTasks");
                });

            modelBuilder.Entity("Tasks.Api.Entities.UserInRoom", b =>
                {
                    b.Property<Guid>("RoomId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoomRoleId")
                        .HasColumnType("uuid");

                    b.HasKey("RoomId", "UserId");

                    b.HasIndex("RoomRoleId");

                    b.ToTable("UsersInRoom");
                });

            modelBuilder.Entity("Tasks.Api.Entities.RoomTask", b =>
                {
                    b.HasOne("Tasks.Api.Entities.Room", "Room")
                        .WithMany("RoomTasks")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasks.Api.Entities.UserInRoom", "TaskCreator")
                        .WithMany()
                        .HasForeignKey("TaskCreatorRoomId", "TaskCreatorUserId");

                    b.Navigation("Room");

                    b.Navigation("TaskCreator");
                });

            modelBuilder.Entity("Tasks.Api.Entities.UserInRoom", b =>
                {
                    b.HasOne("Tasks.Api.Entities.Room", null)
                        .WithMany("UsersInRoom")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasks.Api.Entities.RoomRole", "RoomRole")
                        .WithMany("UserInRooms")
                        .HasForeignKey("RoomRoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomRole");
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
#pragma warning restore 612, 618
        }
    }
}
