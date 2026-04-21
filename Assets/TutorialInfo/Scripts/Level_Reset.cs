using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Level_Reset : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(ResetSceneAfterDelay());
    }
    IEnumerator ResetSceneAfterDelay()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
    }
}
