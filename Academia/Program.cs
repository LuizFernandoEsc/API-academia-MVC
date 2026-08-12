using Academia.Data;
using Academia.Repositório;
using Microsoft.EntityFrameworkCore;

// 1. INICIALIZAÇÃO DO BUILDER
var builder = WebApplication.CreateBuilder(args);

// 2. REGISTRO DE SERVIÇOS (Suporte a Controllers + Views)
builder.Services.AddControllersWithViews();

// Ligação com o Banco de Dados SQL Server
builder.Services.AddDbContext<BancoContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoPadrao")));
builder.Services.AddScoped<InterfaceUsuarioRepositório, UsuarioRepositório>();
// 3. CONSTRUÇÃO DA APLICAÇÃO
var app = builder.Build();

// 4. PIPELINE HTTP (Middlewares para MVC)
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Garante o carregamento de CSS, JS e imagens da pasta wwwroot

app.UseRouting();

app.UseAuthorization();

// Mapeamento de rotas padrão do MVC (Controller/Action/Id)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// 5. INICIAR A APLICAÇÃO
app.Run();