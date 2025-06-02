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
    public class BankPostingLoanAccountClient : BaseClient, IBankPostingLoanAccountClient
    {
        BankPostingLoanAccountEndpoint bankPostingLoanAccountEndpoint = null;
        public BankPostingLoanAccountClient()
        {
            bankPostingLoanAccountEndpoint = new BankPostingLoanAccountEndpoint();
        }
        public virtual BankPostingLoanAccountListResponse List(string centreCode, int bankMemberId, IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(centreCode,bankMemberId, expand, filter, sort, pageIndex, pageSize, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankPostingLoanAccountListResponse> ListAsync(string centreCode, int bankMemberId, IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.ListAsync(centreCode, bankMemberId, expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankPostingLoanAccountListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankPostingLoanAccountListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankPostingLoanAccountListResponse typedBody = JsonConvert.DeserializeObject<BankPostingLoanAccountListResponse>(responseData);
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

        public virtual BankPostingLoanAccountResponse CreatePostingLoanAccount(BankPostingLoanAccountModel body)
        {
            return Task.Run(async () => await CreatePostingLoanAccountAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankPostingLoanAccountResponse> CreatePostingLoanAccountAsync(BankPostingLoanAccountModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.CreatePostingLoanAccountAsync();
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
                            ObjectResponseResult<BankPostingLoanAccountResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankPostingLoanAccountResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankPostingLoanAccountResponse> objectResponseResult = await ReadObjectResponseAsync<BankPostingLoanAccountResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankPostingLoanAccountResponse result = JsonConvert.DeserializeObject<BankPostingLoanAccountResponse>(value);
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

        public virtual BankPostingLoanAccountResponse GetPostingLoanAccount(int bankPostingLoanAccountId)
        {
            return Task.Run(async () => await GetPostingLoanAccountAsync(bankPostingLoanAccountId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankPostingLoanAccountResponse> GetPostingLoanAccountAsync(int bankPostingLoanAccountId, CancellationToken cancellationToken)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new ArgumentNullException("BankPostingLoanAccountId");

            string endpoint = bankPostingLoanAccountEndpoint.GetPostingLoanAccountAsync(bankPostingLoanAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankPostingLoanAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankPostingLoanAccountResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankPostingLoanAccountResponse typedBody = JsonConvert.DeserializeObject<BankPostingLoanAccountResponse>(responseData);
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

        public virtual BankPostingLoanAccountResponse UpdatePostingLoanAccount(BankPostingLoanAccountModel body)
        {
            return Task.Run(async () => await UpdatePostingLoanAccountAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankPostingLoanAccountResponse> UpdatePostingLoanAccountAsync(BankPostingLoanAccountModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.UpdatePostingLoanAccountAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankPostingLoanAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankPostingLoanAccountResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankPostingLoanAccountResponse typedBody = JsonConvert.DeserializeObject<BankPostingLoanAccountResponse>(responseData);
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

        public virtual TrueFalseResponse DeletePostingLoanAccount(ParameterModel body)
        {
            return Task.Run(async () => await DeletePostingLoanAccountAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<TrueFalseResponse> DeletePostingLoanAccountAsync(ParameterModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.DeletePostingLoanAccountAsync();
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
        #region BankLoanForeClosures
        public virtual BankLoanForeClosuresResponse CreateBankLoanForeClosures(BankLoanForeClosuresModel body)
        {
            return Task.Run(async () => await CreateBankLoanForeClosuresAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankLoanForeClosuresResponse> CreateBankLoanForeClosuresAsync(BankLoanForeClosuresModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.CreateBankLoanForeClosuresAsync();
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
                            ObjectResponseResult<BankLoanForeClosuresResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankLoanForeClosuresResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankLoanForeClosuresResponse> objectResponseResult = await ReadObjectResponseAsync<BankLoanForeClosuresResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankLoanForeClosuresResponse result = JsonConvert.DeserializeObject<BankLoanForeClosuresResponse>(value);
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

        public virtual BankLoanForeClosuresResponse GetBankLoanForeClosures(int bankPostingLoanAccountId)
        {
            return Task.Run(async () => await GetBankLoanForeClosuresAsync(bankPostingLoanAccountId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankLoanForeClosuresResponse> GetBankLoanForeClosuresAsync(int bankPostingLoanAccountId, CancellationToken cancellationToken)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new ArgumentNullException("BankPostingLoanAccountId");

            string endpoint = bankPostingLoanAccountEndpoint.GetBankLoanForeClosuresAsync(bankPostingLoanAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanForeClosuresResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankLoanForeClosuresResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanForeClosuresResponse typedBody = JsonConvert.DeserializeObject<BankLoanForeClosuresResponse>(responseData);
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

        public virtual BankLoanForeClosuresResponse UpdateBankLoanForeClosures(BankLoanForeClosuresModel body)
        {
            return Task.Run(async () => await UpdateBankLoanForeClosuresAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankLoanForeClosuresResponse> UpdateBankLoanForeClosuresAsync(BankLoanForeClosuresModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.UpdateBankLoanForeClosuresAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanForeClosuresResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankLoanForeClosuresResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanForeClosuresResponse typedBody = JsonConvert.DeserializeObject<BankLoanForeClosuresResponse>(responseData);
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

        public virtual BankLoanRepaymentResponse GetLoanRepayment(int bankPostingLoanAccountId)
        {
            return Task.Run(async () => await GetLoanRepaymentAsync(bankPostingLoanAccountId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankLoanRepaymentResponse> GetLoanRepaymentAsync(int bankPostingLoanAccountId, CancellationToken cancellationToken)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new ArgumentNullException("BankPostingLoanAccountId");

            string endpoint = bankPostingLoanAccountEndpoint.GetLoanRepaymentAsync(bankPostingLoanAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanRepaymentResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankLoanRepaymentResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanRepaymentResponse typedBody = JsonConvert.DeserializeObject<BankLoanRepaymentResponse>(responseData);
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

        public virtual BankLoanRepaymentResponse UpdateLoanRepayment(BankLoanRepaymentModel body)
        {
            return Task.Run(async () => await UpdateLoanRepaymentAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankLoanRepaymentResponse> UpdateLoanRepaymentAsync(BankLoanRepaymentModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankPostingLoanAccountEndpoint.UpdateLoanRepaymentAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanRepaymentResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankLoanRepaymentResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanRepaymentResponse typedBody = JsonConvert.DeserializeObject<BankLoanRepaymentResponse>(responseData);
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
