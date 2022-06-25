using CommanderGQL.Data;
using CommanderGQL.Models;

namespace CommanderGQL.GraphQL 
{    
    public class ServerPayload
    {
        public ServerPayload(int code)
        {
            Code = code;
        }

        public ServerPayload(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }

        public string? Message { get; set; } = "Server message";

        public bool Ok { get {
            return Code == 200 || Code == 201;
        } }
    }
}