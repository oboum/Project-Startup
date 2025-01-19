using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject curSceneWorld;

    public bool userFrozen = false;
    public bool interactingObj = false; // set this to true with object interactions so the camera doesn't move
    public bool interactingUI; // no need to update this one
    public bool canMove = true;

    public List<Fella> fellaDex; // all collected fellas not in home or concert
    public List<Fella> fellasInHomeRoom; // spawn fellas here when captured
    public List<Fella> fellasInConcertRoom;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (GameManager.instance == null)
        {
            instance = this;
            fellaDex = new List<Fella>();
            fellasInHomeRoom = new List<Fella>();
            fellasInConcertRoom = new List<Fella>();
        }
        else
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        interactingUI = EventSystem.current.IsPointerOverGameObject();
    }
}