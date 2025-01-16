using Domain.Interfaces.ServiceAgent.DataContracts.Response;
using Infrastructure.ServiceAgent.Enum;
using System.Net.Http.Headers;

namespace Infrastructure.ServiceAgent
{
    public abstract class HttpAgentBase
    {
        protected HttpClient? Client;
        private static readonly object threadlock = new object();

        protected abstract void ConfigureHeaders();

        public async Task<OperationResponse<T>>? Requisitar<T>(string url)
        {
            ConfigureHeaders();
            OperationResponse<T>? myResponse = null;
            var response = await Client!.GetAsync(url);


            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                myResponse = new OperationResponse<T>()
                {
                    StatusCode = (int)response.StatusCode,
                    Data = await response.Content.ReadAsAsync<T>()
                };
                return myResponse;
            }
            return null!;
        }


        public async Task<OperationResponse<TResponse>>? Incluir<TRequest, TResponse>(string url, TRequest obj)
        {
            ConfigureHeaders();
            try
            {
                var response = await Client.PostAsJsonAsync(url, obj);
                response.EnsureSuccessStatusCode();
                var myResponse = new OperationResponse<TResponse>()
                {
                    StatusCode = (int)response.StatusCode,
                };

                return myResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<OperationResponse<TResponse>> Alterar<TRequest, TResponse>(string url, TRequest obj)
        {
            ConfigureHeaders();

            HttpResponseMessage response = await Client.PutAsJsonAsync(url, obj);
            response.EnsureSuccessStatusCode();

            var myResponse = new OperationResponse<TResponse>()
            {
                StatusCode = 201,
                Data = await response.Content.ReadAsAsync<TResponse>()
            };

            return myResponse;
        }

        public async Task<OperationResponse<T>> Excluir<T>(string url)
        {
            ConfigureHeaders();

            HttpResponseMessage response = await Client!.DeleteAsync(url);
            response.EnsureSuccessStatusCode();

            var myResponse = new OperationResponse<T>()
            {
                StatusCode = (int)response.StatusCode
            };

            return myResponse;
        }

        public void ConfigureBaseAddress(Uri baseAddress)
        {
            lock (threadlock)
            {
                if (Client == null)
                {
                    CreateBaseAddress(baseAddress);
                }
                else
                {
                    if (Client.BaseAddress!.AbsoluteUri.ToLowerInvariant() != baseAddress.AbsoluteUri.ToLowerInvariant())
                    {
                        Client.Dispose();
                        CreateBaseAddress(baseAddress);
                    }
                }
            }
        }

        private void CreateBaseAddress(Uri baseAddress)
        {
            Client = new HttpClient
            {
                BaseAddress = baseAddress
            };
            Client.DefaultRequestHeaders.Accept.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<OperationResponse<T>>? Persistir<T>(string url, Uri BaseAddress, object data, VerboHttp? verbo = VerboHttp.PUT, string token = "")
        {
            ConfigureHeaders();
            using (var requestClient = new HttpClient())
            {
                requestClient.BaseAddress = BaseAddress;
                requestClient.DefaultRequestHeaders.Accept.Clear();
                requestClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                if (!string.IsNullOrEmpty(token) && !string.IsNullOrWhiteSpace(token))
                    requestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                HttpResponseMessage? response = null;
                OperationResponse<T>? myResponse = null;

                if (!verbo.HasValue || verbo.Value == VerboHttp.PUT)
                    response = await requestClient.PutAsJsonAsync(url, data);
                else if (verbo.Value == VerboHttp.POST)
                {
                    response = await requestClient.PostAsJsonAsync(url, data);


                }



                else if (verbo.Value == VerboHttp.GET)
                    response = await requestClient.GetAsync(url);
                else
                    throw new ArgumentOutOfRangeException("Verbo indicado não é válido para a pesistência do dado, informar verbo POST ou PUT.");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    try
                    {
                        myResponse = new OperationResponse<T>()
                        {
                            StatusCode = (int)System.Net.HttpStatusCode.OK,
                            Data = await response.Content.ReadAsAsync<T>()
                        };
                    }
                    catch (Exception)
                    {

                        myResponse = new OperationResponse<T>()
                        {
                            StatusCode = (int)System.Net.HttpStatusCode.OK,
                        };
                    }


                }
                else if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    response.EnsureSuccessStatusCode();
                    myResponse = new OperationResponse<T>
                    {
                        StatusCode = (int)System.Net.HttpStatusCode.NoContent
                    };
                }

                return myResponse!;
            }
        }

        public async Task<OperationResponse<T>>? Obter<T>(string url, Uri BaseAddress, string token = "", AuthType? authType = AuthType.BEARER)
        {
            ConfigureHeaders();
            using (var requestClient = new HttpClient())
            {
                requestClient.BaseAddress = BaseAddress;
                requestClient.DefaultRequestHeaders.Accept.Clear();                


                if (!string.IsNullOrEmpty(token) && !string.IsNullOrWhiteSpace(token))
                    requestClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(authType == AuthType.BEARER ? "Bearer" : "Basic", token);

                HttpResponseMessage? response = null;
                OperationResponse<T>? myResponse = null;
                response = await requestClient.GetAsync(url);

                if (response?.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    response.EnsureSuccessStatusCode();
                    try
                    {
                        myResponse = new OperationResponse<T>()
                        {
                            StatusCode = (int)System.Net.HttpStatusCode.OK,
                            Data = await response.Content.ReadAsAsync<T>()
                        };
                    }
                    catch (Exception)
                    {

                        myResponse = new OperationResponse<T>()
                        {
                            StatusCode = (int)System.Net.HttpStatusCode.OK,
                        };
                    }


                }
                else if (response?.StatusCode == System.Net.HttpStatusCode.NoContent)
                {
                    response.EnsureSuccessStatusCode();
                    myResponse = new OperationResponse<T>
                    {
                        StatusCode = (int)System.Net.HttpStatusCode.NoContent
                    };
                }

                return myResponse!;
            }
        }
       
    }
}
