﻿// <auto-generated />
using System;
using CommanderGQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(WebAppContext))]
    partial class WebAppContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.6");

            modelBuilder.Entity("CommanderGQL.Models.ChatGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChatGroups");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatGroupMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("TEXT");

                    b.Property<bool>("HasBeenRead")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ChatGroupId");

                    b.HasIndex("ChatMemberId");

                    b.ToTable("ChatGroupMembers");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ChatMembers");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatMessage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatGroupId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ChatGroupMemberId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Deleted")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ChatGroupId");

                    b.HasIndex("ChatGroupMemberId");

                    b.ToTable("ChatMessages");
                });

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("command_id")
                        .HasColumnOrder(1);

                    b.Property<string>("CommandLine")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PlatformId")
                        .IsRequired()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PlatformId");

                    b.ToTable("command", (string)null);
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("platform_id")
                        .HasColumnOrder(1);

                    b.Property<string>("LicenseKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("platform", (string)null);
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatGroupMember", b =>
                {
                    b.HasOne("CommanderGQL.Models.ChatGroup", "ChatGroup")
                        .WithMany("Members")
                        .HasForeignKey("ChatGroupId");

                    b.HasOne("CommanderGQL.Models.ChatMember", "Member")
                        .WithMany("ChatGroups")
                        .HasForeignKey("ChatMemberId");

                    b.Navigation("ChatGroup");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatMessage", b =>
                {
                    b.HasOne("CommanderGQL.Models.ChatGroup", "ChatGroup")
                        .WithMany("Messages")
                        .HasForeignKey("ChatGroupId");

                    b.HasOne("CommanderGQL.Models.ChatGroupMember", "ChatGroupMember")
                        .WithMany()
                        .HasForeignKey("ChatGroupMemberId");

                    b.Navigation("ChatGroup");

                    b.Navigation("ChatGroupMember");
                });

            modelBuilder.Entity("CommanderGQL.Models.Command", b =>
                {
                    b.HasOne("CommanderGQL.Models.Platform", "Platform")
                        .WithMany("Commands")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatGroup", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("Messages");
                });

            modelBuilder.Entity("CommanderGQL.Models.ChatMember", b =>
                {
                    b.Navigation("ChatGroups");
                });

            modelBuilder.Entity("CommanderGQL.Models.Platform", b =>
                {
                    b.Navigation("Commands");
                });
#pragma warning restore 612, 618
        }
    }
}
