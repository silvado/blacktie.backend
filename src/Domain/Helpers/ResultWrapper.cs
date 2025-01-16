namespace Domain.Helpers
{

    public class ResultWrapper<T>
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public StatusType Status { get; private set; } = StatusType.Ok;
        public T Data { get; set; }

        public ResultWrapper()
        {

        }
        public ResultWrapper(T item)
        {
            Data = item;
        }
        public void AddWarning(string message)
        {
            Status = StatusType.Warning;
            Success = true;
            Messages.Add(message);
        }

        public void AddError(string message)
        {
            Status = StatusType.Failed;
            Success = false;
            Messages.Add(message);
        }

        public void AddSuccess(string message)
        {
            Status = StatusType.Ok;
            Success = true;
            Messages.Add(message);
        }
        public void AddSuccess(T item, string message)
        {
            Data = item;
            Status = StatusType.Ok;
            Success = true;
            Messages.Add(message);
        }

        public void AddWarning(List<string> messages)
        {
            Status = StatusType.Warning;
            Success = true;
            Messages.AddRange(messages);
        }
    }
    public enum StatusType
    {
        Ok,
        Warning,
        Failed
    }

}
