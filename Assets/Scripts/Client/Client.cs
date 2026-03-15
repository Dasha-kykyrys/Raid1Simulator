using UnityEngine;
using System.Collections.Generic;



public enum Mood
{
    Neutral
}
public enum ClientType
{
    Detective,
    Politician,
    Journalist,
    Gangster,
    Student,
    BartenderAssistant,
    MysticStranger,
    Random
}
public struct DrinkPreference
{
    public float StrengthEffect;     
    public float SweetnessEffect;
    public float BitternessEffect;
    public float SournessEffect;
}

public class Client : MonoBehaviour
{
    public string npcName;
    public Sprite portrait;
    public Drink[] prefer;
    public int alcoholtolerance;
    public ClientType type;



}