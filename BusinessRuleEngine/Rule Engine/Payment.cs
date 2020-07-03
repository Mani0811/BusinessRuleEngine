using System;

namespace BusinessRulesEngine
{
    public class Payment : ICondtionAction
    {
       
        public Item MemberValue { get; set; }
        public bool Perform()
        {
            try
            {
                Helper.PerformCondtionAction(MemberValue);
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