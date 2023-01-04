using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int lifes = 3;
    [SerializeField] private int level = 1;
    private static GameManager instance;
    
    
    [SerializeField] public List<GameObject> lifesUI;
    
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
            Debug.Log(lifes);
            // Reiniciar nivel  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
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
