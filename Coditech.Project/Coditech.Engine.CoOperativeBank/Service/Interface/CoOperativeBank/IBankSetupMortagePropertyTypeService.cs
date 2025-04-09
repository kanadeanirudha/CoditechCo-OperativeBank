using Coditech.Common.API.Model;
using Coditech.Common.Helper.Utilities;
using System.Collections.Specialized;
namespace Coditech.API.Service
{
    public interface IBankSetupMortagePropertyTypeService
    {
        BankSetupMortagePropertyTypeListModel GetPropertyTypeList(FilterCollection filters, NameValueCollection sorts, NameValueCollection expands, int pagingStart, int pagingLength);
        BankSetupMortagePropertyTypeModel CreatePropertyType(BankSetupMortagePropertyTypeModel model);
        BankSetupMortagePropertyTypeModel GetPropertyType(short bankSetupMortagePropertyTypeId);
        bool UpdatePropertyType(BankSetupMortagePropertyTypeModel model);
        bool DeletePropertyType(ParameterModel parameterModel);
    }
}
