using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class CreateDatabaseTests
{
    private GameObject dbObject;
    private CreateDatabase db;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        dbObject = new GameObject("TestDatabase");
        dbObject.AddComponent<DatabaseConnection>();
        db = dbObject.AddComponent<CreateDatabase>();
        yield return null;
    }

    [UnityTearDown]
    public IEnumerator Teardown()
    {
        Object.Destroy(dbObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItem_GueltigeWerte_WirdEingefuegt()
    {
        string itemName = "TestItem_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        int countBefore = db.GetItemCount();

        db.AddItem(itemName, "Beschreibung", "common", 5.0m);

        int countAfter = db.GetItemCount();
        Assert.AreEqual(countBefore + 1, countAfter);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItem_LeererName_WirdNichtEingefuegt()
    {
        int countBefore = db.GetItemCount();

        db.AddItem("", "Beschreibung", "common", 5.0m);

        int countAfter = db.GetItemCount();
        Assert.AreEqual(countBefore, countAfter);
        yield return null;
    }

    [UnityTest]
    public IEnumerator AddItem_NegativerPreis_WirdNichtEingefuegt()
    {
        string itemName = "TestItem_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        int countBefore = db.GetItemCount();

        db.AddItem(itemName, "Beschreibung", "common", -5.0m);

        int countAfter = db.GetItemCount();
        Assert.AreEqual(countBefore, countAfter);
        yield return null;
    }

    [UnityTest]
    public IEnumerator UpdateItem_GueltigeWerte_AktualisiertEintrag()
    {
        string itemName = "TestItem_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        db.AddItem(itemName, "Alt", "common", 5.0m);
        int itemId = db.GetItemId(itemName);

        db.UpdateItem(itemId, "Neu", "rare", 10.0m);

        string rarity = db.GetItemRarity(itemId);
        Assert.AreEqual("rare", rarity);
        yield return null;
    }

    [UnityTest]
    public IEnumerator DeleteItem_VorhandeneId_LoeschtEintrag()
    {
        string itemName = "TestItem_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        db.AddItem(itemName, "Beschreibung", "common", 5.0m);
        int itemId = db.GetItemId(itemName);

        db.DeleteItem(itemId);

        int itemIdAfter = db.GetItemId(itemName);
        Assert.AreEqual(-1, itemIdAfter);
        yield return null;
    }
}