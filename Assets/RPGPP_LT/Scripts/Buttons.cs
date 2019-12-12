using UnityEngine;
using UnityEngine.SceneManagement;
 
public class Buttons: MonoBehaviour
{
    public GameObject canvasObject;
    public bool paused;
    public Playermovement game;

    public void Play()
    {
        SceneManager.LoadScene("Game");
    }
    public void Options()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Options");
    }
    public void StartMenu()
    {
        SceneManager.LoadScene("StartMenu");
    }
    public void Quit()
{
    Application.Quit();
    Debug.Log("Game is exiting");
}
    public void Resume()
    {
        canvasObject.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        game.paused=false;
    }    
}