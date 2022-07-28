﻿namespace Banking.Domain;

public class Account
{
    private decimal _balance = 5000M;
    private ICalculateBonusesForAccounts _bonusCalculator;

    public Account(ICalculateBonusesForAccounts bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amountToDeposit)
    {
        GuardAgainstNegativeNumbers(amountToDeposit);
        // WTCYWYH
    decimal bonus = _bonusCalculator.AccountDepositOf(_balance, amountToDeposit);
        _balance += amountToDeposit + bonus;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        GuardAgainstNegativeNumbers(amountToWithdraw);
        if (amountToWithdraw > _balance)
        {

            throw new OverdraftException();
        }
        else
        {
            _balance -= amountToWithdraw;
        }
    }

    private void GuardAgainstNegativeNumbers(decimal amount)
    {
        if (amount < 0) throw new NegativeValuesNotAllowedException();
    }
}

public class OverdraftException : ArgumentOutOfRangeException { }