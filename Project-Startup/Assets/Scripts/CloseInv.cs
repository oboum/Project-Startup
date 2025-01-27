using UnityEngine;

public class CloseInv : MonoBehaviour
{
    public void CloseInventory(GameObject content)
    {
        foreach (Transform item in content.transform)
        {
            Destroy(item.gameObject);
        }
    }
}
