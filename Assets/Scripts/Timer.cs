using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class Timer : MonoBehaviour
{
    public float workTime = 480f;
    public float currTime = 0f;
    public static Timer instance;
    public bool isStatic = true;
    [SerializeField] TextMeshProUGUI timerText;
    private void Awake()
    {
        instance = this;
    }
    private void FixedUpdate()
    {
        if (!isStatic)
        {
            currTime += Time.fixedDeltaTime;
            UpdateText();
        }
    }
    public void ChangeTime(float changes, bool s_isStatic)
    {
        isStatic = s_isStatic;
        currTime += changes;
        UpdateText();
    }
    private void UpdateText()
    {
        Debug.Log(currTime);
        timerText.text = currTime.ToString();
    }
}
