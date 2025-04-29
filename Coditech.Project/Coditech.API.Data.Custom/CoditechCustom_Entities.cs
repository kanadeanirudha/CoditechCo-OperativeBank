using Microsoft.EntityFrameworkCore;

namespace Coditech.API.Data
{
    public partial class CoditechCustom_Entities : CoditechDbContext
    {
        public CoditechCustom_Entities()
        {
        }

        public CoditechCustom_Entities(DbContextOptions<CoditechCustom_Entities> options) : base(options)
        {
        }
        #region Accounts
        public DbSet<BankSetupMortagePropertyType> BankSetupMortagePropertyType { get; set; }
        public DbSet<BankVehicleModel> BankVehicleModel { get; set; }
        public DbSet<BankSetupPropertyValuers> BankSetupPropertyValuers { get; set; }
        public DbSet<BankSetupPropertyValuersAuthority> BankSetupPropertyValuersAuthority { get; set; }
        public DbSet<BankMember> BankMember { get; set; }
        #endregion
    }
}

