namespace AutoMapper;
using TODO_API.Data.Models;
using TODO_API.DataTransferObjects;

public class CategoriasMapper : Profile
{
    public CategoriasMapper()
    {
        CreateMap<Categorias, GetCategoriasDTO>();
    }
}
