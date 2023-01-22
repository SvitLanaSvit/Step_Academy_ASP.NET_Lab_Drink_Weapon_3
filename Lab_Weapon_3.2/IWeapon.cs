namespace Lab_Weapon_3._2
{
    public interface IWeapon
    {
        string Kill();
    }

    public class Bazuka : IWeapon
    {
        public string Kill()
        {
            return "Kill with bazuka.";
        }
    }

    public class Sword : IWeapon
    {
        public string Kill()
        {
            return "Kill with sword.";
        }
    }

    public class Warrior 
    {
       public readonly IWeapon weapon;

        public Warrior(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public string GetWeaponMessage()
        {
            return weapon.Kill();
        }
    }
}