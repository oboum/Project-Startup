using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoader : MonoBehaviour
{
    [SerializeField]
    private string sceneName;
    public void LoadNewScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
