using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class  Timer : MonoBehaviour
             {
                 [SerializeField] private GameManager gameManager;
                 [SerializeField] private TextMeshProUGUI timerText;
                 private static float _timeRemaining;
                 private static bool _timerIsRunning = false;
                 private GameObject _timer;
                 public static Timer Instance;
                 void DisplayTime(float timeToDisplay)
                 {
                     timeToDisplay += 1;
                     float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
                     float seconds = Mathf.FloorToInt(timeToDisplay % 60);
                     timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
                 }
             
                 void Countdown()
                 {
                     
                     if (_timerIsRunning)
                     {
                         
                         if (_timeRemaining >= 0)
                         {
                             _timeRemaining -= Time.deltaTime;
                         }
                         else
                         {
                             gameManager.LoseLife();
                         }
                     }
                     DisplayTime(_timeRemaining);
                 }

                 public static void ResetTimer()
                 {
                     _timeRemaining = 180f;
                     _timerIsRunning = true;

                 }

                 private void Awake()
                 {
                     _timer = GameObject.Find("Timer");
                     
                     if (Instance != null && Instance != this) {
                         Destroy(this.gameObject);
                     }
                     else {
                         Instance = this;
                         DontDestroyOnLoad(_timer);
                     }
                     
                 }
                 // Start is called before the first frame update
                 void Start()
                 {
                     gameManager = FindObjectOfType<GameManager>();
                     
                 }
             
                 // Update is called once per frame
                 void Update()
                 {
                     
                     Countdown();
                     
                 }
             }
