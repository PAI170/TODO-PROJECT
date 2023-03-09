using TODO_API.Data.Models;

namespace TODO_API.Services
{
    public interface ICategoriasService
    {
        IQueryable<Categorias> ListCategorias();
    }
}
