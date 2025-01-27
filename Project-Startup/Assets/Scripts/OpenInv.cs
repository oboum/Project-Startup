using UnityEngine;

public class OpenInv : MonoBehaviour
{
    public GameObject inv;

    public void OpenInventory(GameObject content)
    {
        GameManager.instance.openInv(content);
    }
}
