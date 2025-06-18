using Coditech.API.Data;
using Coditech.Common.API.Model;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper;
using Coditech.Common.Helper.Utilities;
using Coditech.Common.Logger;
using Coditech.Common.Service;
using Coditech.Resources;

using System.Data;
namespace Coditech.API.Service
{
    public class CoOperativeUIService : BaseService, ICoOperativeUIService
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ICoditechLogging _coditechLogging;
        private readonly ICoditechRepository<BankMember> _bankMemberRepository;
        //private readonly ICoditechRepository<HospitalDoctors> _hospitalDoctorsRepository;

        public CoOperativeUIService(ICoditechLogging coditechLogging, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _coditechLogging = coditechLogging;
            _bankMemberRepository = new CoditechRepository<BankMember>(_serviceProvider.GetService<CoditechCustom_Entities>());
           // _hospitalDoctorsRepository = new CoditechRepository<HospitalDoctors>(_serviceProvider.GetService<Coditech_Entities>());
        }
        public virtual CoOperativeUIModel GetCoOperativeUIDetails(int selectedBalanceSheeetId)
        {
            if (selectedBalanceSheeetId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "SelectedBalanceSheeetId"));
            CoOperativeUIModel coOperativeUIModel = new CoOperativeUIModel();
            return coOperativeUIModel;
        }

        //Get CoOperativeUIModel by bankMemberId and navbarEnumId.
        public virtual CoOperativeUIModel GetCoOperativeUI(int bankMemberId, int navbarEnumId)
        {
            if (bankMemberId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "bankMemberId"));

            if (navbarEnumId <= 0)
                throw new CoditechException(ErrorCodes.IdLessThanOne, string.Format(GeneralResources.ErrorIdLessThanOne, "weekDayEnumId"));

            CoOperativeUIModel coOperativeUIModel = new CoOperativeUIModel()
            {
                BankMemberId = bankMemberId,
                NavbarEnumId = navbarEnumId
            };
           
            return coOperativeUIModel;
        }
    }
}
