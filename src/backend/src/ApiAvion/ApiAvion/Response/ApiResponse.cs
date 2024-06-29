using System.Net;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiAvion.Response;

public class ApiResponse<T>
{
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
    public bool Success { get; set; }
    public HttpStatusCode StatusCode { get; set; }

    public ApiResponse()
    {
        ErrorMessage = "";
        Success = true;
        StatusCode = HttpStatusCode.OK;
    }

    public void SetError(string errorMessage, HttpStatusCode statusCode)
    {
        Success = false;
        ErrorMessage = errorMessage;
        StatusCode = statusCode;
    }
}