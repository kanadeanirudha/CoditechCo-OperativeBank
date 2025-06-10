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
    public class BankRecurringDepositAccountClient : BaseClient, IBankRecurringDepositAccountClient
    {
        BankRecurringDepositAccountEndpoint bankRecurringDepositAccountEndpoint = null;
        public BankRecurringDepositAccountClient()
        {
            bankRecurringDepositAccountEndpoint = new BankRecurringDepositAccountEndpoint();
        }
        public virtual BankRecurringDepositAccountListResponse List(string centreCode,IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(centreCode,expand, filter, sort, pageIndex, pageSize, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositAccountListResponse> ListAsync(string centreCode,IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.ListAsync(centreCode,expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositAccountListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankRecurringDepositAccountListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankRecurringDepositAccountListResponse typedBody = JsonConvert.DeserializeObject<BankRecurringDepositAccountListResponse>(responseData);
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

        public virtual BankRecurringDepositAccountResponse CreateBankRecurringDepositAccount(BankRecurringDepositAccountModel body)
        {
            return Task.Run(async () => await CreateBankRecurringDepositAccountAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositAccountResponse> CreateBankRecurringDepositAccountAsync(BankRecurringDepositAccountModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.CreateBankRecurringDepositAccountAsync();
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
                            ObjectResponseResult<BankRecurringDepositAccountResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankRecurringDepositAccountResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankRecurringDepositAccountResponse> objectResponseResult = await ReadObjectResponseAsync<BankRecurringDepositAccountResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankRecurringDepositAccountResponse result = JsonConvert.DeserializeObject<BankRecurringDepositAccountResponse>(value);
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
        public virtual BankRecurringDepositAccountResponse GetBankRecurringDepositAccount(int bankRecurringDepositAccountId)
        {
            return Task.Run(async () => await GetBankRecurringDepositAccountAsync(bankRecurringDepositAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositAccountResponse> GetBankRecurringDepositAccountAsync(int bankRecurringDepositAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankRecurringDepositAccountId <= 0)
                throw new System.ArgumentNullException("bankRecurringDepositAccountId");

            string endpoint = bankRecurringDepositAccountEndpoint.GetBankRecurringDepositAccountAsync(bankRecurringDepositAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync< BankRecurringDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankRecurringDepositAccountResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankRecurringDepositAccountResponse typedBody = JsonConvert.DeserializeObject<BankRecurringDepositAccountResponse>(responseData);
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
        public virtual BankRecurringDepositAccountResponse UpdateBankRecurringDepositAccount(BankRecurringDepositAccountModel body)
        {
            return Task.Run(async () => await UpdateBankRecurringDepositAccountAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositAccountResponse> UpdateBankRecurringDepositAccountAsync(BankRecurringDepositAccountModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.UpdateBankRecurringDepositAccountAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankRecurringDepositAccountResponse typedBody = JsonConvert.DeserializeObject<BankRecurringDepositAccountResponse>(responseData);
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
        public virtual TrueFalseResponse DeleteBankRecurringDepositAccount(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankRecurringDepositAccountAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<TrueFalseResponse> DeleteBankRecurringDepositAccountAsync(ParameterModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.DeleteBankRecurringDepositAccountAsync();
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

        #region BankRecurringDepositClosure
        public virtual BankRecurringDepositClosureResponse CreateBankRecurringDepositClosure(BankRecurringDepositClosureModel body)
        {
            return Task.Run(async () => await CreateBankRecurringDepositClosureAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositClosureResponse> CreateBankRecurringDepositClosureAsync(BankRecurringDepositClosureModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.CreateBankRecurringDepositClosureAsync();
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
                            ObjectResponseResult<BankRecurringDepositClosureResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankRecurringDepositClosureResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankRecurringDepositClosureResponse> objectResponseResult = await ReadObjectResponseAsync<BankRecurringDepositClosureResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankRecurringDepositClosureResponse result = JsonConvert.DeserializeObject<BankRecurringDepositClosureResponse>(value);
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
        public virtual BankRecurringDepositClosureResponse GetBankRecurringDepositClosure(int bankRecurringDepositAccountId)
        {
            return Task.Run(async () => await GetBankRecurringDepositClosureAsync(bankRecurringDepositAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositClosureResponse> GetBankRecurringDepositClosureAsync(int bankRecurringDepositAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankRecurringDepositAccountId <= 0)
                throw new System.ArgumentNullException("bankRecurringDepositAccountId");

            string endpoint = bankRecurringDepositAccountEndpoint.GetBankRecurringDepositClosureAsync(bankRecurringDepositAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankRecurringDepositClosureResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankRecurringDepositClosureResponse typedBody = JsonConvert.DeserializeObject<BankRecurringDepositClosureResponse>(responseData);
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
        public virtual BankRecurringDepositClosureResponse UpdateBankRecurringDepositClosure(BankRecurringDepositClosureModel body)
        {
            return Task.Run(async () => await UpdateBankRecurringDepositClosureAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankRecurringDepositClosureResponse> UpdateBankRecurringDepositClosureAsync(BankRecurringDepositClosureModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankRecurringDepositAccountEndpoint.UpdateBankRecurringDepositClosureAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankRecurringDepositClosureResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankRecurringDepositClosureResponse typedBody = JsonConvert.DeserializeObject<BankRecurringDepositClosureResponse>(responseData);
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
