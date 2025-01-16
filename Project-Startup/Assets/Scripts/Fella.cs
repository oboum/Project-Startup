using UnityEngine;

public class Fella : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag =="ChangeScene")
        {
            collision.transform.GetComponent<SceneSwitcher1>().SwitchScene();
        }
    }
}
