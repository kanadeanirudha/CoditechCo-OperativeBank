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
    public class BankFixedDepositAccountClient : BaseClient, IBankFixedDepositAccountClient
    {
        BankFixedDepositAccountEndpoint bankFixedDepositAccountEndpoint = null;
        public BankFixedDepositAccountClient()
        {
            bankFixedDepositAccountEndpoint = new BankFixedDepositAccountEndpoint();
        }
        #region BankFixedDepositAccount
        public virtual BankFixedDepositAccountListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositAccountListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositAccountListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankFixedDepositAccountListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositAccountListResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositAccountListResponse>(responseData);
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
        public virtual BankFixedDepositAccountResponse CreateBankFixedDepositAccount(BankFixedDepositAccountModel body)
        {
            return Task.Run(async () => await CreateBankFixedDepositAccountAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositAccountResponse> CreateBankFixedDepositAccountAsync(BankFixedDepositAccountModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.CreateBankFixedDepositAccountAsync();
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
                            ObjectResponseResult<BankFixedDepositAccountResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankFixedDepositAccountResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankFixedDepositAccountResponse> objectResponseResult = await ReadObjectResponseAsync<BankFixedDepositAccountResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankFixedDepositAccountResponse result = JsonConvert.DeserializeObject<BankFixedDepositAccountResponse>(value);
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
        public virtual BankFixedDepositAccountResponse GetBankFixedDepositAccount(short bankFixedDepositAccountId)
        {
            return Task.Run(async () => await GetBankFixedDepositAccountAsync(bankFixedDepositAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositAccountResponse> GetBankFixedDepositAccountAsync(short bankFixedDepositAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankFixedDepositAccountId <= 0)
                throw new System.ArgumentNullException("bankFixedDepositAccountId");

            string endpoint = bankFixedDepositAccountEndpoint.GetBankFixedDepositAccountAsync(bankFixedDepositAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankFixedDepositAccountResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositAccountResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositAccountResponse>(responseData);
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
        public virtual BankFixedDepositAccountResponse UpdateBankFixedDepositAccount(BankFixedDepositAccountModel body)
        {
            return Task.Run(async () => await UpdateBankFixedDepositAccountAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositAccountResponse> UpdateBankFixedDepositAccountAsync(BankFixedDepositAccountModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.UpdateBankFixedDepositAccountAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositAccountResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositAccountResponse>(responseData);
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
        public virtual TrueFalseResponse DeleteBankFixedDepositAccount(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankFixedDepositAccountAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<TrueFalseResponse> DeleteBankFixedDepositAccountAsync(ParameterModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.DeleteBankFixedDepositAccountAsync();
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
        #endregion
        #region BankFixedDepositClosure

        public virtual BankFixedDepositClosureResponse CreateBankFixedDepositClosure(BankFixedDepositClosureModel body)
        {
            return Task.Run(async () => await CreateBankFixedDepositClosureAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositClosureResponse> CreateBankFixedDepositClosureAsync(BankFixedDepositClosureModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.CreateBankFixedDepositClosureAsync();
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
                            ObjectResponseResult<BankFixedDepositClosureResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankFixedDepositClosureResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankFixedDepositClosureResponse> objectResponseResult = await ReadObjectResponseAsync<BankFixedDepositClosureResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankFixedDepositClosureResponse result = JsonConvert.DeserializeObject<BankFixedDepositClosureResponse>(value);
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
        public virtual BankFixedDepositClosureResponse GetBankFixedDepositClosure(short bankFixedDepositAccountId)
        {
            return Task.Run(async () => await GetBankFixedDepositClosureAsync(bankFixedDepositAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositClosureResponse> GetBankFixedDepositClosureAsync(short bankFixedDepositAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankFixedDepositAccountId <= 0)
                throw new System.ArgumentNullException("bankFixedDepositAccountId");

            string endpoint = bankFixedDepositAccountEndpoint.GetBankFixedDepositClosureAsync(bankFixedDepositAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankFixedDepositClosureResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositClosureResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositClosureResponse>(responseData);
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
        public virtual BankFixedDepositClosureResponse UpdateBankFixedDepositClosure(BankFixedDepositClosureModel body)
        {
            return Task.Run(async () => await UpdateBankFixedDepositClosureAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositClosureResponse> UpdateBankFixedDepositClosureAsync(BankFixedDepositClosureModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.UpdateBankFixedDepositClosureAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositClosureResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositClosureResponse>(responseData);
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

        #endregion
        #region BankFixedDepositInterestPostings
        public virtual BankFixedDepositInterestPostingsResponse CreateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsModel body)
        {
            return Task.Run(async () => await CreateBankFixedDepositInterestPostingsAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositInterestPostingsResponse> CreateBankFixedDepositInterestPostingsAsync(BankFixedDepositInterestPostingsModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.CreateBankFixedDepositInterestPostingsAsync();
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
                            ObjectResponseResult<BankFixedDepositInterestPostingsResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankFixedDepositInterestPostingsResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankFixedDepositInterestPostingsResponse> objectResponseResult = await ReadObjectResponseAsync<BankFixedDepositInterestPostingsResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankFixedDepositInterestPostingsResponse result = JsonConvert.DeserializeObject<BankFixedDepositInterestPostingsResponse>(value);
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
        public virtual BankFixedDepositInterestPostingsResponse GetBankFixedDepositInterestPostings(short bankFixedDepositAccountId)
        {
            return Task.Run(async () => await GetBankFixedDepositInterestPostingsAsync(bankFixedDepositAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositInterestPostingsResponse> GetBankFixedDepositInterestPostingsAsync(short bankFixedDepositAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankFixedDepositAccountId <= 0)
                throw new System.ArgumentNullException("bankFixedDepositAccountId");

            string endpoint = bankFixedDepositAccountEndpoint.GetBankFixedDepositInterestPostingsAsync(bankFixedDepositAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositInterestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankFixedDepositInterestPostingsResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositInterestPostingsResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositInterestPostingsResponse>(responseData);
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
        public virtual BankFixedDepositInterestPostingsResponse UpdateBankFixedDepositInterestPostings(BankFixedDepositInterestPostingsModel body)
        {
            return Task.Run(async () => await UpdateBankFixedDepositInterestPostingsAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankFixedDepositInterestPostingsResponse> UpdateBankFixedDepositInterestPostingsAsync(BankFixedDepositInterestPostingsModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankFixedDepositAccountEndpoint.UpdateBankFixedDepositInterestPostingsAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositInterestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankFixedDepositInterestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankFixedDepositInterestPostingsResponse typedBody = JsonConvert.DeserializeObject<BankFixedDepositInterestPostingsResponse>(responseData);
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

        #endregion
    }
}
