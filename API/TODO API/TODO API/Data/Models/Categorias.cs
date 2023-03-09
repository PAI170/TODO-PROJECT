using System;
using System.Collections.Generic;

namespace TODO_API.Data.Models;

public partial class Categorias
{
    public int CategoriasId { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Tareas> Tareas { get; } = new List<Tareas>();
}
