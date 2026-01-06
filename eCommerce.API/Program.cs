using eCommerce.API.MiddleWares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.InfraStructure;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Add services here
builder.Services.AddInfraStructure();

builder.Services.AddCore();

//Add routing to the solution
builder.Services.AddControllers().AddJsonOptions(
    options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });

builder.Services.AddAutoMapper(typeof(
    ApplicationUserMappingProfile).Assembly);

//Adding Fluent validation for Model
builder.Services.AddFluentValidationAutoValidation();

//Add api explorer services
builder.Services.AddEndpointsApiExplorer();

//Add Swagger Generation services to generate swagger specification
builder.Services.AddSwaggerGen();


//Add cors

builder.Services.AddCors(
    options => {
        options.AddDefaultPolicy(builder =>
        {
            builder.WithOrigins("http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
    }
    );
//Build app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
app.UseSwagger();//Adds endpoints to the swagger.json
app.UseSwaggerUI(); // UI for the swagger page

app.UseCors();// Used for the others apps to work like angular
//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routings
app.MapControllers();

app.Run();
