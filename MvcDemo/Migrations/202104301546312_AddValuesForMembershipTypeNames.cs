namespace MvcDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddValuesForMembershipTypeNames : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name = 'free' WHERE Id = 1;");
            Sql("UPDATE MembershipTypes SET Name = 'monthly' WHERE Id = 2;");
            Sql("UPDATE MembershipTypes SET Name = 'quarterly' WHERE Id = 3;");
            Sql("UPDATE MembershipTypes SET Name = 'annual' WHERE Id = 4;");
        }
        
        public override void Down()
        {
            Sql("UPDATE MembershipTypes SET Name = ''");
        }
    }
}
