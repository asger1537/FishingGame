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
        SceneManager.LoadScene("Options");
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
}