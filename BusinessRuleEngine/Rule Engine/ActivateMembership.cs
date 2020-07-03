using System;

namespace BusinessRulesEngine
{
    public class ActivateMembership : Item, ITargetAction
    {
        public ActivateMembership()
        {
            this.Name = "Activated Membership";
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