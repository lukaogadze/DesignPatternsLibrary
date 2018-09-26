using System;
using ApprovalCommon;

namespace Approval
{
    public class ExpenseHandler : IExpenseHandler
    {
        private readonly IExpenseApprover _approver;
        private IExpenseHandler _next;

        public ExpenseHandler(IExpenseApprover approver)
        {
            _approver = approver;
            _next = EndOfChainExpenseHandler.Instance;
        }
        
        public ApprovalResponse Approve(IExpenseReport expenseReport)
        {
            ApprovalResponse response = _approver.ApproveExpense(expenseReport);

            if (response == ApprovalResponse.BeyondApprovalLimit)
            {
                return _next.Approve(expenseReport);
            }

            return response;
        }
        
        public void RegisterNext(IExpenseHandler next)
        {
            _next = next;
        }                  
    }
}