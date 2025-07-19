using Crm.Tenant.Data;
using Microsoft.AspNetCore.Http;

public class TransactionUnitMiddleware
{
    private readonly RequestDelegate _next;

    public TransactionUnitMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, IUnitOfWork unitOfWork)
    {
        string httpVerb = httpContext.Request.Method.ToUpper();

        if (httpVerb == "POST" || httpVerb == "PUT" || httpVerb == "DELETE")
        {
            try
            {
                await unitOfWork.BeginTransactionAsync();

                await _next(httpContext);

                await unitOfWork.CommitTransactionAsync();
            }
            catch(Exception)
            {
                await unitOfWork.RollbackTransactionAsync();
                return;
            }
        }
        else
        {
            await _next(httpContext);
        }
    }
}
