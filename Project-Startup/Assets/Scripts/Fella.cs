using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Fella : MonoBehaviour
{
    [SerializeField]
    private int score;
    [UnityEngine.Range(1, 100)]
    private int fatigue;
    [SerializeField]
    private string fellaName;
    [SerializeField]
    private string descriptionText;
    // could use enum for fatigue
    [SerializeField]
    public float cosmeticHeight;
   [SerializeField] List<Cosmetic> cosmetics;
    [SerializeField] List<Cosmetic> cosmeticPrefabs;


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
        if (collision.transform.tag == "ChangeScene")
        {
            collision.transform.GetComponent<SceneSwitcher1>().SwitchScene();
        }
    }

    public int getScore()
    {
        int bonus = 0;
        foreach (Cosmetic c in cosmetics)
        {
            bonus += c.ScoreBonus;
        }
        return score + bonus;
    }

    void equipCosmetic(Cosmetic instance,Cosmetic c)
    {
        instance.transform.position = transform.position + new Vector3(0, cosmeticHeight, 0);
        cosmetics.Add(instance);
        cosmeticPrefabs.Add(c);
        GameManager.instance.cosmeticsInventory.Remove(c);
    }
    private void OnMouseOver()
    {
        //fella inspection
        if (Input.GetMouseButtonDown(1) && !GameManager.instance.userFrozen)
        {
            GameManager.instance.canMove = false;
            Canvas canvas = FindAnyObjectByType<Canvas>();
            GameObject tempInspector = Instantiate(GameManager.instance.fellaInspectionScreen, canvas.transform, false);

            TMP_Text nameText = tempInspector.transform.Find("FellaName")?.GetComponent<TMP_Text>();
            TMP_Text rarityText = tempInspector.transform.Find("FellaRarity")?.GetComponent<TMP_Text>();
            TMP_Text fatigueText = tempInspector.transform.Find("FellaFatigue")?.GetComponent<TMP_Text>();
            TMP_Text descText = tempInspector.transform.Find("FellaDescription")?.GetComponent<TMP_Text>();
            TMP_Dropdown dropdown = tempInspector.transform.Find("CosmeticDropdown")?.GetComponent<TMP_Dropdown>();

            if (nameText != null) nameText.text = fellaName;
            if (rarityText != null) rarityText.text = "Rare MF prolly";
            if (fatigueText != null) fatigueText.text = "Maybe tired?";
            if (descText != null) descText.text = descriptionText;

            List<string> cosmeticNames = new List<string>() { "Select cosmetic" };

            foreach (Cosmetic cosmetic in GameManager.instance.cosmeticsInventory)
            {
                cosmeticNames.Add(cosmetic.name);
            }
            cosmeticNames.Add("None");
            dropdown.ClearOptions();
            dropdown.AddOptions(cosmeticNames);

            dropdown.onValueChanged.AddListener(delegate
            {
                string selectedCosmeticName = dropdown.options[dropdown.value].text;
                print(selectedCosmeticName);
                if (selectedCosmeticName == "None")
                {
                    List<Transform> toDestroy = new List<Transform>();
                    foreach (Transform child in transform)
                    {
                        Cosmetic childCosmetic = child.GetComponent<Cosmetic>();
                        if ( childCosmetic!= null)
                        {
                            GameManager.instance.cosmeticsInventory.Add(cosmeticPrefabs.Find(cosmetic=> childCosmetic.Name==cosmetic.Name));
                            cosmetics.Remove(childCosmetic);
                            toDestroy.Add(child);
                        }
                    }
                    foreach(Transform transform in toDestroy)
                    {
                        Destroy(transform.gameObject);
                    }
                    return;
                }
                else
                {
                    Cosmetic cosmeticToAdd = GameManager.instance.cosmeticsInventory.Find(cosmetic => cosmetic.name == selectedCosmeticName);
                    Cosmetic cosmeticInstance = Instantiate(cosmeticToAdd, transform);
                    equipCosmetic(cosmeticInstance, cosmeticToAdd);
                }
            });

            tempInspector.GetComponentInChildren<Button>().onClick.AddListener(() =>
            {
                Destroy(tempInspector);
                GameManager.instance.canMove = true;
            });
        }
    }
}
