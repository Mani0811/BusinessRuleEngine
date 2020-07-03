using System;

namespace BusinessRulesEngine
{
    public class EmailOwnerInormAboutActivation : Item, ITargetAction
    {
        public EmailOwnerInormAboutActivation()
        {
            this.Name = "Sent EmailOwner and Inormed About Activation";
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