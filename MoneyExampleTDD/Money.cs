﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExampleTDD
{
    public class Money : MoneyExpression
    {
        private int _amount;
        private string _Currency;

        public Money(int amount, string currency)
        {
            _amount = amount;
            _Currency = currency;
        }

        public string Currency
        {
            get => _Currency;
        }

        public int Amount
        {
            get => _amount;
        }

        public override bool Equals(object obj)
        {
            Money money = (Money)obj;
            return _amount == money._amount && Currency.Equals(money.Currency);
        }

        public Money Times(int multiplier)
        {
            return new Money(_amount * multiplier, Currency);
        }

        public static Money MakeDollars(int amount)
        {
            return new Money(amount, "USD");
        }

        public static Money MakeFrancs(int amount)
        {
            return new Money(amount, "CHF");
        }

        public MoneyExpression Plus(Money addend)
        {
            // Try obvious implementation
            return new Sum(this, addend);
        }
    }
}
