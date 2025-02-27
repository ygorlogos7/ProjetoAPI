
using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Context;
using ProjetoAPI.Model;
using ProjetoAPI.NovaPasta;

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

app.MapProdutosEndpoints();

app.Run();

// Async  - Assincromo

// GET - Listagem de produtos - "/Listarprodutos"
//app.MapGet("/listarprodutos", async ( ProdutoDbContext db) =>
//{

//    return await db.Produtos.ToListAsync();
//});

//// POST - Cadastro de Produtos - "/cadastrarprodutos"
//app.MapPost("/cadastrarprodutos", static async (Produto cadastropto, ProdutoDbContext db) =>
//{
//    db.Produtos.Add(cadastropto);
//    // EF - SaveChanges
//    await db.SaveChangesAsync();

//    return Results.Created();
//});

//await db.Produtos.FirstOrDefault( proudto => produto.Nome == "X")

//Autenticacao da API
//[roles = "Administrador"]



