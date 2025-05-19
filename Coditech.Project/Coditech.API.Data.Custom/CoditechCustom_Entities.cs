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
        #region CoOperativeBank
        public DbSet<BankInsurancePoliciesType> BankInsurancePoliciesType { get; set; }
        public DbSet<BankSetupDivision> BankSetupDivision { get; set; }
        public DbSet<BankSetupOffices> BankSetupOffices { get; set; }
        public DbSet<BankSetupMortagePropertyType> BankSetupMortagePropertyType { get; set; }
        public DbSet<BankVehicleModel> BankVehicleModel { get; set; }
        public DbSet<BankSetupPropertyValuers> BankSetupPropertyValuers { get; set; }
        public DbSet<BankSetupPropertyValuersAuthority> BankSetupPropertyValuersAuthority { get; set; }
        public DbSet<BankMemberShareCapital> BankMemberShareCapital { get; set; }
        public DbSet<BankMember> BankMember { get; set; }
        public DbSet<BankMemberNominee> BankMemberNominee { get; set; }
        public DbSet<BankSavingsAccount> BankSavingsAccount { get; set; }
        public DbSet<BankSavingAccountIntrestPostings> BankSavingAccountIntrestPostings { get; set; }
        public DbSet<BankFixedDepositAccount> BankFixedDepositAccount { get; set; }
        public DbSet<BankProduct> BankProduct { get; set; }
        #endregion
    }
}

