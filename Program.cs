
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Context;
using ProjetoAPI.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var stringConexao = "Data Source=Produtos.db";
builder.Services.AddSqlite<ProdutoDbContext>(stringConexao);// Passando informacoes para banco de dados 

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Async  - Assincromo
app.MapGet("/produtos", async (ProdutoDbContext db) =>
{
   return await db.Produtos.ToListAsync();
});

//Todo Cadastro  - POST 
app.MapPost("/produtos", static async (Produto pto, ProdutoDbContext  db) =>
{
    db.Produtos.Add(pto);
    // EF - SaveChanges
    await db.SaveChangesAsync();

    return Results.Created();
});

static DbSet<Produto> Add(Produto pto)
{
    throw new NotImplementedException();
}

// GET - Listagem de produtos - "/Listarprodutos"
app.MapGet("/listarprodutos", async ( ProdutoDbContext db) =>
{

    return await db.Produtos.ToListAsync();
});

// POST - Cadastro de Produtos - "/cadastrarprodutos"
app.MapPost("/cadastrarprodutos", static async (Produto cadastropto, ProdutoDbContext db) =>
{
    db.Produtos.Add(cadastropto);
    // EF - SaveChanges
    await db.SaveChangesAsync();

    return Results.Created();
});

app.Run();

