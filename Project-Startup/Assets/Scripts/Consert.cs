using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Concert : MonoBehaviour
{
    List<GameObject> fellas = new List<GameObject>(); // singers
    List<GameObject> dancingFellas = new List<GameObject>(); // bystanders

    private bool concertGoing = false;
    bool concertEnded = false;
    private float timer;
    [SerializeField]
    private float concertTime;

    private int score;
    [SerializeField]
    private TextMeshProUGUI scoreText;
    [SerializeField]
    private GameObject scoreScreen;
    [SerializeField]
    private NumberGoUp scoreScreenScoreText;

    [SerializeField] Transform concertCamTransform;
    private Vector3 originalCamPos;
    private Quaternion originalCamRot;
    [SerializeField] private float camLerpSpeed = 2f;

    [SerializeField]
    private AudioSource BG;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(concertEnded)
        {
            scoreText.text = "Score: " + score;
            concertEnded = false;
        }
    }

    public void StartConsert()
    {
        fellas.Clear();
        originalCamPos = Camera.main.transform.position;
        originalCamRot = Camera.main.transform.rotation;

        foreach (Transform child in transform.transform)
        {
            if (child.tag == "FellaPos" && child.childCount >= 1)
            {
                fellas.Add(child.GetComponentInChildren<Fella>().gameObject);
            }
            if(child.tag == "Fella")
            {
                dancingFellas.Add(child.gameObject);
            }
        }

        BG.Stop();

        foreach(GameObject fella in fellas)
        {
            fella.GetComponent<AudioSource>().Play();
        }
        foreach(GameObject dancingFella in dancingFellas)
        {
            dancingFella.AddComponent<Dancing>();

        }

        timer = 0;
        score = 0;

        concertGoing = true;
        GameManager.instance.userFrozen = true; 

        StartCoroutine(lerpCamera(concertCamTransform.position, concertCamTransform.rotation));
        print("thfeffwe");
        StartCoroutine(Timer());

    }

    public void StopConsert()
    {
        foreach (GameObject fella in fellas)
        {
            fella.GetComponent<AudioSource>().Stop();
        }
        foreach(GameObject dancingFella in dancingFellas)
        {
            Destroy(dancingFella.GetComponent<Dancing>());
        }
        BG.Play();
        concertGoing = false;
        concertEnded = true;
        GameManager.instance.userFrozen = false;
        GameManager.instance.addEXP(score);
        scoreScreen.SetActive(true);
        scoreScreenScoreText.SetTarget(score);
        StartCoroutine(lerpCamera(originalCamPos, originalCamRot));

    }

    public IEnumerator Timer()
    {
        while (concertGoing)
        {
            yield return new WaitForSeconds(1);
            foreach (GameObject fella in fellas)
            {
                score += fella.GetComponent<Fella>().getScore();
            }
            scoreText.text = "score: " + score;

            timer++;
            if (timer >= concertTime)
            {
                StopConsert();
                StopCoroutine(Timer());
                StartCoroutine(lerpCamera(originalCamPos, originalCamRot));

                print("wth");
            }
        }
    }
    IEnumerator lerpCamera(Vector3 targetPosition, Quaternion targetRotation)
    {
        Camera mainCamera = Camera.main;
        while (Vector3.Distance(mainCamera.transform.position, targetPosition) > 0.01f || Quaternion.Angle(mainCamera.transform.rotation, targetRotation) > 0.1f)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetPosition, Time.deltaTime * camLerpSpeed);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetRotation, Time.deltaTime * camLerpSpeed);

            yield return null;
        }

        mainCamera.transform.position = targetPosition;
        mainCamera.transform.rotation = targetRotation;
    }
}
