using TODO_API.Data;
using TODO_API.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(typeof(Program));

builder.Services.AddDbContext<TO_DO_LISTDB>();

//SERVICES

builder.Services.AddScoped<ICategoriasService, CategoriasService>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseCors(options =>
{
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    options.AllowAnyHeader();
});

app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.MapControllers();

app.Run();
