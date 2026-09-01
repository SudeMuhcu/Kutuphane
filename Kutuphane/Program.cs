using Kutuphane.Context;
using Kutuphane.DataAccess.Repositories;
using Kutuphane.Models;
using Kutuphane.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IGenericDal<Book>, GenericRepository<Book>>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IGenericDal<Student>, GenericRepository<Student>>();
builder.Services.AddScoped<IGenericDal<Loan>, GenericRepository<Loan>>();
builder.Services.AddScoped<ILoanService, LoanService>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Login/Index";      
        options.AccessDeniedPath = "/Login/AccessDenied";
        //options.ExpireTimeSpan = TimeSpan.FromHours(8);
        //options.SlidingExpiration = true;
        options.ExpireTimeSpan = TimeSpan.FromSeconds(160);
        options.SlidingExpiration = false; 
    });


builder.Services.AddAuthorization();

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Loan}/{action=StudentLoans}/{id?}");

app.Run();