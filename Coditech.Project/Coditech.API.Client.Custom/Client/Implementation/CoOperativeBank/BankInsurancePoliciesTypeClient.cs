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
    public class BankInsurancePoliciesTypeClient : BaseClient, IBankInsurancePoliciesTypeClient
    {
        BankInsurancePoliciesTypeEndpoint bankInsurancePoliciesTypeEndpoint = null;
        public BankInsurancePoliciesTypeClient()
        {
            bankInsurancePoliciesTypeEndpoint = new BankInsurancePoliciesTypeEndpoint();
        }
        public virtual BankInsurancePoliciesTypeListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankInsurancePoliciesTypeListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankInsurancePoliciesTypeEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankInsurancePoliciesTypeListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankInsurancePoliciesTypeListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankInsurancePoliciesTypeListResponse typedBody = JsonConvert.DeserializeObject<BankInsurancePoliciesTypeListResponse>(responseData);
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
        public virtual BankInsurancePoliciesTypeResponse CreateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel body)
        {
            return Task.Run(async () => await CreateBankInsurancePoliciesTypeAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankInsurancePoliciesTypeResponse> CreateBankInsurancePoliciesTypeAsync(BankInsurancePoliciesTypeModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankInsurancePoliciesTypeEndpoint.CreateBankInsurancePoliciesTypeAsync();
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
                            ObjectResponseResult<BankInsurancePoliciesTypeResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankInsurancePoliciesTypeResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankInsurancePoliciesTypeResponse> objectResponseResult = await ReadObjectResponseAsync<BankInsurancePoliciesTypeResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankInsurancePoliciesTypeResponse result = JsonConvert.DeserializeObject<BankInsurancePoliciesTypeResponse>(value);
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
        public virtual BankInsurancePoliciesTypeResponse GetBankInsurancePoliciesType(short bankInsurancePoliciesTypeId)
        {
            return Task.Run(async () => await GetBankInsurancePoliciesTypeAsync(bankInsurancePoliciesTypeId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankInsurancePoliciesTypeResponse> GetBankInsurancePoliciesTypeAsync(short bankInsurancePoliciesTypeId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankInsurancePoliciesTypeId <= 0)
                throw new System.ArgumentNullException("bankInsurancePoliciesTypeId");

            string endpoint = bankInsurancePoliciesTypeEndpoint.GetBankInsurancePoliciesTypeAsync(bankInsurancePoliciesTypeId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankInsurancePoliciesTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankInsurancePoliciesTypeResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankInsurancePoliciesTypeResponse typedBody = JsonConvert.DeserializeObject<BankInsurancePoliciesTypeResponse>(responseData);
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
        public virtual BankInsurancePoliciesTypeResponse UpdateBankInsurancePoliciesType(BankInsurancePoliciesTypeModel body)
        {
            return Task.Run(async () => await UpdateBankInsurancePoliciesTypeAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankInsurancePoliciesTypeResponse> UpdateBankInsurancePoliciesTypeAsync(BankInsurancePoliciesTypeModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankInsurancePoliciesTypeEndpoint.UpdateBankInsurancePoliciesTypeAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankInsurancePoliciesTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankInsurancePoliciesTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankInsurancePoliciesTypeResponse typedBody = JsonConvert.DeserializeObject<BankInsurancePoliciesTypeResponse>(responseData);
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
        public virtual TrueFalseResponse DeleteBankInsurancePoliciesType(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankInsurancePoliciesTypeAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<TrueFalseResponse> DeleteBankInsurancePoliciesTypeAsync(ParameterModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankInsurancePoliciesTypeEndpoint.DeleteBankInsurancePoliciesTypeAsync();
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
