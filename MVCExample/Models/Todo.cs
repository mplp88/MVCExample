namespace MVCExample.Models
{
    public class Todo
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public bool Hecho { get; set; }
    }
}
