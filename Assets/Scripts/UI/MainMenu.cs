using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void LoadScene()
    {
        Time.timeScale = 1f;
        LoadingScreenManager.Instance.SwitchScene(1);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
    public void ReturnMainMenu()
    {
        Time.timeScale = 1f;
        LoadingScreenManager.Instance.SwitchScene(0);
    }
}
