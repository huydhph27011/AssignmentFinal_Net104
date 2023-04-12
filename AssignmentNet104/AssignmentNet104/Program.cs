using Assignment.IServices;
using Assignment.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IMaterialService, MaterialService>();


// Configure the HTTP request pipeline.


//Set TimeSpan cho từng session
Dictionary<string, TimeSpan> sessionTimes =
    new Dictionary<string, TimeSpan>();

sessionTimes.Add("Material",new TimeSpan(0,0,10));
// Đăng kí Session


builder.Services.AddSession(options =>
{
    foreach (var key in sessionTimes.Keys)
    {
        TimeSpan duration;
        if (sessionTimes.TryGetValue(key, out duration))
        {
            options.IdleTimeout = duration;
        }
    }
});
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
