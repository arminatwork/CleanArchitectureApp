using CA.Todos.Application;
using CA.Todos.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

string connectionStrings = builder.Configuration.GetConnectionString("TodoConnection");

// Add services to the container.
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();

builder.Services.AddInfrastructure(connectionStrings);
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
