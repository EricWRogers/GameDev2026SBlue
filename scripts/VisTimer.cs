using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class VisTimer : MonoBehaviour
{
    public float maxTime = 10.0f;
    public Text timerText;
    public bool timerRunning = true;
    public float currentTime = 0.0f;
    void Start()
    {
      
    }

    void Update()
    {
        if (timerRunning)
        {
            currentTime = maxTime -= Time.deltaTime;
            timerText.text = "Time: " + maxTime.ToString("0.00");
        }
        if (maxTime <= 0)
        {
            timerRunning = false;
        }
    }



}
