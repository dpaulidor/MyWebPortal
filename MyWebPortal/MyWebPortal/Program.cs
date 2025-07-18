using MonPortailWeb.Services; // Ajoutez cette ligne


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// <<< AJOUTEZ CETTE LIGNE
builder.Services.AddHttpClient<AgifyService>();
builder.Services.AddHttpClient<IpInfoService>(); // <<< AJOUTEZ CETTE LIGNE
// builder.Services.AddHttpClient<AlphaVantageService>(); // Vous pouvez commenter ou supprimer cette ligne si vous ne l'utilisez plus
builder.Services.AddHttpClient<CoinGeckoService>(); // <<< AJOUTEZ CETTE LIGNE

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

app.Run();
