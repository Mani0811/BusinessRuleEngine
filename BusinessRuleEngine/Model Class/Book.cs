using BusinessRulesEngine;

namespace BusinessRulesEngine
{
    public class Book : ProductItem
    {
        public int Qunatity { get; set; }

        public Book()
        {
            this.Name = "Book";
            this.Price = 100;
        }
    }
}