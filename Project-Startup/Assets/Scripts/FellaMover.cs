using UnityEngine;

public class FellaMover : MonoBehaviour
{
    private bool followMouse = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(followMouse == true)
        {
            if(Input.GetMouseButtonUp(0))
            {
                followMouse = false;
                transform.parent = GameManager.instance.curSceneWorld.transform;
            }
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));
        }
    }

    private void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
        {
            followMouse = true;
            transform.parent = null;
        }
    }
}
