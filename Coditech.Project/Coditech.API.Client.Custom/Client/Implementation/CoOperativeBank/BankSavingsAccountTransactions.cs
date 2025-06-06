using Coditech.API.Endpoint;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;
namespace Coditech.API.Client
{
    public class BankSavingsAccountTransactionsClient : BaseClient, IBankSavingsAccountTransactionsClient
    {
        BankSavingsAccountTransactionsEndpoint bankSavingsAccountTransactionsEndpoint = null;
        public BankSavingsAccountTransactionsClient()
        {
            bankSavingsAccountTransactionsEndpoint = new BankSavingsAccountTransactionsEndpoint();
        }

        public virtual BankSavingsAccountTransactionsResponse CreateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel body)
        {
            return Task.Run(async () => await CreateBankSavingsAccountTransactionsAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingsAccountTransactionsResponse> CreateBankSavingsAccountTransactionsAsync(BankSavingsAccountTransactionsModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSavingsAccountTransactionsEndpoint.CreateBankSavingsAccountTransactionsAsync();
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
                            ObjectResponseResult<BankSavingsAccountTransactionsResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSavingsAccountTransactionsResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSavingsAccountTransactionsResponse> objectResponseResult = await ReadObjectResponseAsync<BankSavingsAccountTransactionsResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankSavingsAccountTransactionsResponse result = JsonConvert.DeserializeObject<BankSavingsAccountTransactionsResponse>(value);
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
        public virtual BankSavingsAccountTransactionsResponse GetBankSavingsAccountTransactions(long bankSavingsAccountId)
        {
            return Task.Run(async () => await GetBankSavingsAccountTransactionsAsync(bankSavingsAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingsAccountTransactionsResponse> GetBankSavingsAccountTransactionsAsync(long bankSavingsAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankSavingsAccountId <= 0)
                throw new System.ArgumentNullException("bankSavingsAccountId");

            string endpoint = bankSavingsAccountTransactionsEndpoint.GetBankSavingsAccountTransactionsAsync(bankSavingsAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSavingsAccountTransactionsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSavingsAccountTransactionsResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSavingsAccountTransactionsResponse typedBody = JsonConvert.DeserializeObject<BankSavingsAccountTransactionsResponse>(responseData);
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
        public virtual BankSavingsAccountTransactionsResponse UpdateBankSavingsAccountTransactions(BankSavingsAccountTransactionsModel body)
        {
            return Task.Run(async () => await UpdateBankSavingsAccountTransactionsAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingsAccountTransactionsResponse> UpdateBankSavingsAccountTransactionsAsync(BankSavingsAccountTransactionsModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankSavingsAccountTransactionsEndpoint.UpdateBankSavingsAccountTransactionsAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankSavingsAccountTransactionsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSavingsAccountTransactionsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSavingsAccountTransactionsResponse typedBody = JsonConvert.DeserializeObject<BankSavingsAccountTransactionsResponse>(responseData);
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
