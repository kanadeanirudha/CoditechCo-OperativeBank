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
    public class BankSetupPropertyValuersClient : BaseClient, IBankSetupPropertyValuersClient
    {
        BankSetupPropertyValuersEndpoint bankSetupPropertyValuersEndpoint = null;
        public BankSetupPropertyValuersClient()
        {
            bankSetupPropertyValuersEndpoint = new BankSetupPropertyValuersEndpoint();
        }
        public virtual BankSetupPropertyValuersListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankSetupPropertyValuersListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersListResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersListResponse>(responseData);
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

        public virtual BankSetupPropertyValuersResponse CreatePropertyValuers(BankSetupPropertyValuersModel body)
        {
            return Task.Run(async () => await CreatePropertyValuersAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersResponse> CreatePropertyValuersAsync(BankSetupPropertyValuersModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersEndpoint.CreatePropertyValuersAsync();
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
                            ObjectResponseResult<BankSetupPropertyValuersResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSetupPropertyValuersResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSetupPropertyValuersResponse> objectResponseResult = await ReadObjectResponseAsync<BankSetupPropertyValuersResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = response.Content != null ? await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false) : null;
                            BankSetupPropertyValuersResponse result = JsonConvert.DeserializeObject<BankSetupPropertyValuersResponse>(value);
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

        public virtual BankSetupPropertyValuersResponse GetPropertyValuers(long generalPersonAddressId)
        {
            return Task.Run(async () => await GetPropertyValuersAsync(generalPersonAddressId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersResponse> GetPropertyValuersAsync(long generalPersonAddressId, CancellationToken cancellationToken)
        {
            if (generalPersonAddressId <= 0)
                throw new ArgumentNullException("bankSetupPropertyValuersId");

            string endpoint = bankSetupPropertyValuersEndpoint.GetPropertyValuersAsync(generalPersonAddressId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSetupPropertyValuersResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersResponse>(responseData);
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

        public virtual BankSetupPropertyValuersResponse UpdatePropertyValuers(BankSetupPropertyValuersModel body)
        {
            return Task.Run(async () => await UpdatePropertyValuersAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankSetupPropertyValuersResponse> UpdatePropertyValuersAsync(BankSetupPropertyValuersModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersEndpoint.UpdatePropertyValuersAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSetupPropertyValuersResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSetupPropertyValuersResponse typedBody = JsonConvert.DeserializeObject<BankSetupPropertyValuersResponse>(responseData);
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

        public virtual TrueFalseResponse DeletePropertyValuers(ParameterModel body)
        {
            return Task.Run(async () => await DeletePropertyValuersAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<TrueFalseResponse> DeletePropertyValuersAsync(ParameterModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSetupPropertyValuersEndpoint.DeletePropertyValuersAsync();
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
