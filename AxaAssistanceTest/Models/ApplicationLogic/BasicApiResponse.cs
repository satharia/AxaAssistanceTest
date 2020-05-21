namespace AxaAssistanceTest.Models.ApplicationLogic
{
    /// <summary>
    /// Wrapper class used to return and object and a message in a HTTP response.
    /// </summary>
    public class BasicApiResponse
    {
        public string Message { get; set; }
        public object Data { get; set; }
    }
}