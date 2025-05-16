using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu: MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("STEMCityScene");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
