using UnityEngine;
using UnityEngine.EventSystems;
public class PanZoomRotate : MonoBehaviour
{
    public float fovMin = 20f;
    public float fovMax = 60f;
    public float panSpeed = 0.5f;
    public float zoomSpeed = 10f;

    public float leftLimit;
    public float rightLimit;
    public float backwardLimit;
    public float forwardLimit;

    //public float rotationSpeed = 100f;

   // public Vector2 pitchLimits = new Vector2(10f, 80f);

    Vector3 touchStart;
    float yaw = 0f;
    float pitch;
    private void Awake()
    {/*
        yaw = Camera.main.transform.eulerAngles.y;
        pitch = Camera.main.transform.eulerAngles.x;*/
    }
    void Update()
    {
        if (GameManager.instance.interactingUI || GameManager.instance.interactingObj || !GameManager.instance.canMove) return;

        if (Input.GetMouseButtonDown(0))
            touchStart = getWorldPoint(Input.mousePosition);
        /*else if (Input.GetMouseButtonDown(1))
        {
            yaw = Camera.main.transform.eulerAngles.y;
            pitch = Camera.main.transform.eulerAngles.x;
        }*/

        if (Input.GetMouseButton(0))
        {
            Vector3 direction = touchStart - getWorldPoint(Input.mousePosition);
            direction.y = 0;

            Camera.main.transform.position += direction * panSpeed;
        }
        /* else if (Input.GetMouseButton(1))
         {
             float mouseX = Input.GetAxis("Mouse X");
             float mouseY = Input.GetAxis("Mouse Y");

             yaw += mouseX * rotationSpeed * Time.deltaTime;

             pitch -= mouseY * rotationSpeed * Time.deltaTime;
             pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

             Camera.main.transform.eulerAngles = new Vector3(pitch, yaw, 0);
         }*/

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (Mathf.Abs(scroll) > 0.01f)
            Camera.main.fieldOfView = Mathf.Clamp(Camera.main.fieldOfView - scroll * zoomSpeed, fovMin, fovMax);
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            transform.position.y,
            Mathf.Clamp(transform.position.z, backwardLimit, forwardLimit));
    }

    Vector3 getWorldPoint(Vector3 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero); // could change this with collision layers and adjust cam height if needed
        if (groundPlane.Raycast(ray, out float hitDistance))
        {
            return ray.GetPoint(hitDistance);
        }
        return Vector3.zero;
    }
}