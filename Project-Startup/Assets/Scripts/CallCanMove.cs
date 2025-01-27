using UnityEngine;

public class CallCanMove : MonoBehaviour
{
    public void CallCanMoveGM(bool b)
    {
        GameManager.instance.SetCanMove(b);
    }
}
