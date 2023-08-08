﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactsApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConfirmPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Contacts",
                newName: "Password");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Contacts",
                newName: "PasswordHash");
        }
    }
}
