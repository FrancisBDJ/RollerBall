using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class  Timer : MonoBehaviour
             {
                 [SerializeField]
                 private GameManager _gameManager;
                 [SerializeField] 
                 private TextMeshProUGUI _timerText;
                 [SerializeField] 
                 private float _timeRemaining;
                 [SerializeField] 
                 private bool _timerIsRunning = false;
                 
                 void DisplayTime(float _timeToDisplay)
                 {
                     _timeToDisplay += 1;
                     float minutes = Mathf.FloorToInt(_timeToDisplay / 60); 
                     float seconds = Mathf.FloorToInt(_timeToDisplay % 60);
                     _timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                 }
             
                 void Countdown()
                 {
                     if (_timerIsRunning)
                     {
                         if (_timeRemaining >= 0)
                         {
                             _timeRemaining -= Time.deltaTime;
                         }
                     }
                     else
                     {
                         _gameManager.GameOver();
                     }
                     DisplayTime(_timeRemaining);
                 }
                 
                 // Start is called before the first frame update
                 void Start()
                 {
                     _gameManager = FindObjectOfType<GameManager>();
             
                     _timerIsRunning = true;
                     
                     
                 }
             
                 // Update is called once per frame
                 void Update()
                 {
                     
                     Countdown();
                     
                 }
             }
