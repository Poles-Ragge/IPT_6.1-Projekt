using UnityEngine;

public class ExampleData : MonoBehaviour
{
    void Start()
    {
        CreateDatabase db = FindFirstObjectByType<CreateDatabase>();

        db.AddEffect("Poison", "Deals damage over time");
        db.AddEffect("Burn", "Sets target on fire");
        db.AddEffect("Heal", "Restores HP over time");

        db.AddArmour("Leather Armor", "Basic protection", "common", 5.0m);
        db.AddArmour("Chain Mail", "Interlocked metal rings", "uncommon", 20.0m);
        db.AddArmour("Plate Armor", "Heavy full-body plate", "rare", 75.0m);

        db.AddItem("Health Potion", "Heals 50 HP", "common", 5.0m);
        db.AddItem("Mana Potion", "Restores 30 MP", "common", 4.0m);
        db.AddItem("Elixir", "Fully restores HP and MP", "rare", 50.0m);

        Debug.Log("Beispieldaten eingefügt");
    }

    public void BenutzerItemHinzufuegen(string name, string description, string rarity, decimal price)
    {
        if (name == "")
        {
            Debug.LogWarning("Name darf nicht leer sein");
            return;
        }
        CreateDatabase db = FindFirstObjectByType<CreateDatabase>();
        db.AddItem(name, description, rarity, price);
    }
}