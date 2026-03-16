using UnityEngine;
using UnityEngine.Rendering;

public class WorkDayCycle : MonoBehaviour
{
    public static WorkDayCycle instance;
    [SerializeField] private GameObject[] Clients;
    [SerializeField] Days[] days;
    private int currDay = 0;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartCycle();
    }
    public void StartCycle()
    {
        if (currDay < days.Length)
        {
            Days day = ScriptableObject.CreateInstance<Days>();
            day = days[currDay];

            foreach (StoryNode node in day.storyPart)
            {
                Timer.instance.ChangeTime(node.duration, true);
            }
            Timer.instance.ChangeTime(0, false);
        }
        else
        {
            Debug.Log("Конец демо");
        }
    }
    private void SpawnClient(GameObject client)
    {

    }
}
