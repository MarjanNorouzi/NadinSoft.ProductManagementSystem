using System.Net;

namespace ProductManagementSystem.API.Middlewares;

public class CustomExceptionHandlerMiddleware
{
    public CustomExceptionHandlerMiddleware(RequestDelegate next)
    {
        Next = next;
    }

    public RequestDelegate Next { get; set; }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await Next(context);
        }
        catch (Application.Exceptions.ApplicationException ex)
        {
            if (ex.IsConfidentiality == false)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                await context.Response.WriteAsJsonAsync(ex.Message);
            }
            else
            {
                await UnHandleError(context);
            }
        }
        catch (FluentValidation.ValidationException ex)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            await context.Response.WriteAsJsonAsync(ex.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"));
        }
        catch (Exception ex)
        {
            await UnHandleError(context);
        }
    }

    private static async Task UnHandleError(HttpContext context)
    {
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsJsonAsync("InternalServerError");
    }
}

