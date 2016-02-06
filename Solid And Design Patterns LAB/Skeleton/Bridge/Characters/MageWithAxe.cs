using RPG.Weapons;

namespace RPG.Characters
{
    using RPG.Weapons;

    public class MageWithAxe : Mage
    {
        public Axe Weapon { get; set; }

        public override string ToString()
        {
            return string.Format("{0} wields weapon {1}",
                "Mage", "Axe");
        }
    }
}
