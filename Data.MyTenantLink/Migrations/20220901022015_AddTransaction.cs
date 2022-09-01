using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTenantLink.Data.Migrations
{
    public partial class AddTransaction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buildings_Customer_CustomerId",
                table: "Buildings");

            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Customer_CustomerId",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Tenants_TenantId",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_Leases_Units_UnitId",
                table: "Leases");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenants_Customer_CustomerId",
                table: "Tenants");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Buildings_BuildingId",
                table: "Units");

            migrationBuilder.DropForeignKey(
                name: "FK_Units_Customer_CustomerId",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Leases",
                table: "Leases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "Unit");

            migrationBuilder.RenameTable(
                name: "Tenants",
                newName: "Tenant");

            migrationBuilder.RenameTable(
                name: "Leases",
                newName: "Lease");

            migrationBuilder.RenameTable(
                name: "Buildings",
                newName: "Building");

            migrationBuilder.RenameIndex(
                name: "IX_Units_CustomerId",
                table: "Unit",
                newName: "IX_Unit_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Units_BuildingId",
                table: "Unit",
                newName: "IX_Unit_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenants_CustomerId",
                table: "Tenant",
                newName: "IX_Tenant_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Leases_UnitId",
                table: "Lease",
                newName: "IX_Lease_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Leases_TenantId",
                table: "Lease",
                newName: "IX_Lease_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Leases_CustomerId",
                table: "Lease",
                newName: "IX_Lease_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Buildings_CustomerId",
                table: "Building",
                newName: "IX_Building_CustomerId");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Lease",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "NextDate",
                table: "Lease",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Period",
                table: "Lease",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "Lease",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Unit",
                table: "Unit",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lease",
                table: "Lease",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Building",
                table: "Building",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Building_Customer_CustomerId",
                table: "Building",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_Customer_CustomerId",
                table: "Lease",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_Tenant_TenantId",
                table: "Lease",
                column: "TenantId",
                principalTable: "Tenant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Lease_Unit_UnitId",
                table: "Lease",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenant_Customer_CustomerId",
                table: "Tenant",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Building_BuildingId",
                table: "Unit",
                column: "BuildingId",
                principalTable: "Building",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Unit_Customer_CustomerId",
                table: "Unit",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Building_Customer_CustomerId",
                table: "Building");

            migrationBuilder.DropForeignKey(
                name: "FK_Lease_Customer_CustomerId",
                table: "Lease");

            migrationBuilder.DropForeignKey(
                name: "FK_Lease_Tenant_TenantId",
                table: "Lease");

            migrationBuilder.DropForeignKey(
                name: "FK_Lease_Unit_UnitId",
                table: "Lease");

            migrationBuilder.DropForeignKey(
                name: "FK_Tenant_Customer_CustomerId",
                table: "Tenant");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Building_BuildingId",
                table: "Unit");

            migrationBuilder.DropForeignKey(
                name: "FK_Unit_Customer_CustomerId",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Unit",
                table: "Unit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tenant",
                table: "Tenant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lease",
                table: "Lease");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Building",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Lease");

            migrationBuilder.DropColumn(
                name: "NextDate",
                table: "Lease");

            migrationBuilder.DropColumn(
                name: "Period",
                table: "Lease");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "Lease");

            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "Tenant",
                newName: "Tenants");

            migrationBuilder.RenameTable(
                name: "Lease",
                newName: "Leases");

            migrationBuilder.RenameTable(
                name: "Building",
                newName: "Buildings");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_CustomerId",
                table: "Units",
                newName: "IX_Units_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Unit_BuildingId",
                table: "Units",
                newName: "IX_Units_BuildingId");

            migrationBuilder.RenameIndex(
                name: "IX_Tenant_CustomerId",
                table: "Tenants",
                newName: "IX_Tenants_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_UnitId",
                table: "Leases",
                newName: "IX_Leases_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_TenantId",
                table: "Leases",
                newName: "IX_Leases_TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Lease_CustomerId",
                table: "Leases",
                newName: "IX_Leases_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Building_CustomerId",
                table: "Buildings",
                newName: "IX_Buildings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tenants",
                table: "Tenants",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Leases",
                table: "Leases",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Buildings",
                table: "Buildings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Buildings_Customer_CustomerId",
                table: "Buildings",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Customer_CustomerId",
                table: "Leases",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Tenants_TenantId",
                table: "Leases",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Leases_Units_UnitId",
                table: "Leases",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tenants_Customer_CustomerId",
                table: "Tenants",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Buildings_BuildingId",
                table: "Units",
                column: "BuildingId",
                principalTable: "Buildings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Units_Customer_CustomerId",
                table: "Units",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "Id");
        }
    }
}
