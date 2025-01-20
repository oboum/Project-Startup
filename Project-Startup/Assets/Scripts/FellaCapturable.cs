using UnityEngine;

public class FellaCapturable : MonoBehaviour
{
    [SerializeField]
    private GameObject fella;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.userFrozen)
        {
            GameManager.instance.capturedFella(fella);
            Destroy(gameObject);
        }
    }
}
