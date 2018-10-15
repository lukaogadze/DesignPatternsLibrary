using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.StoreExample
{
    public interface IDiscountRule
    {
        decimal CalculateCustomerDiscount(Customer customer);
    }
  
    public class FirstTimeCustomerRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (!customer.DateOfFirstPurchase.HasValue)
            {
                return 0.15m;
            }
            return 0;
        }
    }
  
    public class LoyalCustomerRule : IDiscountRule
    {
        private readonly decimal _discount;
        private readonly int _yearsAsCustomer;

        public LoyalCustomerRule(int yearsAsCustomer, decimal discount)
        {
            this._yearsAsCustomer = yearsAsCustomer;
            this._discount = discount;
        }

        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (customer.DateOfFirstPurchase.HasValue)
            {
                if (customer.DateOfFirstPurchase.Value.AddYears(_yearsAsCustomer) <= DateTime.Today)
                {
                    var birthdayRule = new BirthdayDiscountRule();

                    return _discount + birthdayRule.CalculateCustomerDiscount(customer);
                }
            }
            return 0;
        }
    }
  
    public class VeteranRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (customer.IsVeteran)
            {
                return 0.1m;
            }
            return 0;
        }
    }
  
    public class SeniorRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (customer.DateOfBirth < DateTime.Now.AddYears(-65))
            {
                return .05m;
            }
            return 0;
        }
    }
  
    public class BirthdayDiscountRule : IDiscountRule
    {
        public decimal CalculateCustomerDiscount(Customer customer)
        {
            if (customer.DateOfBirth.Month == DateTime.Today.Month &&
                customer.DateOfBirth.Day == DateTime.Today.Day)
            {
                return 0.10m;
            }
            return 0;
        }
    }

    public class DiscountCalculator
    {
        List<IDiscountRule> _rules = new List<IDiscountRule>();
        public DiscountCalculator()
        {
            _rules.Add(new BirthdayDiscountRule());
            _rules.Add(new SeniorRule());
            _rules.Add(new VeteranRule());
            _rules.Add(new LoyalCustomerRule(1, 0.10m));
            _rules.Add(new LoyalCustomerRule(5, 0.12m));
            _rules.Add(new LoyalCustomerRule(10, 0.20m));
            _rules.Add(new FirstTimeCustomerRule());
        }

        public decimal CalculateDiscountPercentage(Customer customer)
        {
            decimal discount = 0;
            foreach (var rule in _rules)
            {
                discount = Math.Max(rule.CalculateCustomerDiscount(customer), discount);
            }
            return discount;
        }
    }
}