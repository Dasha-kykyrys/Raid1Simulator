using UnityEngine;
using UnityEngine.UI;

public class DrunkScrollBar : MonoBehaviour
{
    [SerializeField] Scrollbar drunk;
    public void UpdateDrunk(float newValue)
    {
        drunk.value = newValue;
    }
}
