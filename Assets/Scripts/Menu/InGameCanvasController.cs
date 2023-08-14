using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameCanvasController : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject winPanel;


    private void Start()
    {
        gamePanel.SetActive(true);
        winPanel.SetActive(false);
    }

    public void ChangeScene(string _sceneName)
    {
        SceneManager.LoadScene(_sceneName);
    }
    public void RelodeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene("Title");
    }

    public string GetSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

}
