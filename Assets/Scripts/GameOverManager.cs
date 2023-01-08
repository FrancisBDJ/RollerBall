using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    
    
    [SerializeField] private Button _btnMainMenu;
    [SerializeField] private Button _btnTryAgain;
    [SerializeField] private Button _btnQuitGame;
    
    private void LoadLevel1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    
    private void GoToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    private void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        if (gameManager != null)
        {
            Destroy(gameManager);
        }
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        _btnMainMenu.onClick.AddListener(GoToMainMenu);
        _btnTryAgain.onClick.AddListener(LoadLevel1);
        _btnQuitGame.onClick.AddListener(QuitGame);
    }
}
