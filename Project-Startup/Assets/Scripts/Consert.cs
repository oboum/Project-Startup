using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Consert : MonoBehaviour
{
    List<GameObject> fellas = new List<GameObject>();

    private bool consertGoing = false;
    private float timer;
    [SerializeField]
    private float consertTime;

    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject scoreScreen;
    [SerializeField]
    private TextMeshProUGUI scoreScreenScoreText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartConsert()
    {
        fellas.Clear();

        foreach (Transform child in transform.transform)
        {
            if (child.tag == "FellaPos" && child.childCount >= 1)
            {
                fellas.Add(child.GetComponentInChildren<Fella>().gameObject);
            }

        }

        foreach(GameObject fella in fellas)
        {
            fella.GetComponent<AudioSource>().Play();
        }

        timer = 0;
        score = 0;
        scoreText.text = "score: " + score;

        consertGoing = true;
        GameManager.instance.userFrozen = true;
        StartCoroutine(Timer());
    }

    public void StopConsert()
    {
        foreach (GameObject fella in fellas)
        {
            fella.GetComponent<AudioSource>().Stop();
        }
        consertGoing = false;
        GameManager.instance.userFrozen = false;
        GameManager.instance.addEXP(score);
        scoreScreen.SetActive(true);
        scoreScreenScoreText.text = "EXP: " + score;
    }

    public IEnumerator Timer()
    {
        while (consertGoing)
        {
            yield return new WaitForSeconds(1);
            foreach (GameObject fella in fellas)
            {
                score += fella.GetComponent<Fella>().getScore();
            }
            scoreText.text = "score: " + score;

            timer++;
            if (timer >= consertTime)
            {
                StopConsert();
                StopCoroutine(Timer());
            }
        }
    }
}
