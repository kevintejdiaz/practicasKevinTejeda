public class Cliente : IEntidad
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    
    public override string ToString()
    {
        return $"ID: {Id}, Cliente: {Nombre}";
    }
}