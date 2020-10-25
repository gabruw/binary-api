using System.Collections.Generic;

namespace Domain.DTO
{
    public class Response
    {
        public Response()
        {
            
        }

        public Response(List<string> errors)
        {
            this.Errors = errors;
            this.Observations = new List<string>();
        }

        public Response(List<string> errors, List<string> observations)
        {
            this.Errors = errors ?? new List<string>();
            this.Observations = observations ?? new List<string>();
        }

        public List<string> Errors { get; set; }
        public List<string> Observations { get; set; }
    }
}
