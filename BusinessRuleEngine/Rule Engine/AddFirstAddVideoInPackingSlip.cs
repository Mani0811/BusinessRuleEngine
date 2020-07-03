using System;

namespace BusinessRulesEngine
{
    public class AddFirstAidVideoInPackingSlip :Item, ITargetAction
    {
        public AddFirstAidVideoInPackingSlip()
        {
            this.Name = "Added First Aid Video In PackingSlip";
        }
        double Amount { get; set; }
        public DateTime Date { get; set; }

        public virtual bool Perform()
        {
            try
            {
                Helper.PerformResultAction(this, string.Empty);
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