using System;
using CreditUnion_Challenge;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class CreditUnionTests
    {
        [TestMethod]
        public void CreditUnion_GetList_ShouldReturnExpectedCountList()
        {
            //Arrange
            CreditUnion union = new CreditUnion();
            var expected = union.GetList().Count;
            var actual = 0;

            Assert.AreEqual(expected, actual);
        }

        [TestClass]
        public class Account
        {
            [TestMethod]
            public void Account_Deposit_ShouldIncrease()
            {
                Consumer consumer = new Consumer();

                consumer.Deposit(10);

                var actual = consumer.Balance;
                var expected = 10;

                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void Account_Withdraw_BalanceShouldDecrease()
            {
                Consumer consumer = new Consumer();

                consumer.Deposit(20);
                consumer.Withdraw(10);

                var expected = 10;
                var actual = consumer.Balance;

                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void Account_Transfer_MoneyShouldBeTransferred()
            {
                Consumer consumer1 = new Consumer();
                Consumer consumer2 = new Consumer()
                {
                    Owner = "Tim",
                    Balance = 1.5m,
                };

                CreditUnion union = new CreditUnion();

                union.AddAccount(consumer2);

                consumer1.Transfer("Tim", 2);

                var expected = 3.5m;
                var actual = consumer2.Balance;

                Assert.AreEqual(expected, actual);
            }
        }
    }
}
