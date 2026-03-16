using System.Collections.Generic;
using UnityEngine;
public enum SpecialEffects
{
    xz
}
[CreateAssetMenu(fileName = "NPC", menuName = "Scriptable Objects/Drink")]

public class Drink : ScriptableObject
{
    [Header("Основная информация")]
    public string DrinkName;
    public Sprite sprite;

    [Header("Ингредиенты")]
    public List<Ingredient> alco;
    public List<Ingredient> bases;
    public List<Ingredient> ingredients;
    public List<Ingredient> specialIngredients;

    [Header("Свойства напитка")]
    public float Strength;              
    public float Sweetness;
    public float Sourness;
    public float Bitterness;            
    public SpecialEffects SpecialEffect;
    private void OnValidate()
    {
        RecalculateStats();
    }

    public void RecalculateStats()
    {
        Strength = 0;
        Sweetness = 0;
        Bitterness = 0;
        Sourness = 0;

        AddIngredientsStats(alco);
        AddIngredientsStats(bases);
        AddIngredientsStats(ingredients);
        AddIngredientsStats(specialIngredients);
    }

    void AddIngredientsStats(List<Ingredient> list)
    {
        if (list == null) return;

        foreach (var ing in list)
        {
            if (ing == null) continue;

            Strength += ing.strength;
            Sweetness += ing.sweetness;
            Bitterness += ing.bitterness;
            Sourness += ing.sourness;
        }
    }
}
