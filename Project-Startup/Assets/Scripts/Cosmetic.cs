using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class Cosmetic : MonoBehaviour 
{
    public string Name;
    public int ScoreBonus;
    public MeshFilter Mesh;
    public Material Material;

    void Awake()
    {
        Mesh = GetComponent<MeshFilter>();
        Material = GetComponent<Material>();
    }
}
