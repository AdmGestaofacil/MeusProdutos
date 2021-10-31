namespace GestaoFacil.infra.Migrations
{
    using GestaoFacil.infra.Data.Context;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<GestaoFacilContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

    }
}
