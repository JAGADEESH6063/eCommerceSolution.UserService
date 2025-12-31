using eCommerce.API.MiddleWares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.InfraStructure;
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

//Build app
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

//Auth
app.UseAuthentication();
app.UseAuthorization();

//Controller Routings
app.MapControllers();

app.Run();
