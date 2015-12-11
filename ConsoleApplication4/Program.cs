using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication4
{
    public class Program
    {

        public Program() { }

        static void Main(string[] args)
        {
            Program test = new Program();
            string postfix = Console.ReadLine();
            Console.WriteLine(test.EvaluatePostfix(postfix));
        }

        public string InfixToPostfix(string infix)
        {

            // split the string by spaces into an array
            string[] splitInfix = infix.Split(' ');

            // string that will represent the postfix
            string postfix = "";

            // stack to hold chars. while reading each char from the infix
            Stack<string> stack = new Stack<string>();

            // start looping through each char. in the infix
            foreach (string s in splitInfix)
            {

                // check if the character is an operand
                if (IsOperand(s))
                {

                    // add the integer to the postfix expression
                    postfix += s + " ";
                }

                // check for left parenthesis
                else if (IsLeftParen(s))
                {

                    // push the left parenthesis onto the stack
                    stack.Push(s);
                }

                // check for an operator
                else if (IsOperator(s))
                {

                    // check if the stack is empty
                    if (stack.Count() > 0)
                    {

                        // pop operators off the stack while precedence is higher
                        int stackPrecedence = Precedence(stack.Peek(), true);
                        int inputPrecedence = Precedence(s, false);

                        while (stack.Count() > 0 && (Precedence(stack.Peek(), true) >= (Precedence(s, false))))
                        {

                            // pop operators from stack using stack precedence
                            postfix += stack.Pop() + " ";
                        }
                    }

                    // push the operator onto the stack
                    stack.Push(s);
                }

                // check for right parenthesis
                else if (IsRightParen(s))
                {

                    // pop operators until left parenthesis is found
                    string topChar;
                    while (!IsLeftParen((topChar = stack.Pop())))
                    {
                        postfix += topChar + " ";
                    }
                }
            }

            // add remaining items on the stack to the postfix
            while (stack.Count() != 0)
            {
                postfix += stack.Pop() + " ";
            }

            // trim whitespace off end & return postfix string
            return postfix.Trim();
        }

        /// <summary>
        /// Method calculates the value of a postfix expression.
        /// </summary>
        /// <param name="postfix">Valid postfix expression.</param>
        /// <returns>Integer value of the postfix expression.</returns>
        public int EvaluatePostfix(string postfix)
        {

            // stack that keeps track of the results
            Stack<int> results = new Stack<int>();

            // loop through value separated by spaces
            foreach (string s in postfix.Split(' '))
            {

                // check if the string is an operand
                if (IsOperand(s))
                {

                    // convert to integer & push it onto the stack
                    results.Push(Convert.ToInt16(s));
                }

                // check if the current element is an operator
                else if (IsOperator(s))
                {

                    // pop the top into y, next variable into x
                    int y = results.Pop();
                    int x = results.Pop();

                    // stores the result of the current operation
                    int result;
                    
                    // check which operation do to
                    switch (s)
                    {
                        case "+":
                            result = x + y;
                            break;
                        case "-":
                            result = x - y;
                            break;
                        case "*":
                            result = x * y;
                            break;
                        case "/":
                            result = x / y;
                            break;
                        case "%":
                            result = x % y;
                            break;
                        case "^":
                            result = (int) Math.Pow(x, y);
                            break;
                        default:
                            result = 0;
                            break;                        
                    }

                    // push the result onto the stack
                    results.Push(result);
                }
            }

            // return the top of the stack
            return results.Peek();
        }

        /// <summary>
        /// Calculates the input & stack precedence of an operator.
        /// </summary>
        /// <param name="s">String to be evaluated.</param>
        /// <param name="isStack">If isStack is true the stack precedence of 
        /// the string will be calculated. If isStack is false the input 
        /// precedence will be calculated.</param>
        /// <returns>The stack or input precedence of an operator</returns>
        public int Precedence(string s, bool isStack)
        {
            switch (s)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                case "%":
                    return 2;
                case "^":
                    return isStack ? 3 : 4;
                default:
                    return isStack ? -1 : 5;
            }
        }

        /// <summary>
        /// Determines if a string is an operand by attempting to convert the
        /// string an integer.
        /// </summary>
        /// <param name="s">String to be evaluated.</param>
        /// <returns>True if the string is an operand.</returns>
        public bool IsOperand(string s)
        {
            int value;
            return int.TryParse(s.ToString(), out value);
        }

        /// <summary>
        /// Determines if a string is an operator.
        /// </summary>
        /// <param name="s">String to be evaluated.</param>
        /// <returns>True if the string is the the operators array.</returns>
        public bool IsOperator(string s)
        {
            return new string[] { "+", "-", "*", "/", "%", "^" }.Contains(s);
        } 

        /// <summary>
        /// Determines if a string is a left parenthesis.
        /// </summary>
        /// <param name="s">String to be evaluated.</param>
        /// <returns>True is the string is "(".</returns>
        public bool IsLeftParen(string s)
        {
            return s.Equals("(");
        }

        /// <summary>
        /// Determines if a string is a right parenthesis.
        /// </summary>
        /// <param name="s">String to be evaluated.</param>
        /// <returns>True if the string is equal to ")".</returns>
        public bool IsRightParen(string s)
        {
            return s.Equals(")");
        }
    }
}
