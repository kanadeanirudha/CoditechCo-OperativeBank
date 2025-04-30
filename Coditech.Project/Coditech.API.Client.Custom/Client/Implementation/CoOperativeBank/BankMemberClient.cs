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
    public class BankMemberClient : BaseClient, IBankMemberClient
    {
        BankMemberEndpoint bankMemberEndpoint = null;
        public BankMemberClient()
        {
            bankMemberEndpoint = new BankMemberEndpoint();
        }
        public virtual BankMemberListResponse List(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize)
        {
            return Task.Run(async () => await ListAsync(expand, filter, sort, pageIndex, pageSize, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankMemberListResponse> ListAsync(IEnumerable<string> expand, IEnumerable<FilterTuple> filter, IDictionary<string, string> sort, int? pageIndex, int? pageSize, CancellationToken cancellationToken)
        {
            string endpoint = bankMemberEndpoint.ListAsync(expand, filter, sort, pageIndex, pageSize);
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
                    var objectResponse = await ReadObjectResponseAsync<BankMemberListResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else if (status_ == 204)
                {
                    return new BankMemberListResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankMemberListResponse typedBody = JsonConvert.DeserializeObject<BankMemberListResponse>(responseData);
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

        public virtual BankMemberResponse CreateBankMember(BankMemberModel body)
        {
            return Task.Run(async () => await CreateBankMemberAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankMemberResponse> CreateBankMemberAsync(BankMemberModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankMemberEndpoint.CreateBankMemberAsync();
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
                            ObjectResponseResult<BankMemberResponse> objectResponseResult2 = await ReadObjectResponseAsync<BankMemberResponse>(response, BindHeaders(response), cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult2.Object == null)
                            {
                                throw new CoditechException(objectResponseResult2.Object.ErrorCode, objectResponseResult2.Object.ErrorMessage);
                            }

                            return objectResponseResult2.Object;
                        }
                    case HttpStatusCode.Created:
                        {
                            ObjectResponseResult<BankMemberResponse> objectResponseResult = await ReadObjectResponseAsync<BankMemberResponse>(response, dictionary, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
                            if (objectResponseResult.Object == null)
                            {
                                throw new CoditechException(objectResponseResult.Object.ErrorCode, objectResponseResult.Object.ErrorMessage);
                            }

                            return objectResponseResult.Object;
                        }
                    default:
                        {
                            string value = response.Content != null ? await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false) : null;
                            BankMemberResponse result = JsonConvert.DeserializeObject<BankMemberResponse>(value);
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

        //public virtual BankMemberResponse GetMemberOtherDetail(long employeeId)
        //{
        //    return Task.Run(async () => await GetMemberOtherDetailAsync(employeeId, CancellationToken.None)).GetAwaiter().GetResult();
        //}

        //public virtual async Task<BankMemberResponse> GetMemberOtherDetailAsync(long employeeId, CancellationToken cancellationToken)
        //{
        //    if (employeeId <= 0)
        //        throw new System.ArgumentNullException("employeeId");

        //    string endpoint = BankMemberEndpoint.GetMemberOtherDetailAsync(employeeId);
        //    HttpResponseMessage response = null;
        //    var disposeResponse = true;
        //    try
        //    {
        //        ApiStatus status = new ApiStatus();

        //        response = await GetResourceFromEndpointAsync(endpoint, status, cancellationToken).ConfigureAwait(false);
        //        Dictionary<string, IEnumerable<string>> headers_ = BindHeaders(response);
        //        var status_ = (int)response.StatusCode;
        //        if (status_ == 200)
        //        {
        //            var objectResponse = await ReadObjectResponseAsync<BankMemberResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
        //            if (objectResponse.Object == null)
        //            {
        //                throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
        //            }
        //            return objectResponse.Object;
        //        }
        //        else
        //        if (status_ == 204)
        //        {
        //            return new BankMemberResponse();
        //        }
        //        else
        //        {
        //            string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
        //            BankMemberResponse typedBody = JsonConvert.DeserializeObject<BankMemberResponse>(responseData);
        //            UpdateApiStatus(typedBody, status, response);
        //            throw new CoditechException(status.ErrorCode, status.ErrorMessage, status.StatusCode);
        //        }
        //    }
        //    finally
        //    {
        //        if (disposeResponse)
        //            response.Dispose();
        //    }
        //}

        public virtual BankMemberResponse GetBankMember(int bankMemberId)
        {
            return Task.Run(async () => await GetBankMemberAsync(bankMemberId, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankMemberResponse> GetBankMemberAsync(int bankMemberId, CancellationToken cancellationToken)
        {
            if (bankMemberId <= 0)
                throw new ArgumentNullException("bankMemberId");

            string endpoint = bankMemberEndpoint.GetBankMemberAsync(bankMemberId);
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
                    var objectResponse = await ReadObjectResponseAsync<BankMemberResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new BankMemberResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankMemberResponse typedBody = JsonConvert.DeserializeObject<BankMemberResponse>(responseData);
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

        public virtual BankMemberResponse UpdateBankMember(BankMemberModel body)
        {
            return Task.Run(async () => await UpdateBankMemberAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<BankMemberResponse> UpdateBankMemberAsync(BankMemberModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankMemberEndpoint.UpdateBankMemberAsync();
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
                    var objectResponse = await ReadObjectResponseAsync<BankMemberResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 201)
                {
                    var objectResponse = await ReadObjectResponseAsync<BankMemberResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    BankMemberResponse typedBody = JsonConvert.DeserializeObject<BankMemberResponse>(responseData);
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

        public virtual TrueFalseResponse DeleteBankMember(ParameterModel body)
        {
            return Task.Run(async () => await DeleteBankMemberAsync(body, CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<TrueFalseResponse> DeleteBankMemberAsync(ParameterModel body, CancellationToken cancellationToken)
        {
            string endpoint = bankMemberEndpoint.DeleteBankMemberAsync();
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
