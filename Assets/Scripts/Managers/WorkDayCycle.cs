using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;

public class WorkDayCycle : MonoBehaviour
{
    public static WorkDayCycle instance;
    [SerializeField] private GameObject[] Clients;
    private int currDay = 0;
    public DialogueRunner dialogueRunner;
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
        dialogueRunner.StartDialogue("Start");
    }
    private void SpawnClient(GameObject client)
    {

    }
}
