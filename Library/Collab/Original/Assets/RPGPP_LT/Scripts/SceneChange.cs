using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SceneChange : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Options");
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }

    public void Quit()
    {
        Debug.Log("Game is exiting");
    }
}