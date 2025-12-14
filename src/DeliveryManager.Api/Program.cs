using DeliveryManager.Api.Endpoints;
using DeliveryManager.Application;
using DeliveryManager.Infrastructure;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var feature = context.Features.Get<IExceptionHandlerFeature>();
        var exception = feature?.Error;

        context.Response.ContentType = "application/json";

        var statusCode = StatusCodes.Status500InternalServerError;
        var type = "server_error";
        var title = "Unexpected error";
        var detail = "An unexpected error occurred.";

        /*
        if (exception is BusinessException bex)
        {
            context.Response.StatusCode = bex.StatusCode;

            await context.Response.WriteAsJsonAsync(new
            {
                type = "business_error",
                title = bex.Message,
                status = bex.StatusCode
            });

            return;
        }
        */

        /*
        if (exception is DbUpdateException dbEx &&
            dbEx.InnerException is PostgresException pgEx &&
            pgEx.SqlState == "23505")
        {
            statusCode = StatusCodes.Status409Conflict;
            type = "duplicate_measurement";
            title = "Duplicate measurement";
            detail = "A measurement with the same Code and Timestamp already exists.";
        }
        */

        context.Response.StatusCode = statusCode;

        var problem = new ProblemDetails
        {
            Type = type,
            Title = title,
            Detail = detail,
            Status = statusCode
        };

        await context.Response.WriteAsJsonAsync(problem);
    });
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

//Endpoints
app.MapDeliveryEndpoints();
app.MapResidentEndpoints();

app.Run();