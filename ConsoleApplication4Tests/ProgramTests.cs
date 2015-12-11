using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ConsoleApplication4.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        Program test = new Program();

        [TestMethod()]
        public void InfixToPostfixTest1()
        {
            Assert.AreEqual("3 4 2 5 ^ - * 6 +",
                test.InfixToPostfix("3 * ( 4 - 2 ^ 5 ) + 6"));
        }

        [TestMethod()]
        public void InfixToPostfixTest2()
        {
            Assert.AreEqual("3 2 1 2 + ^ ^",
                test.InfixToPostfix("3 ^ 2 ^ ( 1 + 2 )"));
        }

        [TestMethod()]
        public void InfixToPostfixTest3()
        {
            Assert.AreEqual("10 2 2 2 ^ ^ * 10 50 * +",
                test.InfixToPostfix("10 * ( 2 ^ 2 ^ 2 ) + 10 * 50"));
        }

        [TestMethod()]
        public void InfixToPostfixTest4()
        {
            Assert.AreEqual("100 50 2 3 ^ - / 50 10 / - 5 +",
                test.InfixToPostfix("100 / ( 50 - 2 ^ 3 ) - 50 / 10 + 5"));
        }

        [TestMethod()]
        public void InfixToPostfixTest5()
        {
            Assert.AreEqual("10 54 10 % 25 10 - 2 2 ^ + * 3 / +",
                test.InfixToPostfix("10 + 54 % 10 * ( 25 - 10 + 2 ^ 2 ) / 3"));
        }

        [TestMethod()]
        public void InfixToPostfixTest6()
        {
            Assert.AreEqual("10 5 2 % + 5 3 3 ^ * + 25 5 / -",
                test.InfixToPostfix("( 10 + 5 % 2 ) + ( 5 * 3 ^ 3 ) - ( 25 / 5 )"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest1()
        {
            Assert.AreEqual(-78, test.EvaluatePostfix("3 4 2 5 ^ - * 6 +"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest2()
        {
            Assert.AreEqual(6561, test.EvaluatePostfix("3 2 1 2 + ^ ^"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest3()
        {
            Assert.AreEqual(6561, test.EvaluatePostfix("3 2 1 2 + ^ ^"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest4()
        {
            Assert.AreEqual(6561, test.EvaluatePostfix("3 2 1 2 + ^ ^"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest5()
        {
            Assert.AreEqual(6561, test.EvaluatePostfix("3 2 1 2 + ^ ^"));
        }

        [TestMethod()]
        public void EvaluatePostfixTest6()
        {
            Assert.AreEqual(141, 
                test.EvaluatePostfix("10 5 2 % + 5 3 3 ^ * + 25 5 / -"));
        }
    }
}