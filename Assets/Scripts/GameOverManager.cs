using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    
    
    [FormerlySerializedAs("_btnMainMenu")] [SerializeField] private Button btnMainMenu;
    [FormerlySerializedAs("_btnTryAgain")] [SerializeField] private Button btnTryAgain;
    [FormerlySerializedAs("_btnQuitGame")] [SerializeField] private Button btnQuitGame;
    
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
        btnMainMenu.onClick.AddListener(GoToMainMenu);
        btnTryAgain.onClick.AddListener(LoadLevel1);
        btnQuitGame.onClick.AddListener(QuitGame);
    }
}
