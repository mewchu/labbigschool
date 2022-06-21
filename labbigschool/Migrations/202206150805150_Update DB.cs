namespace labbigschool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Courses", new[] { "Category_Id" });
            DropIndex("dbo.Courses", new[] { "Lecturer_Id" });
            RenameColumn(table: "dbo.Courses", name: "Category_Id", newName: "CategoryId");
            RenameColumn(table: "dbo.Courses", name: "Lecturer_Id", newName: "LecturerId");
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Courses", "LecturerId");
            CreateIndex("dbo.Courses", "CategoryId");
            AddForeignKey("dbo.Courses", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "LecturerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            DropIndex("dbo.Courses", new[] { "LecturerId" });
            AlterColumn("dbo.Courses", "LecturerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Courses", "CategoryId", c => c.Byte());
            RenameColumn(table: "dbo.Courses", name: "LecturerId", newName: "Lecturer_Id");
            RenameColumn(table: "dbo.Courses", name: "CategoryId", newName: "Category_Id");
            CreateIndex("dbo.Courses", "Lecturer_Id");
            CreateIndex("dbo.Courses", "Category_Id");
            AddForeignKey("dbo.Courses", "Lecturer_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Courses", "Category_Id", "dbo.Categories", "Id");
        }
    }
}
