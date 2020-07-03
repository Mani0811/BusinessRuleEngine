using System.Collections.Generic;

namespace BusinessRulesEngine
{
    public interface IRule
    {
        int Id { get; set; }

        IList<ICondtionAction> Conditions { get; set; }

        IList<ITargetAction> ResultActions { get; set; }

        bool PerformCondition();

        bool PerformResultAction();
    }
}