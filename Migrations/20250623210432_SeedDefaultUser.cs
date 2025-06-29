using Microsoft.EntityFrameworkCore.Migrations;
using System;

#nullable disable

namespace SchoolManagement.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var timestamp = new DateTime(2025, 06, 23, 18, 0, 0);
            var hashedPassword = "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=";

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[]
                {
                    "Id", "FirstName", "LastName", "Email", "PhoneNumber",
                    "Address", "DateOfBirth", "PasswordHash", "Role", "IsDeleted",
                    "DeletedAt", "DeletedBy", "CreatedAt", "CreatedBy", "UpdatedAt", "UpdatedBy"
                },
                values: new object[]
                {
                    1,
                    "Admin",
                    "User",
                    "admin@school.com",
                    "1234567890",
                    "School Address",
                    new DateTime(1980, 1, 1),
                    hashedPassword,
                    "Admin",
                    false,
                    null,
                    null,
                    timestamp,
                    "System",
                    null,
                    null
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[]
                {
                    "Id", "TeacherId", "HireDate", "Specialization",
                    "UserId", "IsDeleted", "CreatedAt", "CreatedBy"
                },
                values: new object[]
                {
                    1,
                    "TECH-ADMIN-001",
                    timestamp,
                    "Administration",
                    1,
                    false,
                    timestamp,
                    "System"
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
