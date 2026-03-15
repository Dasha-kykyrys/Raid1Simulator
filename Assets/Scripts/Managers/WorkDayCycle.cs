using UnityEngine;

public class WorkDayCycle : MonoBehaviour
{
    public static WorkDayCycle instance;
    [SerializeField] private GameObject[] Clients;
    private void Awake()
    {
        instance = this;
    }
    public void StartCycle()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnClient(Clients[Random.Range(0, Clients.Length)]);
            Client currClient = FindFirstObjectByType<Client>();
            if (currClient != null)
            {

            }
        }
    }
    private void SpawnClient(GameObject client)
    {

    }
}
