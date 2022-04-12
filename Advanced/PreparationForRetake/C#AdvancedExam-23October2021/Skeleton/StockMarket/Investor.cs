﻿using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            var currCompany = Portfolio.FirstOrDefault(x=>x.CompanyName == companyName);
            if (currCompany == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < currCompany.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(currCompany);
            MoneyToInvest -= sellPrice;
            return $"{companyName} was sold.";
        }
        public Stock FindStock(string companyName)
        {
            return Portfolio.First(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            if (Portfolio.Count == 0 )
            {
                return null;
            }

            return Portfolio.OrderByDescending(x => x.MarketCapitalization).First();
        }
        public string InvestorInformation()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
