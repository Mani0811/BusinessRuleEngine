using System;

namespace BusinessRulesEngine
{
    public class ShipingPackingSlip : PackingSlip, ITargetAction
    {
        public ShipingPackingSlip()
        {
            this.Name = "Shipping";
        }
        public string Address { get; set; }
        public DateTime ShipingDate { get; set; }

        public override bool Perform()
        {
            try
            {
                ShipingDate = DateTime.UtcNow;
                return base.Perform();
            }
            catch (Exception ex)
            {
                Helper.LogException(ex);
                return false;
            }
            
        }

    }
}