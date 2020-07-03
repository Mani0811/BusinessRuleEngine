namespace BusinessRulesEngine
{
    internal class UpgradeMemberShip : ProductItem
    {
        public int Qunatity { get; set; }

        public UpgradeMemberShip()
        {
            this.Name = "Upgrade MemberShip";
            this.Price = 100;
        }
    }
}