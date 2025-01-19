using UnityEngine;

public class FirstScene : MonoBehaviour
{
    void Start()
    {
        GameManager.instance.curSceneWorld = gameObject;
        GameManager.instance.spawnFellas();
    }
}
