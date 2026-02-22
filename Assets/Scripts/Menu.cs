using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void MenuPlayGame()
    {
        SceneManager.LoadScene("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
