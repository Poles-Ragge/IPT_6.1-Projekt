using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class UserRepositoryTests
{
    private GameObject dbObject;

    [UnitySetUp]
    public IEnumerator Setup()
    {
        dbObject = new GameObject("TestDatabase");
        dbObject.AddComponent<DatabaseConnection>();
        dbObject.AddComponent<CreateDatabase>();
        yield return null;
    }

    [UnityTearDown]
    public IEnumerator Teardown()
    {
        Object.Destroy(dbObject);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Register_NeuerBenutzer_GibtTrueZurueck()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);

        bool result = repo.Register(username, "password123");

        Assert.IsTrue(result);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Register_DoppelterBenutzername_GibtFalseZurueck()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);

        repo.Register(username, "password123");
        bool result = repo.Register(username, "anderespasswort");

        Assert.IsFalse(result);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Register_LeererUsername_GibtFalseZurueck()
    {
        var repo = UserRepository.Instance;

        bool result = repo.Register("", "password123");

        Assert.IsFalse(result);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Register_KurzesPasswort_GibtFalseZurueck()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);

        bool result = repo.Register(username, "abc");

        Assert.IsFalse(result);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Login_KorrekteDaten_GibtUserIdZurueck()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        repo.Register(username, "password123");

        int userId = repo.Login(username, "password123");

        Assert.AreNotEqual(-1, userId);
        yield return null;
    }

    [UnityTest]
    public IEnumerator Login_FalschesPasswort_GibtMinusEinsZurueck()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        repo.Register(username, "password123");

        int userId = repo.Login(username, "falschespasswort");

        Assert.AreEqual(-1, userId);
        yield return null;
    }

    [UnityTest]
    public IEnumerator SaveAndLoadGameState_SpeichertUndLaedtKorrekt()
    {
        var repo = UserRepository.Instance;
        string username = "testuser_" + System.Guid.NewGuid().ToString("N").Substring(0, 8);
        repo.Register(username, "password123");
        int userId = repo.Login(username, "password123");

        repo.SaveGameState(userId, username, 100, 50m, 2, true, 7.5f);
        PlayerSaveData data = repo.LoadGameState(userId);

        Assert.IsNotNull(data);
        Assert.AreEqual(100, data.experience);
        Assert.AreEqual(50m, data.money);
        Assert.AreEqual(2, data.level);
        Assert.IsTrue(data.hasGewehr);
        Assert.AreEqual(7.5f, data.speed);
        yield return null;
    }
}