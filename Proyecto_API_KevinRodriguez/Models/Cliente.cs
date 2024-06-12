using System;
using System.Collections.Generic;

namespace Proyecto_API_KevinRodriguez.Models;

public partial class Cliente
{
    public int ClienteId { get; set; }

    public string NombreC { get; set; } = null!;

    public string ApellidoC { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public int Telefono { get; set; }

    public string Email { get; set; } = null!;

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
