using System;
using System.Collections.Generic;

namespace Proyecto_API_KevinRodriguez.Models;

public partial class Empleado
{
    public int EmpleadoId { get; set; }

    public string NombreE { get; set; } = null!;

    public string ApellidoE { get; set; } = null!;

    public string Cargo { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
