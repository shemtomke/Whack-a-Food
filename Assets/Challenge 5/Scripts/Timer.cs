using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private GameManagerX gameManagerX;

    public TextMeshProUGUI timerText;
    
    public int timeRemaining = 60;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    }

    // Update is called once per frame
    void Update()
    {
        //if the time is less
        if(timeRemaining < 1)
        {
            gameManagerX.GameOver();
        }


    }
    public void StartTimer()
    {
        StartCoroutine(startCountDown(timeRemaining));
    }

    IEnumerator startCountDown(int countDown)
    {
        while(countDown > 0 && gameManagerX.isGameActive)
        {
            yield return new WaitForSeconds(1f);
            countDown--;
            timerText.text = "Timer: " + countDown.ToString();
        }
    }
}
