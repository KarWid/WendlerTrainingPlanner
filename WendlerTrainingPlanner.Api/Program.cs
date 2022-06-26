using Microsoft.AspNetCore.Mvc;
using WendlerTrainingPlanner.Api.Helpers;
using WendlerTrainingPlanner.Api.Middleware;
using WendlerTrainingPlanner.Application.CQRS;
using WendlerTrainingPlanner.Infrastructure.EventStoreAndBus;
using WendlerTrainingPlanner.Infrastructure.EF;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddApiVersioning(o =>
{
    o.DefaultApiVersion = new ApiVersion(1, 0);
    o.AssumeDefaultVersionWhenUnspecified = true;
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

builder.Services.AddWendlerTrainingPlannerCQRS(builder.Configuration);
builder.Services.AddWendlerTrainingPlannerApi(builder.Configuration);

builder.Services.AddWendlerTrainingPlannerEFDbServices();
//builder.Services.AddHealthChecks().AddDbContextCheck<AppDbContext>(); // TODO

builder.Services.AddCqrsServices();
builder.Services.AddDefaultEventStore(); // TODO: just for testing
builder.Services.AddBusAndRepository(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Wendler Training Planner - API V1");
        c.RoutePrefix = string.Empty;
    });
}

//app.UseCors(builder => builder
//    .AllowAnyOrigin()
//    .AllowAnyMethod()
//    .AllowAnyHeader());
//app.UseMvc();

// TODO
//app.UseHttpsRedirection();

app.UseRouting();

app.UseErrorHandlingMiddleware();

app.UseAuthorization();

app.MapControllers();

app.Run();
