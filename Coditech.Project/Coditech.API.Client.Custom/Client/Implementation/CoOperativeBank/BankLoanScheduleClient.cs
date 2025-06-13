using Coditech.API.Endpoint;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Newtonsoft.Json;
using System.Net;
namespace Coditech.API.Client
{
    public class BankLoanScheduleClient : BaseClient, IBankLoanScheduleClient
    {
        BankLoanScheduleEndpoint bankLoanScheduleEndpoint = null;
        public BankLoanScheduleClient()
        {
            bankLoanScheduleEndpoint = new BankLoanScheduleEndpoint();
        }

        public virtual BankLoanScheduleResponse CreateBankLoanSchedule(BankLoanScheduleModel body)
        {
            return Task.Run(async () => await CreateBankLoanScheduleAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankLoanScheduleResponse> CreateBankLoanScheduleAsync(BankLoanScheduleModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankLoanScheduleEndpoint.CreateBankLoanScheduleAsync();
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
                            ObjectResponseResult<BankLoanScheduleResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankLoanScheduleResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankLoanScheduleResponse> objectResponseResult = await ReadObjectResponseAsync<BankLoanScheduleResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankLoanScheduleResponse result = JsonConvert.DeserializeObject<BankLoanScheduleResponse>(value);
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
        public virtual BankLoanScheduleResponse GetBankLoanSchedule(int bankPostingLoanAccountId)
        {
            return Task.Run(async () => await GetBankLoanScheduleAsync(bankPostingLoanAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankLoanScheduleResponse> GetBankLoanScheduleAsync(int bankPostingLoanAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankPostingLoanAccountId <= 0)
                throw new System.ArgumentNullException("bankPostingLoanAccountId");

            string endpoint = bankLoanScheduleEndpoint.GetBankLoanScheduleAsync(bankPostingLoanAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanScheduleResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankLoanScheduleResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanScheduleResponse typedBody = JsonConvert.DeserializeObject<BankLoanScheduleResponse>(responseData);
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
        public virtual BankLoanScheduleResponse UpdateBankLoanSchedule(BankLoanScheduleModel body)
        {
            return Task.Run(async () => await UpdateBankLoanScheduleAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankLoanScheduleResponse> UpdateBankLoanScheduleAsync(BankLoanScheduleModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankLoanScheduleEndpoint.UpdateBankLoanScheduleAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankLoanScheduleResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankLoanScheduleResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankLoanScheduleResponse typedBody = JsonConvert.DeserializeObject<BankLoanScheduleResponse>(responseData);
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
