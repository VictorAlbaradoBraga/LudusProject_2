using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamecontroller : MonoBehaviour
{

    public bool follow = true;
    public GameObject gameOver;

    public static Gamecontroller instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void ShowGameOver()
    {
        follow = false;
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlName)
    {
        SceneManager.LoadScene(lvlName);
    }
    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        //Application.Quit();
    }
}
