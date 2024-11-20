using Chirper.Components;
using Chirper.Data;
using Chirper.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped<ChirpService>();
builder.Services.AddControllers(); // Add MVC controllers
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=chirps.db"));
    


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.UseRouting();
app.UseAntiforgery(); //Has to go after UseRouting()

app.MapControllers(); // Enable API controllers

app.Run();
