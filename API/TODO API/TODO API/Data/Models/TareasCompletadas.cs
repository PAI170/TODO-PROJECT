using System;
using System.Collections.Generic;

namespace TODO_API.Data.Models;

public partial class TareasCompletadas
{
    public DateTime FechaCompletada { get; set; }

    public string Descripcion { get; set; } = null!;

    public int CategoriasId { get; set; }

    public virtual Categorias Categorias { get; set; } = null!;

    public virtual Tareas DescripcionNavigation { get; set; } = null!;
}
