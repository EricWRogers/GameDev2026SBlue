using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Change : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LevelNext")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        if (other.tag == "LevelBack")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
}
