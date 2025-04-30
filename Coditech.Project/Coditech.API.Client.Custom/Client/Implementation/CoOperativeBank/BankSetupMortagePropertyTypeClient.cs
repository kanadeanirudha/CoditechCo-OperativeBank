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
    public class BankSetupMortagePropertyTypeClient : BaseClient, IBankSetupMortagePropertyTypeClient
    {
        BankSetupMortagePropertyTypeEndpoint bankSetupMortagePropertyTypeEndpoint = null;
        public BankSetupMortagePropertyTypeClient()
        {
            bankSetupMortagePropertyTypeEndpoint = new BankSetupMortagePropertyTypeEndpoint();
        }
        public virtual BankSetupMortagePropertyTypeListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupMortagePropertyTypeListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupMortagePropertyTypeEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankSetupMortagePropertyTypeListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupMortagePropertyTypeListResponse typedBody = JsonConvert.DeserializeObject<BankSetupMortagePropertyTypeListResponse>(responseData);
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

        public virtual BankSetupMortagePropertyTypeResponse CreatePropertyType(BankSetupMortagePropertyTypeModel body)
        {
            return Task.Run(async () => await CreatePropertyTypeAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupMortagePropertyTypeResponse> CreatePropertyTypeAsync(BankSetupMortagePropertyTypeModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupMortagePropertyTypeEndpoint.CreatePropertyTypeAsync();
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
                            ObjectResponseResult<BankSetupMortagePropertyTypeResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSetupMortagePropertyTypeResponse> objectResponseResult = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = response.Content != null ? await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false) : null;
                            BankSetupMortagePropertyTypeResponse result = JsonConvert.DeserializeObject<BankSetupMortagePropertyTypeResponse>(value);
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

        public virtual BankSetupMortagePropertyTypeResponse GetPropertyType(short bankSetupMortagePropertyTypeId)
        {
            return Task.Run(async () => await GetPropertyTypeAsync(bankSetupMortagePropertyTypeId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupMortagePropertyTypeResponse> GetPropertyTypeAsync(short bankSetupMortagePropertyTypeId, CancellationToken cancellationToken)
        {
            if (bankSetupMortagePropertyTypeId <= 0)
                throw new ArgumentNullException("bankSetupMortagePropertyTypeId");

            string endpoint = bankSetupMortagePropertyTypeEndpoint.GetPropertyTypeAsync(bankSetupMortagePropertyTypeId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSetupMortagePropertyTypeResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupMortagePropertyTypeResponse typedBody = JsonConvert.DeserializeObject<BankSetupMortagePropertyTypeResponse>(responseData);
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

        public virtual BankSetupMortagePropertyTypeResponse UpdatePropertyType(BankSetupMortagePropertyTypeModel body)
        {
            return Task.Run(async () => await UpdatePropertyTypeAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupMortagePropertyTypeResponse> UpdatePropertyTypeAsync(BankSetupMortagePropertyTypeModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupMortagePropertyTypeEndpoint.UpdatePropertyTypeAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupMortagePropertyTypeResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupMortagePropertyTypeResponse typedBody = JsonConvert.DeserializeObject<BankSetupMortagePropertyTypeResponse>(responseData);
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

        public virtual TrueFalseResponse DeletePropertyType(ParameterModel body)
        {
            return Task.Run(async () => await DeletePropertyTypeAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<TrueFalseResponse> DeletePropertyTypeAsync(ParameterModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupMortagePropertyTypeEndpoint.DeletePropertyTypeAsync();
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
