namespace DataBase.Models
{
    public class Priority
    {
        public int Id { get; set; }
        public string Type { get; set; }

        public Priority() { }
        public Priority(string type)
        {
            Type = type;
        }

        public override string ToString()
        => $"Type: {Type}";
    }
}
