using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private int level = 1; //Change level value in Inspector to try the other levels 
    private static GameManager _instance;
    private float _health = 100.0f;
    private int _score;
    private int _cubeTotal;
    private int _cubeCount;
    public bool paused;
    [SerializeField] private TextMeshProUGUI txtScore;
    [SerializeField] private TextMeshProUGUI txtCubes;
    [SerializeField] public List<GameObject> lifesUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI txtPause;
    [SerializeField] private Button mainMenuButton;
    [SerializeField] private Button quitGameButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private TextMeshProUGUI txtTimer;
    [SerializeField] private TextMeshProUGUI txtWin;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
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

    public void NextLevel()
    {
        if (level == 1)
        {
            level++;
            SceneManager.LoadScene("Scenes/Level2");
        }
        else if (level == 2)
        {
            level++;
            SceneManager.LoadScene("Scenes/Level3");
        }
    }

    private void WinLevel()
    {
        quitGameButton.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(true);
        txtWin.gameObject.SetActive(true);
        _score += 100;
        txtScore.text = _score + " pts";
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0.0f;
        if (level != 3)
        {
            nextLevelButton.gameObject.SetActive(true);
        }
        else
        {
            txtWin.text = "You Winned all 3 levels. Congratulations";
        }
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
        mainMenuButton.gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitGameButton.gameObject.SetActive(false);
        quitGameButton.onClick.AddListener(QuitGame);
        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(NextLevel);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _cubeTotal = 7;
        _cubeCount = 0;
        txtCubes.text = (_cubeCount + "/" + _cubeTotal) ;
        
    }

    public void InitLevel2()
    {
        txtPause.gameObject.SetActive(false);
        txtTimer.gameObject.SetActive(true);
        txtWin.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitGameButton.gameObject.SetActive(false);
        quitGameButton.onClick.AddListener(QuitGame);
        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(NextLevel);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _cubeTotal = 15;
        _cubeCount = 0;
        _health = 100.0f;
        healthBar.value = _health;
        txtCubes.text = (_cubeCount + "/" + _cubeTotal);
        txtScore.text = _score + " pts";
    }
    
    public void InitLevel3()
    {
        txtPause.gameObject.SetActive(false);
        txtTimer.gameObject.SetActive(true);
        txtWin.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(true);
        mainMenuButton.gameObject.SetActive(false);
        mainMenuButton.onClick.AddListener(GoToMainMenu);
        quitGameButton.gameObject.SetActive(false);
        quitGameButton.onClick.AddListener(QuitGame);
        nextLevelButton.gameObject.SetActive(false);
        nextLevelButton.onClick.AddListener(NextLevel);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _cubeTotal = 20;
        _cubeCount = 0;
        _health = 100.0f;
        healthBar.value = _health;
        txtCubes.text = (_cubeCount + "/" + _cubeTotal);
        txtScore.text = _score + " pts";
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
        if (level == 1)
        {
            InitLevel1();  
        }
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
