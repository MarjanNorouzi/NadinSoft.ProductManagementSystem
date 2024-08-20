namespace ProductManagementSystem.API.Middlewares;

public class CustomExceptionHandlerMiddleware(RequestDelegate next)
{
    public RequestDelegate Next { get; set; } = next;

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
                context.Response.StatusCode = ex.StatusCode;
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
        catch (DbUpdateException ex)
        {
            if ((ex.InnerException as Microsoft.Data.SqlClient.SqlException).Number == 2627)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsJsonAsync("The product with this 'ManufactureEmail' and 'ProduceDate' is already exist.");
            }
            else
            {
                await UnHandleError(context);
            }
        }
        catch (Exception ex)
        {
            await UnHandleError(context);
        }
    }

    private static async Task UnHandleError(HttpContext context)
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        await context.Response.WriteAsJsonAsync("InternalServerError");
    }
}

