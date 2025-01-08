public class Videojuego
{
    public string Titulo { get; set; }
    public int AnioLanzamiento { get; set; }
    public string Tematica { get; set; }
    public string EstudioDesarrollo { get; set; }
    public int VecesAlquilado { get; private set; } = 0;

    public void IncrementarAlquiler()
    {
        VecesAlquilado++;
    }
}
