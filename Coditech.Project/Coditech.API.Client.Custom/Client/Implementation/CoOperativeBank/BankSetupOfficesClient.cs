using Coditech.API.Endpoint;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Newtonsoft.Json;
using System.Net;
namespace Coditech.API.Client
{
    public class BankSetupOfficesClient : BaseClient, IBankSetupOfficesClient
    {
        BankSetupOfficesEndpoint bankSetupOfficesEndpoint = null;
        public BankSetupOfficesClient()
        {
            bankSetupOfficesEndpoint = new BankSetupOfficesEndpoint();
        }
        public virtual BankSetupOfficesListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSetupOfficesListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupOfficesEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
            HttpResponseMessage response = null;
            var disposeResponse = true;
            try
            {
                ApiStatus status = new ApiStatus();

                response = await GetResourceFromEndpointAsync(endpoint, status, cancellationToken).ConfigureAwait(false);
                Dictionary<string, IEnumerable<string>> headers_ = BindHeaders(response);
                var status_ = (int)response.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupOfficesListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankSetupOfficesListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupOfficesListResponse typedBody = JsonConvert.DeserializeObject<BankSetupOfficesListResponse>(responseData);
                    UpdateApiStatus(typedBody, status, response);
                    throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
                }
            }
            finally
            {
                if (disposeResponse)
                    response.Dispose();
            }
        }
        public virtual BankSetupOfficesResponse CreateBankSetupOffices(BankSetupOfficesModel body)
        {
            return Task.Run(async () => await CreateBankSetupOfficesAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSetupOfficesResponse> CreateBankSetupOfficesAsync(BankSetupOfficesModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupOfficesEndpoint.CreateBankSetupOfficesAsync();
            HttpResponseMessage response = null;
            bool disposeResponse = true;
            try
            {
                ApiStatus status = new ApiStatus();
                response = await PostResourceToEndpointAsync(endpoint, JsonConvert.SerializeObject(body), status, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                Dictionary<string, IEnumerable<string>> dictionary = BindHeaders(response);

                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        {
                            ObjectResponseResult<BankSetupOfficesResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSetupOfficesResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSetupOfficesResponse> objectResponseResult = await ReadObjectResponseAsync<BankSetupOfficesResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankSetupOfficesResponse result = JsonConvert.DeserializeObject<BankSetupOfficesResponse>(value);
                            UpdateApiStatus(result, status, response);
                            throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
                        }
                }
            }
            finally
            {
                if (disposeResponse)
                {
                    response.Dispose();
                }
            }
        }
        public virtual BankSetupOfficesResponse GetBankSetupOffices(short bankSetupOfficeId)
        {
            return Task.Run(async () => await GetBankSetupOfficesAsync(bankSetupOfficeId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSetupOfficesResponse> GetBankSetupOfficesAsync(short bankInsurancePoliciesTypeId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankInsurancePoliciesTypeId <= 0)
                throw new System.ArgumentNullException("bankSetupOfficeId");

            string endpoint = bankSetupOfficesEndpoint.GetBankSetupOfficesAsync(bankInsurancePoliciesTypeId);
            HttpResponseMessage response = null;
            var disposeResponse = true;
            try
            {
                ApiStatus status = new ApiStatus();

                response = await GetResourceFromEndpointAsync(endpoint, status, cancellationToken).ConfigureAwait(false);
                Dictionary<string, IEnumerable<string>> headers_ = BindHeaders(response);
                var status_ = (int)response.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupOfficesResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSetupOfficesResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupOfficesResponse typedBody = JsonConvert.DeserializeObject<BankSetupOfficesResponse>(responseData);
                    UpdateApiStatus(typedBody, status, response);
                    throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
                }
            }
            finally
            {
                if (disposeResponse)
                    response.Dispose();
            }
        }
        public virtual BankSetupOfficesResponse UpdateBankSetupOffices(BankSetupOfficesModel body)
        {
            return Task.Run(async () => await UpdateBankSetupOfficesAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSetupOfficesResponse> UpdateBankSetupOfficesAsync(BankSetupOfficesModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankSetupOfficesEndpoint.UpdateBankSetupOfficesAsync();
            HttpResponseMessage response = null;
            var disposeResponse = true;
            try
            {
                ApiStatus status = new ApiStatus();

                response = await PutResourceToEndpointAsync(endpoint, JsonConvert.SerializeObject(body), status, cancellationToken).ConfigureAwait(false);

                var headers_ = BindHeaders(response);
                var status_ = (int)response.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupOfficesResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupOfficesResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupOfficesResponse typedBody = JsonConvert.DeserializeObject<BankSetupOfficesResponse>(responseData);
                    UpdateApiStatus(typedBody, status, response);
                    throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
                }

            }
            finally
            {
                if (disposeResponse)
                    response.Dispose();
            }
        }
        public virtual TrueFalseResponse DeleteBankSetupOffices(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankSetupOfficesAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<TrueFalseResponse> DeleteBankSetupOfficesAsync(ParameterModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankSetupOfficesEndpoint.DeleteBankSetupOfficesAsync();
            HttpResponseMessage response = null;
            var disposeResponse = true;
            try
            {
                ApiStatus status = new ApiStatus();

                response = await PostResourceToEndpointAsync(endpoint, JsonConvert.SerializeObject(body), status, cancellationToken).ConfigureAwait(false);

                var headers_ = BindHeaders(response);
                var status_ = (int)response.StatusCode;
                if (status_ == 200)
                {
                    var objectResponse = await ReadObjectResponseAsync<TrueFalseResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    TrueFalseResponse typedBody = JsonConvert.DeserializeObject<TrueFalseResponse>(responseData);
                    UpdateApiStatus(typedBody, status, response);
                    throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
                }
            }
            finally
            {
                if (disposeResponse)
                    response.Dispose();
            }
        }
    }
}
