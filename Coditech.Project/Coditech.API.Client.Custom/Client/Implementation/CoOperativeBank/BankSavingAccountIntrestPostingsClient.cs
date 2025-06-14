﻿using Coditech.API.Endpoint;
using Coditech.Common.API.Model;
using Coditech.Common.API.Model.Response;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;
using Coditech.Common.Helper.Utilities;
using Newtonsoft.Json;
using System.Net;
namespace Coditech.API.Client
{
    public class BankSavingAccountIntrestPostingsClient : BaseClient, IBankSavingAccountIntrestPostingsClient
    {
        BankSavingAccountIntrestPostingsEndpoint bankSavingAccountIntrestPostingsEndpoint = null;
        public BankSavingAccountIntrestPostingsClient()
        {
            bankSavingAccountIntrestPostingsEndpoint = new BankSavingAccountIntrestPostingsEndpoint();
        }
        public virtual BankSavingAccountIntrestPostingsListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingAccountIntrestPostingsListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankSavingAccountIntrestPostingsEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankSavingAccountIntrestPostingsListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSavingAccountIntrestPostingsListResponse typedBody = JsonConvert.DeserializeObject<BankSavingAccountIntrestPostingsListResponse>(responseData);
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
        public virtual BankSavingAccountIntrestPostingsResponse CreateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel body)
        {
            return Task.Run(async () => await CreateBankSavingAccountIntrestPostingsAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingAccountIntrestPostingsResponse> CreateBankSavingAccountIntrestPostingsAsync(BankSavingAccountIntrestPostingsModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankSavingAccountIntrestPostingsEndpoint.CreateBankSavingAccountIntrestPostingsAsync();
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
                            ObjectResponseResult<BankSavingAccountIntrestPostingsResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankSavingAccountIntrestPostingsResponse> objectResponseResult = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = ((response.Content != null) ? (await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false)) : null);
                            BankSavingAccountIntrestPostingsResponse result = JsonConvert.DeserializeObject<BankSavingAccountIntrestPostingsResponse>(value);
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
        public virtual BankSavingAccountIntrestPostingsResponse GetBankSavingAccountIntrestPostings(int bankSavingsAccountId)
        {
            return Task.Run(async () => await GetBankSavingAccountIntrestPostingsAsync(bankSavingsAccountId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingAccountIntrestPostingsResponse> GetBankSavingAccountIntrestPostingsAsync(int bankSavingsAccountId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankSavingsAccountId <= 0)
                throw new System.ArgumentNullException("bankSavingsAccountId");

            string endpoint = bankSavingAccountIntrestPostingsEndpoint.GetBankSavingAccountIntrestPostingsAsync(bankSavingsAccountId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankSavingAccountIntrestPostingsResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSavingAccountIntrestPostingsResponse typedBody = JsonConvert.DeserializeObject<BankSavingAccountIntrestPostingsResponse>(responseData);
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
        public virtual BankSavingAccountIntrestPostingsResponse UpdateBankSavingAccountIntrestPostings(BankSavingAccountIntrestPostingsModel body)
        {
            return Task.Run(async () => await UpdateBankSavingAccountIntrestPostingsAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<BankSavingAccountIntrestPostingsResponse> UpdateBankSavingAccountIntrestPostingsAsync(BankSavingAccountIntrestPostingsModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankSavingAccountIntrestPostingsEndpoint.UpdateBankSavingAccountIntrestPostingsAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankSavingAccountIntrestPostingsResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankSavingAccountIntrestPostingsResponse typedBody = JsonConvert.DeserializeObject<BankSavingAccountIntrestPostingsResponse>(responseData);
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
        public virtual TrueFalseResponse DeleteBankSavingAccountIntrestPostings(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankSavingAccountIntrestPostingsAsync(body, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }
        public virtual async Task<TrueFalseResponse> DeleteBankSavingAccountIntrestPostingsAsync(ParameterModel body, System.Threading.CancellationToken cancellationToken)
        {
            string endpoint = bankSavingAccountIntrestPostingsEndpoint.DeleteBankSavingAccountIntrestPostingsAsync();
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
