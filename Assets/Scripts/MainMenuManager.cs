using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitGameButton;
    private void LoadLevel1()
    {
        SceneManager.LoadScene("Scenes/Level1");
    }
    
    private void QuitGame()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManager = GameObject.Find("Game Manager");
        if (gameManager != null)
        {
            Destroy(gameManager);
        }
        newGameButton.onClick.AddListener(LoadLevel1);
        //optionsButton.onClick.AddListener(LoadOptions);
        quitGameButton.onClick.AddListener(QuitGame);
    }
}
