namespace Core.Utilities.Results
{
    public interface IResult
    {         
        bool Success { get; set; }
        string Message { get; set; }

        Dictionary<string,string> MessageList { get; set; }

        int StatusCode { get; set; }
    }
}
