using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TallerMecanico.Models;

public class TipoServicio
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nombre { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal PrecioBase { get; set; }

    // Relación 1:N con OrdenServicio
    public ICollection<OrdenServicio> OrdenesServicio { get; set; } = new List<OrdenServicio>();
}

public class Cliente
{
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Paterno { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Materno { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string Nombres { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Correo { get; set; }

    [MaxLength(20)]
    public string? Telefono { get; set; }

    // Relación 1:N con Vehiculo
    public ICollection<Vehiculo> Vehiculos { get; set; } = new List<Vehiculo>();
}

public class Vehiculo
{
    public int Id { get; set; }

    [Required]
    [MaxLength(10)]
    public string Placa { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Marca { get; set; } = string.Empty;

    [Required]
    [MaxLength(50)]
    public string Modelo { get; set; } = string.Empty;

    public int Anio { get; set; }

    // Clave Foránea
    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;

    // Relación 1:N con OrdenServicio
    public ICollection<OrdenServicio> OrdenesServicio { get; set; } = new List<OrdenServicio>();
}

public class OrdenServicio
{
    public int Id { get; set; }

    public DateTime FechaIngreso { get; set; }

    [Required]
    public string DescripcionProblema { get; set; } = string.Empty;

    [Column(TypeName = "decimal(10,2)")]
    public decimal CostoEstimado { get; set; }

    [Required]
    [MaxLength(20)]
    public string Estado { get; set; } = "Pendiente";

    // Claves Foráneas
    public int VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; } = null!;

    public int TipoServicioId { get; set; }
    public TipoServicio TipoServicio { get; set; } = null!;
}
