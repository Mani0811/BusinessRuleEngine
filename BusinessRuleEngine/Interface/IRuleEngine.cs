namespace BusinessRulesEngine
{
    internal interface IRuleEngine
    {
        void AddRule();

        bool Perform(IRule rule);
    }
}
