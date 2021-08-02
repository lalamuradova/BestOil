using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BestOil
{
    public class DataBase
    {
        public int ID { get; set; } = 0;
        public List<MiniCafe> Eats { get; set; } = new List<MiniCafe>();
        public List<Refueling> Gasolines { get; set; } = new List<Refueling>();

        public void AddEats(MiniCafe eat)
        {
            ++ID;
            Eats.Add(eat);
        }
        public void AddGasoline(Refueling gasoline)
        {
            ++ID;
            Gasolines.Add(gasoline);
        }

    }
    public class MiniCafe
    {
        public MiniCafe() { }
        public MiniCafe(string eat, double price, int count, double totalPrice)
        {
            Eat = eat;
            Price = price;
            Count = count;
            TotalPrice = totalPrice;
        }

        public string Eat { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public double TotalPrice { get; set; }
    }
    public class Refueling
    {
        public Refueling() { }
        public Refueling(string gasoline, int quantity, double price,double totalPrice)
        {
            Gasoline = gasoline;
            Quantity = quantity;
            Price = price;
            TotalPrice = totalPrice;
        }

        public string Gasoline { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double TotalPrice { get; set; }
    }
}
