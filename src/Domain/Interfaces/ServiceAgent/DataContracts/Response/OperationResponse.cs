namespace Domain.Interfaces.ServiceAgent.DataContracts.Response
{
    public class OperationResponse<T>
    {
        public T? Data { get; set; }
        public int StatusCode { get; set; }
    }
}
