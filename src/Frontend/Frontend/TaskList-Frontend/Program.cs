using TaskList_Frontend.Services.TaskListApi.Controllers;
using TaskList_Frontend.Services.TaskListApi.Interface;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IUserControllers, UserControllers>();

builder.Services.AddScoped<ITaskListControllers, TaskListControllers>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=AccountRegistration}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Authorization}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=Index}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=TaskListAdd}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=Status}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=StatusEror}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=TaskList}/{action=ChangeTask}");


app.Run();
