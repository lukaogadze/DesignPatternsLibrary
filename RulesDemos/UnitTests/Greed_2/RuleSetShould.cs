using Core.Greed2.Rules;
using NUnit.Framework;

namespace UnitTests.Greed_2
{
    [TestFixture]
    public class RuleSetShould
    {
        [Test]
        public void ReturnRuleNothingWhenEmpty()
        {
            var ruleSet = new RuleSet();
            var result = ruleSet.BestRule(new int[] { 1, 2, 3 });
            Assert.IsNull(result);
        }

        [Test]
        public void ReturnOnlyRuleIfMatchFound()
        {
            var ruleSet = new RuleSet();
            ruleSet.Add(new SingleDieRule(1, 100));
            var result = ruleSet.BestRule(new int[] { 1, 2, 3 });
            Assert.IsInstanceOf<SingleDieRule>(result);
        }

    }
}