using System;
using System.Collections.Generic;
using UnityEngine;

public class DrinksDetector : MonoBehaviour
{
    [SerializeField] List<Drink> allDrinks;
    public static DrinksDetector Instance;
    private void Awake()
    {
        Instance = this;
    }
    public Drink FindDrink(Drink madenDrink)
    {
        foreach (Drink drink in allDrinks)
        {
            if  (CompareLists(drink.alco, madenDrink.alco) &&
                CompareLists(drink.bases, madenDrink.bases) &&
                CompareLists(drink.ingredients, madenDrink.ingredients) &&
                CompareLists(drink.specialIngredients, madenDrink.specialIngredients))
            {
                return drink;
            }
        }

        return null;
    }

    private bool CompareLists(List<Ingredient> recipe, List<Ingredient> current)
    {
        if (recipe.Count != current.Count)
        {
            return false;
        }

        List<int> recipeIDs = new List<int>();
        List<int> currentIDs = new List<int>();

        foreach (var i in recipe) recipeIDs.Add(i.ingredientID);
        foreach (var i in current) currentIDs.Add(i.ingredientID);
        
        recipeIDs.Sort();
        currentIDs.Sort();

        for (int i = 0; i < recipeIDs.Count; i++)
        {
            if (recipeIDs[i] != currentIDs[i])
                return false;
        }

        return true;
    }
}
