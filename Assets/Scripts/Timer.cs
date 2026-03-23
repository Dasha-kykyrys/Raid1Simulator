using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public float workTime = 480f;
    public float currTime = 0f;
    public static Timer instance;
    [SerializeField] TextMeshProUGUI timerText;
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        currTime += Time.fixedDeltaTime;
        UpdateText();
    }
    private void UpdateText()
    {
        timerText.text = currTime.ToString();
    }
}
