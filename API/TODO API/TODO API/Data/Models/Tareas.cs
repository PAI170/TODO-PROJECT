using System;
using System.Collections.Generic;

namespace TODO_API.Data.Models;

public partial class Tareas
{
    public int CategoriasId { get; set; }

    public string Descripcion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual Categorias Categorias { get; set; } = null!;
}
