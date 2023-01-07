using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    private GameManager _gameManager;
    
    [SerializeField] private Button _btnMainMenu;
    [SerializeField] private Button _btnTryAgain;
    [SerializeField] private Button _btnQuitGame;
    [SerializeField] private Canvas GameManagerCanvas;
    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        GameManagerCanvas.gameObject.SetActive(false);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        /*_btnMainMenu.onClick.AddListener(SceneManager.LoadScene("MainMenu");
        _btnTryAgain.onClick.AddListener(SceneManager.LoadScene("Level1"));*/
        _btnQuitGame.onClick.AddListener(_gameManager.QuitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
