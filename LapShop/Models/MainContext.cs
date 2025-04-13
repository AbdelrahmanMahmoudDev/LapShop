using Microsoft.EntityFrameworkCore;

namespace LapShop.Models
{
    public class MainContext : DbContext
    {
        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
            configurationBuilder.Properties<string>().HaveMaxLength(200);
            configurationBuilder.Properties<decimal>().HaveColumnType("decimal(8, 2)");
            configurationBuilder.Properties<DateTime>().HaveColumnType("DateTime");
        }
    }
}
