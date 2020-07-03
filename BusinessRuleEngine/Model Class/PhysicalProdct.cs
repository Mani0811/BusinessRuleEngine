namespace BusinessRulesEngine
{
    public class PhysicalProduct : ProductItem
    {
        public int Qunatity { get; set; }

        public PhysicalProduct()
        {
            this.Name = "Physical Product";
            this.Price = 100;
        }

    }


}