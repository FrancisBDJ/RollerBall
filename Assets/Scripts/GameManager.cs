using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private int level = 1;
    private static GameManager _instance;
    private float _health = 100.0f;
    private int _cubeTotal = 7;
    private int _cubeCount = 0;
    public bool paused;
    [SerializeField] private TextMeshProUGUI txtCubes;
    [SerializeField] public List<GameObject> lifesUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI txtPause;
    [SerializeField] private Button quitGameButton;
    [SerializeField] private TextMeshProUGUI txtTimer;
    [SerializeField] private TextMeshProUGUI txtWin;
    public int GetLevel()
    {
        return level;
    }
    
    public void GameOver()
    {
       
        Time.timeScale = 0f;
        SceneManager.LoadScene("GameOverScene");
    }
    
    public void LoseLife()
    {
        lifes--;
        lifesUI[lifes].gameObject.SetActive(false);

        if (lifes <= 0)
        {
            // GameOver
            GameOver();
        }
        else
        {
            // Reiniciar nivel  
            _cubeCount = 0;
            txtCubes.text = (_cubeCount + "/" + _cubeTotal) ;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    
    public void TakeDamage(float damageAmount)
    {
        _health = _health - damageAmount;
        healthBar.value = _health;
 
        if (_health <= 0f)
        {
            // die
            LoseLife();
        }   
    }

    public void WinLevel()
    {
        level++;
        quitGameButton.gameObject.SetActive(true);
        txtWin.gameObject.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
    }

    public void AddCube()
    {
        _cubeCount++;
        txtCubes.text = (_cubeCount + "/" + _cubeTotal) ;
        if (_cubeCount >= _cubeTotal)
        {
            WinLevel();
        }
    }
    
    private void Pause()
        {
            if (paused == true)
            {
                txtPause.gameObject.SetActive(false);
                quitGameButton.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
                paused = false;
            }
    
            else
            {
                txtPause.gameObject.SetActive(true);
                quitGameButton.gameObject.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0.0f;
                paused = true;
            }
        }
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    private void InitLevel1()
    {
        txtPause.gameObject.SetActive(false);
        txtTimer.gameObject.SetActive(false);
        txtWin.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
        quitGameButton.gameObject.SetActive(false);
        quitGameButton.onClick.AddListener(QuitGame);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InitLevel1();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Pause();
        }
    }
}
