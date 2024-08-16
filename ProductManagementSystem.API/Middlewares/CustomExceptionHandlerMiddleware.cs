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
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(ex.Errors.Select(x => $"{x.PropertyName}: {x.ErrorMessage}"));
        }
        catch (DbUpdateException ex)
        {
            if(ex.InnerException.Message.Contains("Violation of PRIMARY KEY constraint 'PK_Products'. Cannot insert duplicate key in object 'dbo.Products'. The duplicate key value is"))
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await context.Response.WriteAsJsonAsync("The product with this 'ManufactureEmail' and 'ProduceDate' is already exist.");
            }
        }
        catch (Exception)
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

