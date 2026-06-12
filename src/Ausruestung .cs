using System;

public abstract class Ausruestung
{
    public string Name { get; set; }
    public string Rarity { get; set; }
    public decimal Price { get; set; }

    public Ausruestung(string name, string rarity, decimal price)
    {
        Name = name;
        Rarity = rarity;
        Price = price;
    }

    public abstract string Beschreibung();
}

public class Waffe : Ausruestung
{
    public float Schaden { get; set; }

    public Waffe(string name, string rarity, decimal price, float schaden)
        : base(name, rarity, price)
    {
        Schaden = schaden;
    }

    public override string Beschreibung()
    {
        return Name + " (" + Rarity + ") - Schaden: " + Schaden + ", Preis: " + Price + " Coins";
    }
}

public class Ruestung : Ausruestung
{
    public int Verteidigung { get; set; }

    public Ruestung(string name, string rarity, decimal price, int verteidigung)
        : base(name, rarity, price)
    {
        Verteidigung = verteidigung;
    }

    public override string Beschreibung()
    {
        return Name + " (" + Rarity + ") - Verteidigung: " + Verteidigung + ", Preis: " + Price + " Coins";
    }
}