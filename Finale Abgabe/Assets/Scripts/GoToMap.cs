using UnityEngine;

public class GoToMap : MonoBehaviour
{
    public void GoToMapScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Map");
        Time.timeScale = 1;
    }

}

