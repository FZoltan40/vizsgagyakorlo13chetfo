using System;
using System.Collections.Generic;

namespace Farkas_Zoltán_backend.Models;

public partial class FilmType
{
    public int TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
}
