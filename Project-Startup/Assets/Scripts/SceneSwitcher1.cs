using UnityEngine;

public class SceneSwitcher1 : MonoBehaviour
{
    [SerializeField]
    private GameObject sceneCurrentUI;
    [SerializeField]
    private GameObject sceneCurrentWorld;
    [SerializeField]
    private GameObject sceneNewUI;
    [SerializeField]
    private GameObject sceneNewWorld;

    public void SwitchScene()
    {
        if (!GameManager.instance.userFrozen)
        {
            sceneNewUI.SetActive(true);
            sceneNewWorld.SetActive(true);
            sceneCurrentUI.SetActive(false);
            sceneCurrentWorld.SetActive(false);
            GameManager.instance.curSceneWorld = sceneNewWorld;
        }
    }
}