using System.Collections.Generic;
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
        if (followMouse == true)
        {
            transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -Camera.main.transform.position.z));


            if (Input.GetMouseButtonUp(0))
            {
                followMouse = false;
                transform.parent = GameManager.instance.curSceneWorld.transform;
                List<Transform> positions = new List<Transform>();

                foreach (Transform child in transform.parent.transform)
                {
                    if (child.tag == "FellaPos")
                    {
                        positions.Add(child);
                    }

                }

                if (positions.Count > 0)
                {
                    int closest = 0;
                    for (int i = 0; i < positions.Count; i++)
                    {
                        if ((transform.position - positions[i].position).magnitude < (transform.position - positions[closest].position).magnitude)
                        {
                            closest = i;
                        }
                    }

                    transform.position = positions[closest].position;
                    print(transform.position);
                    print(positions[closest].position);
                }
            }
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
