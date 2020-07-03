using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace BusinessRulesEngine
{
   public class RuleEngine : IRuleEngine
    {
        private readonly ILogger<RuleEngine> _logger;
        private readonly IServiceProvider _serviceProvider;
        public RuleEngine()
        {

        }

        public RuleEngine(ILogger<RuleEngine> logger, IServiceProvider servicesProvider)
        {
            _logger = logger;
            _serviceProvider = servicesProvider;
        }

        public Dictionary<int, Rule> Rules { get; set; } = new Dictionary<int, Rule>();

        /// <summary>
        /// The rule can be configured by the user in the XML or UI tool.
        /// The rule can be saved in the database and the can be loaded in from the database.
        /// </summary>
        public void AddRule()
        {
            try
            {
                var rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 1;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new PhysicalProduct() } };
                rule.ResultActions = new List<ITargetAction> {  new ShipingPackingSlip() };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information,$"Rule Created with id: {rule.Id}", rule);
                rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 2;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new Book() } };
                rule.ResultActions = new List<ITargetAction> {new RoyaltyDepartmentPackingSlip() };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information, $"Rule Created with id: {rule.Id}", rule);
                rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 3;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new Book() }, new Payment() { MemberValue = new PhysicalProduct() } };
                rule.ResultActions = new List<ITargetAction> { new CommissioonToAgent()  };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information, $"Rule Created with id: {rule.Id}", rule);
                rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 4;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new MemberShip() } };
                rule.ResultActions = new List<ITargetAction> { new ActivateMembership() };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information, $"Rule Created with id: {rule.Id}", rule);
                rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 5;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new UpgradeMemberShip() }, new Payment() { MemberValue = new MemberShip() } };
                rule.ResultActions = new List<ITargetAction> { new EmailOwnerInormAboutActivation() };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information, $"Rule Created with id: {rule.Id}", rule);
                rule = _serviceProvider.GetRequiredService<Rule>();
                rule.Id = 6;
                rule.Conditions = new List<ICondtionAction> { new Payment() { MemberValue = new VideoLearningToSki() } };
                rule.ResultActions = new List<ITargetAction> { new AddFirstAidVideoInPackingSlip() };
                Rules.Add(rule.Id, rule);
                _logger.Log(LogLevel.Information, $"Rule Created with id: {rule.Id}", rule);
            }
            catch (Exception ex)
            {
                _logger.LogError(0,ex,"Error while Creating Rule");
            }
           
        }

        public bool Perform(IRule rule)
        {
            if (rule == null)
                throw new ArgumentNullException(nameof(rule));
            if (rule.PerformCondition())
               return rule.PerformResultAction();
            return false;
        }
    }
}
