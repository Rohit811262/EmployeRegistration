using Microsoft.EntityFrameworkCore;
using Repository.DBEntities;
using Services.Interface;
using Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.   
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(Repository.AutoMapper.AutoMapperProfile));

builder.Services.AddScoped<IEmploye, Employe>();
builder.Services.AddDbContext<EmployeRegistrationTestDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
    pattern: "{controller=Employe}/{action=Create}/{id?}");

app.Run();
