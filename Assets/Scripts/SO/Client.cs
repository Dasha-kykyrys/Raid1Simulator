using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public struct StatPreference
{
    public string PrefText;
    public int StrengthEffect;     
    public int SweetnessEffect;
    public int BitternessEffect;      
}
[System.Serializable]
public struct DrinkPreference
{
    public string PrefText;
    public Drink drink;
}
[System.Serializable]
public struct IngredientPreference
{
    public string PrefText;
    public List<Ingredient> ingredient;
}
public class Client : MonoBehaviour
{
    public string ClientName;
    public Sprite sprite;
    public float Mood = 0.5f;
    public float DrunkLevel = 0f;
    public List<StatPreference> Preferences;
    public List<DrinkPreference> Drinks;
    public List<IngredientPreference> Ingredients;

}