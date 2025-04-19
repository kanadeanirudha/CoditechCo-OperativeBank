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
    public class BankSetupPropertyValuersAuthorityClient : BaseClient, IBankSetupPropertyValuersAuthorityClient
    {
        BankSetupPropertyValuersAuthorityEndpoint bankSetupPropertyValuersAuthorityEndpoint = null;
        public BankSetupPropertyValuersAuthorityClient()
        {
            bankSetupPropertyValuersAuthorityEndpoint = new BankSetupPropertyValuersAuthorityEndpoint();
        }
        public virtual BankSetupPropertyValuersAuthorityListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersAuthorityListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersAuthorityEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankSetupPropertyValuersAuthorityListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersAuthorityListResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersAuthorityListResponse>(responseData);
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

        public virtual BankSetupPropertyValuersAuthorityResponse CreatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel body)
        {
            return Task.Run(async () => await CreatePropertyValuersAuthorityAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersAuthorityResponse> CreatePropertyValuersAuthorityAsync(BankSetupPropertyValuersAuthorityModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersAuthorityEndpoint.CreatePropertyValuersAuthorityAsync();
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
                            ObjectResponseResult<BankSetupPropertyValuersAuthorityResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSetupPropertyValuersAuthorityResponse> objectResponseResult = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = response.Content != null ? await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false) : null;
                            BankSetupPropertyValuersAuthorityResponse result = JsonConvert.DeserializeObject<BankSetupPropertyValuersAuthorityResponse>(value);
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

        public virtual BankSetupPropertyValuersAuthorityResponse GetPropertyValuersAuthority(short bankSetupPropertyValuersAuthorityId)
        {
            return Task.Run(async () => await GetPropertyValuersAuthorityAsync(bankSetupPropertyValuersAuthorityId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersAuthorityResponse> GetPropertyValuersAuthorityAsync(short bankSetupPropertyValuersAuthorityId, CancellationToken cancellationToken)
        {
            if (bankSetupPropertyValuersAuthorityId <= 0)
                throw new ArgumentNullException("bankSetupPropertyValuersAuthorityId");

            string endpoint = bankSetupPropertyValuersAuthorityEndpoint.GetPropertyValuersAuthorityAsync(bankSetupPropertyValuersAuthorityId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSetupPropertyValuersAuthorityResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersAuthorityResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersAuthorityResponse>(responseData);
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

        public virtual BankSetupPropertyValuersAuthorityResponse UpdatePropertyValuersAuthority(BankSetupPropertyValuersAuthorityModel body)
        {
            return Task.Run(async () => await UpdatePropertyValuersAuthorityAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersAuthorityResponse> UpdatePropertyValuersAuthorityAsync(BankSetupPropertyValuersAuthorityModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersAuthorityEndpoint.UpdatePropertyValuersAuthorityAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersAuthorityResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersAuthorityResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersAuthorityResponse>(responseData);
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

        public virtual TrueFalseResponse DeletePropertyValuersAuthority(ParameterModel body)
        {
            return Task.Run(async () => await DeletePropertyValuersAuthorityAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<TrueFalseResponse> DeletePropertyValuersAuthorityAsync(ParameterModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersAuthorityEndpoint.DeletePropertyValuersAuthorityAsync();
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
