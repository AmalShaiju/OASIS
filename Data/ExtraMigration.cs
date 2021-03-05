using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Data
{
    public static class ExtraMigration
    {
        public static void Steps(MigrationBuilder migrationBuilder)
        {
            // Customer Auditing Fields Updation
            migrationBuilder.Sql(
                  @"
                    CREATE TRIGGER SetCustomerTimestampOnUpdate
                    AFTER UPDATE ON Customers
                    BEGIN
                        UPDATE Customers
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
               @"
                    CREATE TRIGGER SetCustomerTimestampOnInsert
                    AFTER INSERT ON Customers
                    BEGIN
                        UPDATE Customers
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                   END
               ");


            // Role Auditing Fields Updation
            migrationBuilder.Sql(
                          @"
                CREATE TRIGGER SetRoleTimestampOnUpdate
                AFTER UPDATE ON Roles
                BEGIN
                    UPDATE Roles
                    SET RowVersion = randomblob(8)
                    WHERE rowid = NEW.rowid;
                END
            ");
            migrationBuilder.Sql(
               @"
                CREATE TRIGGER SetRoleTimestampOnInsert
                AFTER INSERT ON Roles
                BEGIN
                    UPDATE Roles
                    SET RowVersion = randomblob(8)
                    WHERE rowid = NEW.rowid;
               END
           ");

            // Project Auditing Field Updation
            migrationBuilder.Sql(
             @"
                    CREATE TRIGGER SetProjectTimestampOnUpdate
                    AFTER UPDATE ON Projects
                    BEGIN
                        UPDATE Projects
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
               @"
                    CREATE TRIGGER SetProjectTimestampOnInsert
                    AFTER INSERT ON Projects
                    BEGIN
                        UPDATE Projects
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                   END
               ");

            // Employee Auditing Fields Updation
            migrationBuilder.Sql(
                  @"
                    CREATE TRIGGER SetEmployeeTimestampOnUpdate
                    AFTER UPDATE ON Employees
                    BEGIN
                        UPDATE Employees
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
               @"
                    CREATE TRIGGER SetEmployeeTimestampOnInsert
                    AFTER INSERT ON Employees
                    BEGIN
                        UPDATE Employees
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                   END
               ");

            // Bid Auditing Fields Updation
            migrationBuilder.Sql(
                    @"
                    CREATE TRIGGER SetBidTimestampOnUpdate
                    AFTER UPDATE ON Bids
                    BEGIN
                        UPDATE Bids
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                    END
                ");
            migrationBuilder.Sql(
               @"
                    CREATE TRIGGER SetBidTimestampOnInsert
                    AFTER INSERT ON Bids
                    BEGIN
                        UPDATE Bids
                        SET RowVersion = randomblob(8)
                        WHERE rowid = NEW.rowid;
                   END
               ");


        }
    }
}

