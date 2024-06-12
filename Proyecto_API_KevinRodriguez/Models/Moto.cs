using System;
using System.Collections.Generic;

namespace Proyecto_API_KevinRodriguez.Models;

public partial class Moto
{
    public int MotoId { get; set; }

    public string Modelo { get; set; } = null!;

    public string Marca { get; set; } = null!;

    public int Año { get; set; }

    public int Precio { get; set; }

    public string Color { get; set; } = null!;

    public string Tipo { get; set; } = null!;

    public string Estado { get; set; } = null!;

    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();

    public virtual ICollection<Ventum> Venta { get; set; } = new List<Ventum>();
}
