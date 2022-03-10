using System;
using System.Collections.Generic;
using System.Linq;

namespace MoneyTransactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(",");
            Dictionary<int, double> accounts = new Dictionary<int, double>();
            foreach (var item in input)
            {
                var currItem = item.Split("-");
                var accNumber = int.Parse(currItem[0]);
                var accBalance = double.Parse(currItem[1]);
                accounts.Add(accNumber, accBalance);
            }
            var commands = Console.ReadLine();
            while (commands != "End")
            {
                try
                {
                    var tokens = commands.Split();
                    var cmd = tokens[0];
                    var accNumber = int.Parse(tokens[1]);
                    var sum = double.Parse(tokens[2]);
                    if (cmd == "Deposit")
                    {
                        if (accounts.ContainsKey(accNumber))
                        {
                            accounts[accNumber] += sum;
                            Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    else if (cmd == "Withdraw")
                    {
                        if (accounts.ContainsKey(accNumber))
                        {
                            if (accounts[accNumber] - sum > 0)
                            {
                            accounts[accNumber] -= sum;
                            Console.WriteLine($"Account {accNumber} has new balance: {accounts[accNumber]:f2}");
                            }
                            else
                            {
                                throw new Exception();
                            }
                        }
                        else
                        {
                            throw new ArgumentException();
                        }
                    }
                    else
                    {
                        throw new FormatException();
                    }
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid command!");
                }
                catch (Exception)
                {
                    Console.WriteLine($"Insufficient balance!");
                }
                finally
                {
                    Console.WriteLine($"Enter another command");
                }

                commands = Console.ReadLine();
            }
        }
    }
}
