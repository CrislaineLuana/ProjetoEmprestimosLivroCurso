using Microsoft.EntityFrameworkCore;
using ProjetoEmprestimosLivroCurso.Data;
using ProjetoEmprestimosLivroCurso.Services.Autenticacao;
using ProjetoEmprestimosLivroCurso.Services.LivroService;
using ProjetoEmprestimosLivroCurso.Services.UsuarioService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped< ILivroInterface, LivroService  >();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IAutenticacaoInterface, AutenticacaoService>();

builder.Services.AddAutoMapper(typeof(Program));

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
    pattern: "{controller=Livro}/{action=Index}/{id?}");

app.Run();
