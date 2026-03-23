using UnityEngine;

[CreateAssetMenu(fileName = "NPC", menuName = "Scriptable Objects/Drink")]
public class Drink : ScriptableObject
{
    public string drinkName;

    public Ingredient[] ingredients; 

    public float sweetness;
    public float bitterness;
    public float sourness;
    public float intoxication;

}