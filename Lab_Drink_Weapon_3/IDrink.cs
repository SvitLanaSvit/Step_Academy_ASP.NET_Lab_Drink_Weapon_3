using System.Text;

namespace Lab_Drink_Weapon_3
{
    public interface IDrink
    {
        string GetInfo();
    }

    public class Tee : IDrink
    {
        public string GetInfo()
        {
            return "Green tee with hot water, ginger and honey.";
        }
    }

    public class Caffe : IDrink
    {
        public string GetInfo()
        {
            return "Americano with hot water and milk and some suger.";
        }
    }

    public class Juice : IDrink
    {
        public string GetInfo()
        {
            return "Straight-pressed apple juice.";
        }
    }

    public class DrinkService
    {
        public readonly IDrink drink;
        public DrinkService(IDrink drink)
        {
            this.drink = drink;
        }

        public string GetDrinkMessage() 
        {
            return drink.GetInfo();
        }
    }

    public class AllDrinkService
    {
        public readonly IEnumerable<IDrink> drinks;
        public AllDrinkService(IEnumerable<IDrink> drinks)
        {
            this.drinks = drinks;
        }

        public string GetDrinkMessage()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<ul>");
            foreach (var drink in drinks)
            {
                sb.AppendLine($"<li>{drink.GetInfo()}</li>");
            }
            sb.AppendLine("</ul>");
            return sb.ToString();
        }
    }
}