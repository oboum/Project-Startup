using UnityEngine;

public class OpenInv : MonoBehaviour
{
    public void OpenInventory(GameObject content)
    {
        GameManager.instance.openInv(content);
    }
}
