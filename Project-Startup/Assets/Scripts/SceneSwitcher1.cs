using UnityEngine;

public class SceneSwitcher1 : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneNewUI;
    [SerializeField]
    private GameObject sceneNewWorld;

    public void SwitchScene()
    {
        sceneNewUI.SetActive(true);
        sceneNewWorld.SetActive(true);
        GameManager.instance.curSceneUI.SetActive(false);
        GameManager.instance.curSceneWorld.SetActive(false);
        GameManager.instance.curSceneUI = sceneNewUI;
        GameManager.instance.curSceneWorld = sceneNewWorld;
    }
}