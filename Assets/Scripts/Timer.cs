using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class  Timer : MonoBehaviour
             {
                 [SerializeField] private GameManager gameManager;
                 [SerializeField] private TextMeshProUGUI timerText;
                 [SerializeField] private float timeRemaining;
                 [SerializeField] private bool timerIsRunning = false;
                 
                 void DisplayTime(float timeToDisplay)
                 {
                     timeToDisplay += 1;
                     float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
                     float seconds = Mathf.FloorToInt(timeToDisplay % 60);
                     timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                 }
             
                 void Countdown()
                 {
                     if (timerIsRunning)
                     {
                         if (timeRemaining >= 0)
                         {
                             timeRemaining -= Time.deltaTime;
                         }
                     }
                     else
                     {
                         gameManager.GameOver();
                     }
                     DisplayTime(timeRemaining);
                 }
                 
                 // Start is called before the first frame update
                 void Start()
                 {
                     gameManager = FindObjectOfType<GameManager>();
             
                     timerIsRunning = true;
                     
                     
                 }
             
                 // Update is called once per frame
                 void Update()
                 {
                     
                     Countdown();
                     
                 }
             }
