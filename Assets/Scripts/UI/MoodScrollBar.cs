using UnityEngine;
using UnityEngine.UI;

public class MoodScrollBar : MonoBehaviour
{
    [SerializeField] Scrollbar mood;
    public void UpdateMood(float newValue)
    {
        mood.value = newValue;
    }
}
