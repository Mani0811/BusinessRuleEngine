using System;
using System.Collections.Generic;

namespace BusinessRulesEngine
{
    public class Rule: IRule
    {
        public int Id { get; set; }
       
        public IList<ICondtionAction> Conditions { get; set; }

        public IList<ITargetAction> ResultActions { get; set; }

        public bool PerformConditionSuccess  {get; set; }
        public  bool ResultActionnSuccess { get; set; }

       public bool PerformCondition()
        {
            try
            {
                int count = 0;
                foreach (var condition in Conditions)
                {
                    PerformConditionSuccess = condition.Perform();
                    if (count < Conditions.Count - 1)
                        Console.WriteLine("or");
                    count++;
                }
                return PerformConditionSuccess;
            }
            catch (Exception ex)
            {
                
                Helper.LogException(ex);
                return false;
            }
            
        }

       public bool PerformResultAction()
        {
            if(!PerformConditionSuccess)
            {
                return false;
            }

            foreach (var resultAction in ResultActions)
            {
                ResultActionnSuccess = resultAction.Perform();
            }
            return ResultActionnSuccess;
        }

    }
}
