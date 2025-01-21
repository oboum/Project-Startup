using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject curSceneWorld;

    public bool userFrozen = false;
    public bool interactingObj = false; // set this to true with object interactions so the camera doesn't move
    public bool interactingUI; // no need to update this one
    public bool canMove = true;

    public GameObject fellaInspectionScreen;

    [SerializeField]
    public List<Cosmetic> cosmeticsInventory;

    public List<GameObject> newFellas;

    [SerializeField]
    private List<GameObject> ownedFellas;

    [SerializeField]
    private int exp;

    void Awake()
    {
        if (GameManager.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void LoadNewScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void spawnFellas()
    {
        foreach (GameObject fella in newFellas)
        {
            ownedFellas.Add(fella);
        }
        newFellas.Clear();

        for (int i = 0; i < ownedFellas.Count; i++)
        {
            GameObject fella = Instantiate(ownedFellas[i], curSceneWorld.transform);
            fella.transform.position = new Vector3(i,1,0);
        }
    }

    public void capturedFella(GameObject fella)
    {
        newFellas.Add(fella);
    }
    
    void Update()
    {
        if (!interactingUI)
        {
               interactingUI = EventSystem.current.IsPointerOverGameObject() && Input.GetMouseButtonDown(0);
        }
        else
        {
            interactingUI = !Input.GetMouseButtonUp(0);
        }
    }

    public void addEXP(int xp)
    {
        exp += xp;
    }
}
