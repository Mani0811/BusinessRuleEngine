using BusinessRulesEngine;
using System;

namespace BusinessRulesEngine
{
    public class RoyaltyDepartmentPackingSlip : PackingSlip, ITargetAction
    {
        public RoyaltyDepartmentPackingSlip()
        {
            this.Name = "Royalty Department";
        }
        public DateTime Date { get; set; }
        public override bool Perform()
        {
            Date = DateTime.UtcNow;
            return base.Perform();
        }
    }
}