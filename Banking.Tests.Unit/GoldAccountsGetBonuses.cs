﻿
namespace Banking.Tests.Unit;

public class GoldAccountsGetBonuses
{
    

    [Fact]
    public void GoldAccountsGetDepositBonus()
    {
        var account = new GoldAccount();
        var openingBalance = account.GetBalance();
        var amountToDeposit = 100M;

        account.Deposit(amountToDeposit);

        Assert.Equal(openingBalance + amountToDeposit + 10M, account.GetBalance());
    }
}