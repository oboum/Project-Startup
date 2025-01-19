using UnityEngine;

public class LoadNewScene : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        GameManager.instance.LoadNewScene(sceneName);
    }
}
