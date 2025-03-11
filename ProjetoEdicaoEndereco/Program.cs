using Microsoft.EntityFrameworkCore;
using ProjetoEdicaoEndereco.Data;
using ProjetoEdicaoEndereco.Repositories;
var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("ProjetoEdicaoEnderecoContext");

builder.Services.AddScoped<IIndividuoRepositorio, IndividuoRepositorio>();

builder.Services.AddDbContext<ProjetoEdicaoEnderecoContext>(
    options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)
));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20); // Tempo de inatividade da sessão (opcional)
    options.Cookie.HttpOnly = true; // Segurança do cookie (opcional)
    options.Cookie.IsEssential = true; // Define o cookie como essencial (opcional)
});

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}");

// Gera os dados fictícios
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ProjetoEdicaoEnderecoContext>();
    DadosFicticios.GerarDados(dbContext);
}

app.Run();
