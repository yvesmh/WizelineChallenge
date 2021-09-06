using RestSharp;
using System.Net;
using System.Text.Json;

namespace WizelineChallenge.Client
{
    public class ClientResult
    {
        public bool IsSuccessful { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public string ErrorMessage { get; set; }

        public static ClientResult CreateResultFromRestSharpResponse(IRestResponse restResponse)
        {
            if (restResponse.IsSuccessful)
            {
                return new ClientResult
                {
                    IsSuccessful = true,
                    StatusCode = restResponse.StatusCode
                };
            }
            else
            {
                return new ClientResult
                {
                    IsSuccessful = false,
                    StatusCode = restResponse.StatusCode,
                    ErrorMessage = restResponse.ErrorMessage
                };
            }
        }
    }

    public class ClientResult<T> : ClientResult
    {
        public T Data { get; set; }

        public static ClientResult<T> CreateResultFromRestSharpResponse(IRestResponse<T> restResponse)
        {
            if (restResponse.IsSuccessful)
            {
                var responseData = JsonSerializer.Deserialize<T>(restResponse.Content);
                return new ClientResult<T>
                {
                    Data = responseData,
                    StatusCode = restResponse.StatusCode,
                    IsSuccessful = true
                };
            }
            else
            {
                return new ClientResult<T>
                {
                    Data = default,
                    StatusCode = restResponse.StatusCode,
                    IsSuccessful = false,
                    ErrorMessage = restResponse.ErrorMessage
                };
            }
        }
    }
}
