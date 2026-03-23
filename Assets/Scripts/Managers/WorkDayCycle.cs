using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Yarn;
using Yarn.Unity;

public class WorkDayCycle : MonoBehaviour
{
    public static WorkDayCycle instance;
    [SerializeField] private GameObject[] Clients;
    private int currDay = 1;
    public DialogueRunner dialogueRunner;
    [SerializeField] Transform clientSpawn, clientStatsSpawn;
    [SerializeField] GameObject[] randomclients;
    private string currClientName;
    private Client clientData;
    private int clientPrefVariant;
    private int prefInd;
    private GameObject client, clientStats;
    [SerializeField] GameObject clientStatsPrefab;
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
        spawnClient();
        StartDialogue();

    }
    public string MakeDialogue(int dialogueInd)
    {
        string dialogue = string.Empty;
        prefInd = Random.Range(0, 3);
        clientPrefVariant = dialogueInd;
        switch (clientPrefVariant)
        {
            case 1:
                dialogue = $"{clientData.Preferences[prefInd].PrefText}";
                break;
            case 2:
                dialogue = $"{clientData.Drinks[prefInd].PrefText}";
                break;
            case 3:
                dialogue = $"{clientData.Ingredients[prefInd].PrefText}";
                break;
        }
        
        return dialogue;
    }
    private void StartDialogue()
    {

        dialogueRunner.StartDialogue($"{currClientName}_greet");
    }
    public void StartReactDialogue(Drink drink)
    {
        clientData.Mood = ChangeMood(drink);
        if (clientData.Mood <0.5f)
        {
            dialogueRunner.StartDialogue($"{currClientName}_badreact");
        }
        else if (clientData.Mood < 1f)
        {
            dialogueRunner.StartDialogue($"{currClientName}_normalreact");
        }
        else
        {
            dialogueRunner.StartDialogue($"{currClientName}_goodreact");
        }

    }
    public void EndClientSession()
    {
        Destroy(clientStats);
        Destroy(client);
        StartCycle();
    }
    public float ChangeMood(Drink drink)
    {
        clientData.DrunkLevel += drink.Strength / 2;
        FindAnyObjectByType<DrunkScrollBar>().UpdateDrunk(clientData.DrunkLevel);
        switch (clientPrefVariant)
        {
            case 1:
                float prefStrength = clientData.Preferences[prefInd].StrengthEffect;
                float prefSweetness = clientData.Preferences[prefInd].SweetnessEffect;
                float prefBitterness = clientData.Preferences[prefInd].BitternessEffect;
                float clientChange = 0f;
                if (prefSweetness != -1)
                {
                    clientChange += ComparePref(prefSweetness, drink.Sweetness);
                }
                if (prefStrength != -1)
                {
                    clientChange += ComparePref(prefStrength, drink.Strength);
                }
                if (prefBitterness != -1)
                {
                    clientChange += ComparePref(prefBitterness, drink.Bitterness);
                }
                FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
                return clientData.Mood + clientChange; 
            case 2:
                if(drink.DrinkName == clientData.Drinks[prefInd].drink.DrinkName)
                {
                    FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
                    return clientData.Mood + 0.5f;
                }
                FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
                return clientData.Mood - 0.5f;
            case 3:
                bool isIngredietInDrink = true;
                foreach (Ingredient indregient in clientData.Ingredients[prefInd].ingredient)
                {
                    if(!drink.allIngredients.Contains(indregient))
                    {
                        isIngredietInDrink = false; 
                        break;
                    }
                }
                if (isIngredietInDrink)
                {
                    FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
                    return clientData.Mood + 0.5f;
                }
                FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
                return clientData.Mood - 0.5f;
        }
        FindAnyObjectByType<MoodScrollBar>().UpdateMood(clientData.Mood);
        return clientData.Mood;
    }
    private float ComparePref(float pref, float drinkStat) 
    {
        if ((pref - drinkStat) < 1f)
        {
            return 0.25f;
        }
        return -Mathf.Abs((pref - drinkStat) / 2);
    }
    private void spawnClient()
    {
        clientStats = Instantiate(clientStatsPrefab, clientStatsSpawn);
        client = Instantiate(randomclients[Random.Range(0, randomclients.Length)], clientSpawn);
        clientData = client.GetComponent<Client>();
        client.GetComponent<SpriteRenderer>().sprite = clientData.sprite;
        currClientName = clientData.ClientName;
    }
}
