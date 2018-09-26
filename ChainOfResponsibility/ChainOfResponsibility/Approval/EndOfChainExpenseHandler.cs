using ApprovalCommon;

namespace Approval
{
    public class EndOfChainExpenseHandler : IExpenseHandler
    {
        private static readonly EndOfChainExpenseHandler _instance = new EndOfChainExpenseHandler();
        
        
        private EndOfChainExpenseHandler () {}

        public static EndOfChainExpenseHandler Instance => _instance;

        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            return ApprovalResponse.Denied;
        }

        public void RegisterNext(IExpenseHandler next)
        {
            throw new System.InvalidOperationException("End of chain handler must be the end of the chain!");
        }
    }
}