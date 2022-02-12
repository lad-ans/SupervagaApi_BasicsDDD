using Supervaga.Api.DI;

var builder = WebApplication.CreateBuilder(args);

// summary:
//      Custom Startup
Startup.Call(builder.Services, builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

// summary:
//      Swagger API Documentation
// summary
APIDocumentation.Add(builder.Services);

var app = builder.Build();

// if (builder.Environment.IsDevelopment())
// {
app.UseSwagger();
app.UseSwaggerUI(ui =>
{
    ui.SwaggerEndpoint("./v1/swagger.json", "API de Vagas");
});
// }

app.UseHttpsRedirection();

app.UseRouting();

// Cors
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

// Make Sure To Call
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
