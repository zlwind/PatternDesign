using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _23_StragetyPattern
{
    //场景：计算个人所得税 个人和企业的个人所得税算法不一样

    // 所得税计算策略
    public interface ITaxStragety
    {
        double CalculateTax(double income);
    }

    // 个人所得税
    public class PersonalTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return income * 0.12;
        }
    }

    // 企业所得税
    public class EnterpriseTaxStrategy : ITaxStragety
    {
        public double CalculateTax(double income)
        {
            return (income - 3500) > 0 ? (income - 3500) * 0.045 : 0.0;
        }
    }

    public class InterestOperation
    {
        private ITaxStragety m_strategy;
        public InterestOperation(ITaxStragety strategy)
        {
            this.m_strategy = strategy;
        }

        public double GetTax(double income)
        {
            return m_strategy.CalculateTax(income);
        }
    }
}
