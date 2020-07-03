using System;

namespace BusinessRulesEngine
{
    public class PackingSlip : Item
    {
        public DateTime PurchaseDate { get; set; }

        public double TotalPrice { get; set; }

        public virtual bool Perform()
        {
            try
            {
                Helper.PerformResultAction(this, "generated packing slip for");
                return true;
            }
            catch (Exception ex)
            {
                Helper.LogException(ex);
                return false;
            }

        }

    }


}