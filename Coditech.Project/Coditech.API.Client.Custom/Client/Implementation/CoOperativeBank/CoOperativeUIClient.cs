using Coditech.API.Endpoint;
using Coditech.Common.API.Model.Responses;
using Coditech.Common.Exceptions;

using Newtonsoft.Json;

namespace Coditech.API.Client
{
    public partial class CoOperativeUIClient : BaseClient, ICoOperativeUIClient
    {
        CoOperativeUIEndpoint coOperativeUIEndpoint = null;
        public CoOperativeUIClient()
        {
            coOperativeUIEndpoint = new CoOperativeUIEndpoint();
        }

        public virtual CoOperativeUIResponse GetCoOperativeUIDetails(int selectedBalanceSheeetId)
        {
            return Task.Run(async () => await GetCoOperativeUIDetailsAsync(selectedBalanceSheeetId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<CoOperativeUIResponse> GetCoOperativeUIDetailsAsync(int selectedBalanceSheeetId, System.Threading.CancellationToken cancellationToken)
        {
            if (selectedBalanceSheeetId <= 0)
                throw new System.ArgumentNullException("selectedBalanceSheeetId");

            string endpoint = coOperativeUIEndpoint.GetCoOperativeUIDetailsAsync(selectedBalanceSheeetId);
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
                    var objectResponse = await ReadObjectResponseAsync<CoOperativeUIResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new CoOperativeUIResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CoOperativeUIResponse typedBody = JsonConvert.DeserializeObject<CoOperativeUIResponse>(responseData);
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

        public virtual CoOperativeUIResponse GetCoOperativeUI(int bankMemberId, int navbarEnumId)
        {
            return Task.Run(async () => await GetCoOperativeUIAsync(bankMemberId, navbarEnumId, System.Threading.CancellationToken.None)).GetAwaiter().GetResult();
        }

        public virtual async Task<CoOperativeUIResponse> GetCoOperativeUIAsync(int bankMemberId, int navbarEnumId, System.Threading.CancellationToken cancellationToken)
        {
            if (bankMemberId <= 0)
                throw new System.ArgumentNullException("bankMemberId");

            string endpoint = coOperativeUIEndpoint.GetCoOperativeUIAsync(bankMemberId, navbarEnumId);
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
                    var objectResponse = await ReadObjectResponseAsync<CoOperativeUIResponse>(response, headers_, cancellationToken).ConfigureAwait(false);
                    if (objectResponse.Object == null)
                    {
                        throw new CoditechException(objectResponse.Object.ErrorCode, objectResponse.Object.ErrorMessage);
                    }
                    return objectResponse.Object;
                }
                else
                if (status_ == 204)
                {
                    return new CoOperativeUIResponse();
                }
                else
                {
                    string responseData = response.Content == null ? null : await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    CoOperativeUIResponse typedBody = JsonConvert.DeserializeObject<CoOperativeUIResponse>(responseData);
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