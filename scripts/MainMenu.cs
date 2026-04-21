using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    // Called when the Start Game button is pressed
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1); // Replace with your actual gameplay scene name
    }

    // Called when the Quit Game button is pressed
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit(); // Won't work in editor, only in build
    }
}
