using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjetoEmprestimosLivroCurso.Data;
using ProjetoEmprestimosLivroCurso.Services.Autenticacao;
using ProjetoEmprestimosLivroCurso.Services.EmprestimoService;
using ProjetoEmprestimosLivroCurso.Services.HomeService;
using ProjetoEmprestimosLivroCurso.Services.LivroService;
using ProjetoEmprestimosLivroCurso.Services.RelatorioService;
using ProjetoEmprestimosLivroCurso.Services.SessaoService;
using ProjetoEmprestimosLivroCurso.Services.UsuarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped< ILivroInterface, LivroService  >();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoInterface, AutenticacaoService>();
builder.Services.AddScoped<ISessaoInterface, SessaoService>();
builder.Services.AddScoped<IHomeInterface, HomeService>();
builder.Services.AddScoped<IEmprestimoInterface, EmprestimoService>();
builder.Services.AddScoped<IRelatorioInterface, RelatorioService>();

builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
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

app.UseSession();       

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
