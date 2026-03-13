using UnityEngine;
using System.Collections.Generic;

public enum ClientType
{
    Detective,
    Politician,
    Journalist,
    Gangster,
    Student,
    BartenderAssistant,
    MysticStranger,
    
}

public enum Mood
{
    Neutral
}

[System.Serializable]
public struct DrinkPreference
{
    public float StrengthEffect;     
    public float SweetnessEffect;
    public float BitternessEffect;      
}

public class Client : MonoBehaviour
{
    public string ClientName;
    public Sprite Portrait;           
    public ClientType Type;
    public Mood CurrentMood = Mood.Neutral;
    public List<DrinkPreference> Preferences;

    public void Interact(Drink drink)
    {
        
    }

    public void UpdateMood(Drink drink)
    {

    }

}