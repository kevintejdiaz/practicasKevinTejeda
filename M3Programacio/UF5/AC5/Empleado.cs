public class Empleado : IEntidad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Puesto { get; set; }
    
    public override string ToString()
    {
        return $"ID: {Id}, Nombre: {Nombre}, Puesto: {Puesto}";
    }
}