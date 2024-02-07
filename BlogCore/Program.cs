using BlogCore.AccesoDatos.Data.Inicializador;
using BlogCore.AccesoDatos.Data.Repository;
using BlogCore.AccesoDatos.Data.Repository.IRepository;
using BlogCore.Data;
using BlogCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("ConexionSQL") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI();
builder.Services.AddControllersWithViews();

#region Configuracion Cors 

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder.WithOrigins("http://dominio-permitido.com")
               .AllowAnyHeader()
               .AllowAnyMethod(); // Aquí permitimos cualquier método, incluyendo DELETE.
    });
});

#endregion

//Agregar contenedor de trabajo
builder.Services.AddScoped<IContenedorTrabajo, ContenedorTrabajo>();

// siembra de datos 1 
builder.Services.AddScoped<IInicializadorDB, InicializadorDB>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsProduction())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

// metodo que ejecuta la siembra de datos 
SiembraDeDatos();


#region Usar Cors
app.UseCors("AllowSpecificOrigin");

#endregion

app.UseRouting();

app.UseAuthorization();




app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Cliente}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();







// funcionalidad metodo SiembraDeDatos();
void SiembraDeDatos()
{
    using (var scope = app.Services.CreateScope())
    { 
      var inicializadorDb = scope.ServiceProvider.GetRequiredService<IInicializadorDB>();
        inicializadorDb.Inicializar();
    }
}