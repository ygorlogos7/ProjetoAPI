using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Context;
using ProjetoAPI.DTO;
using ProjetoAPI.Model;

namespace ProjetoAPI.NovaPasta
{
    public  static class ProdutosEndPoints
    {
        public static void MapProdutosEndpoints(this WebApplication app)
        {
            app.MapGet("/produtos", async (ProdutoDbContext db) =>
            {
                return await db.Produtos.ToListAsync();
            });

            //Todo Cadastro  - POST 
            app.MapPost("/produtos", static async (ProdutoDTO pto, ProdutoDbContext db) =>
            {

                var produto = new Produto()
                {
                    Nome = pto.Nome,
                    Valor = pto.Valor,
                    Descricao = pto.Descricao,
                    CategoriaId = pto.CategoriaId
                };

                db.Produtos.Add(produto);
                // EF - SaveChanges
                await db.SaveChangesAsync();

                return Results.Created();

            });

            app.MapGet("/produtos/{id}", static async (Guid id, ProdutoDbContext db) =>
            {
                return await db.Produtos.FindAsync(id);
                // Find, First or Default
            });

            // Deletar e Editar
            app.MapDelete("/produtos/{id}", async (Guid id, ProdutoDbContext db) =>
            {
                var produtoEncontrado = await db.Produtos.FindAsync(id);

                if (produtoEncontrado is null) return Results.NotFound();

                db.Produtos.Remove(produtoEncontrado);
                await db.SaveChangesAsync();
                return Results.Ok(produtoEncontrado);

            });

            app.MapPut("/produtos/{id}", async (Guid id, Produto prod, ProdutoDbContext db) =>
            {
                var produtoEncontrado = await db.Produtos.FindAsync(id);

                if (produtoEncontrado is null) return Results.NotFound();

                produtoEncontrado.Nome = prod.Nome;
                produtoEncontrado.Valor = prod.Valor;
                produtoEncontrado.Descricao = prod.Descricao;
                produtoEncontrado.CategoriaId = prod.CategoriaId;

                await db.SaveChangesAsync();

                return Results.Ok(produtoEncontrado);
            });
        }
    }
}
