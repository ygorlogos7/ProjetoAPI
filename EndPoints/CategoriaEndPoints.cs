using Microsoft.EntityFrameworkCore;
using ProjetoAPI.Context;
using ProjetoAPI.DTO;
using ProjetoAPI.Model;

namespace ProjetoAPI.EndPoints
{
    public static class CategoriaEndPoints
    {
        public static void MapCategoriaEndpoints(this WebApplication app)
        {
            app.MapGet("/categorias", async (ProdutoDbContext db) =>
            {
                return await db.Categorias.ToListAsync();
            });

            app.MapPost("/categorias", async (Categoria cat, ProdutoDbContext db) =>
            {
                db.Categorias.Add(cat);
                await db.SaveChangesAsync();

                return Results.Created();

            });
        }
    }
}
