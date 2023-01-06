using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private int level = 1;
    private static GameManager instance;
    private float _health = 100.0f;
    private int _cubeTotal = 7;
    private int _cubeCount = 0;
    public bool paused;
    [SerializeField] private TextMeshProUGUI _txtCubes;
    [SerializeField] public List<GameObject> lifesUI;
    [SerializeField] private Slider healthBar;
    [SerializeField] private TextMeshProUGUI _txtPause;
    [SerializeField] private Button _quitGameButton;
    
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
            _txtCubes.text = (_cubeCount + "/" + _cubeTotal) ;
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

    public void AddCube()
    {
        _cubeCount++;
        _txtCubes.text = (_cubeCount + "/" + _cubeTotal) ;
       
    }
    
    private void Pause()
        {
            if (paused == true)
            {
                _txtPause.gameObject.SetActive(false);
                _quitGameButton.gameObject.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1.0f;
                paused = false;
            }
    
            else
            {
                _txtPause.gameObject.SetActive(true);
                _quitGameButton.gameObject.SetActive(true);
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
        _txtPause.gameObject.SetActive(false);
        _quitGameButton.gameObject.SetActive(false);
        _quitGameButton.onClick.AddListener(QuitGame);
        Time.timeScale = 1.0f;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
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
