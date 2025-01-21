using TMPro;
using UnityEngine;
public class NumberGoUp : MonoBehaviour
{
    [SerializeField] public TMP_Text textLerp;
    [SerializeField] float lerpSpeed = 1f;

    float currentValue = 0f;
    float targetValue = 100f;
    bool isLerping = false;

    private void Update()
    {
        if (isLerping)
        {
            currentValue = Mathf.Lerp(currentValue, targetValue, Time.deltaTime * lerpSpeed);

            textLerp.text = Mathf.RoundToInt(currentValue).ToString();

            if (Mathf.Abs(currentValue - targetValue) < 0.5f)
            {
                currentValue = targetValue;
                textLerp.text = targetValue.ToString();
                Destroy(this);
            }
        }
    }

    public void SetTarget(float value)
    {
        targetValue = value;
        isLerping = true;
    }
}