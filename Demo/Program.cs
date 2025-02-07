using Demo.Repositories.DBModels;
using Demo.Repositories.Repositories;
using Demo.Services.OGImageService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DbConnectonString");

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DBContext
builder.Services.AddDbContext<DemoContext>(options => options.UseSqlServer(connectionString));

// Add EFRepository
builder.Services.AddScoped(typeof(IRepository<>), typeof(EFRepository<>));

// Add OGImageService
builder.Services.AddScoped<IOGImageService, OGImageService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Page}/{pagename=1A}");

app.MapPageRoute("oneA", "1A")
   .MapPageRoute("twoB", "2B")
   .MapPageRoute("threeB", "3B")
   .MapPageRoute("fourA", "4A")
   .MapPageRoute("fiveC", "5C");

app.Run();
