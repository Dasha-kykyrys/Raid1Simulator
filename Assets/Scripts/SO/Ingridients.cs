using UnityEngine;
[CreateAssetMenu(fileName = "NPC", menuName = "Scriptable Objects/Ingredients")]
public class Ingredient : ScriptableObject
{
    public string ingredientName;
    public int ingredientID;
    public int startCount;
    public float sweetness;
    public float bitterness;
    public float sourness;
    public float strength;
    public SpecialEffect specialEffect;
    public IngredientType type;
}


public enum SpecialEffect
{
    None,
    
}
public enum IngredientType
{
    Base,
    Alcohol,
    Ingredient,
    SpecialIngredient
}