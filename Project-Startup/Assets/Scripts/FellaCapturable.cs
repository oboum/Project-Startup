using UnityEngine;

public class FellaCapturable : MonoBehaviour
{
    public bool canCapture = true;

    [SerializeField]
    private GameObject fella;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && !GameManager.instance.userFrozen && canCapture)
        {
            GameManager.instance.capturedFella(fella);

            if(GetComponentInParent<UncommanFellaPuzzel>() != null)
            {
                Destroy(transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
