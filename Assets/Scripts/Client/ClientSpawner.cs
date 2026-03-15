using System.Collections.Generic;
using UnityEngine;

public class ClientSpawner : MonoBehaviour
{

    public List<Client> clientPrefabs;

    public Transform spawnPoint;

    public Client SpawnClient()
    {
        int index = Random.Range(0, clientPrefabs.Count);

        Client client = Instantiate(clientPrefabs[index], spawnPoint.position, Quaternion.identity);

        return client;
    }

}
