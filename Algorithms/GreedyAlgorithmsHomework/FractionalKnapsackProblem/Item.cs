namespace FractionalKnapsackProblem
{
    public class Item
    {
        public Item(int price, int weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price { get; set; }

        public int Weight { get; set; }
    }
}
