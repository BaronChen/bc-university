using System;
using System.Net;
using System.Threading.Tasks;
using BCUniversity.Domain.Exceptions;
using BCUniversity.Service.Exceptions;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BCUniversity.Api.Common
{
    //extremely simple error handler
    public class ErrorHandler
    {
        private readonly RequestDelegate _next;

        public ErrorHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                var response = context.Response;
               
                response.ContentType = "application/json";
                if (ex is DomainValidationException || ex is InvalidInputException)
                {
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                }else if (ex is ResourceNotFoundException)
                {
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                }
                else
                {
                    throw;
                }
                
                await response.WriteAsync(JsonConvert.SerializeObject(new 
                {
                    message = ex.Message
                }));
            }
        }
    }
}