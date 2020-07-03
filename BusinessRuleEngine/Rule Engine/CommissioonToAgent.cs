using BusinessRulesEngine;
using System;

namespace BusinessRulesEngine
{
    public class CommissioonToAgent : Item, ITargetAction
    {

        public CommissioonToAgent()
        {
            this.Name = "Generated Commissioon To Agent";
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