using TODO_API.Data.Models;
using TODO_API.Data;

namespace TODO_API.Services
{
    public class CategoriasService : ICategoriasService
    {
        private readonly TO_DO_LISTDB _database;
        public CategoriasService(TO_DO_LISTDB database)
        {
            this._database = database;
        }

        public IQueryable<Categorias> ListCategorias()
        {
            return this._database
                        .Categorias;
        }
    }
}
