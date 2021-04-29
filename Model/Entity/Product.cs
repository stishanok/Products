namespace Model.Entity
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Calorific { get; set; }

        public Product()
        {
            
        }

        public Product(string name, string type, string color, int calorific)
        {
            Name = name;
            Type = type;
            Color = color;
            Calorific = calorific;
        }

        public override string ToString()
        {
            return $"Name: {Name}, " +
                   $"Type: {Type}, " +
                   $"Color: {Color}, " +
                   $"Calorific: {Calorific.ToString()}";
        }
    }
}