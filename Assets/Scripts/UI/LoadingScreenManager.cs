using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;

    [SerializeField] GameObject loadingScreen;
    [SerializeField] Slider loadingScreenSlider;
    [SerializeField] float delay = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void SwitchScene(int id)
    {
        loadingScreen.SetActive(true);
        loadingScreenSlider.value = 0;
        StartCoroutine(LoadScene(id));
    }

    IEnumerator LoadScene(int id)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(id);
        while (!operation.isDone)
        {
            loadingScreenSlider.value = operation.progress;
            yield return null;
        }
        yield return new WaitForSeconds(delay);
        loadingScreen.SetActive(false);
    }
}
