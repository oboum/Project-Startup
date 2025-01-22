using Unity.Mathematics;
using UnityEngine;

public class Bait : MonoBehaviour
{
    [SerializeField]
    private GameObject correctBait;

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            foreach(GameObject bait in GameManager.instance.BaitInv)
            {
                if(bait == correctBait)
                {
                    Instantiate(bait, transform.position, quaternion.identity);
                    GameManager.instance.BaitInv.Remove(bait);
                    GetComponentInParent<LegendaryMosterPuzzel>().showFella();
                    break;
                }
            }
        }
    }
}
