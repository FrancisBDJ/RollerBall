using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] private TextMeshProUGUI _txtCubes;
    [SerializeField] public List<GameObject> lifesUI;
    [SerializeField] private Slider healthBar;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
