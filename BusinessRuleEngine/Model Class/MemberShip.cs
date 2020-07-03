namespace BusinessRulesEngine
{
    internal class MemberShip : ProductItem
    {
        public int Qunatity { get; set; }

        public MemberShip()
        {
            this.Name = "MemberShip";
            this.Price = 100;
        }
    }
}