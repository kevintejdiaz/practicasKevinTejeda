public class Producto : IEntidad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public decimal Precio { get; set; }
    
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Precio: {Precio:C}";
    }
}