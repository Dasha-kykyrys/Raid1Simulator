using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class DrinkShaker : MonoBehaviour
{
    private const int maxAlcohol = 1;
    private const int maxBase = 2;
    private const int maxIngredient = 3;
    private const int maxSpecialIngredient = 1;
    private List<Ingredient> c_alco, c_base, c_ingredient, c_specIngredient;
    private bool isAvailable = false;
    public static DrinkShaker instance;
    private float sweetness, bitterness, sourness, intoxication;
    private void Start()
    {
        instance = this;
        c_alco = new List<Ingredient>();
        c_base = new List<Ingredient>();
        c_ingredient = new List<Ingredient>();
        c_specIngredient = new List<Ingredient>();

    }
    public int AddIngredients(Ingredient ingredient, IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Alcohol:
                if (c_alco.Count >= maxAlcohol)
                {
                    Debug.Log("Достигнут максимум алкоголя");
                    return 0;
                }
                c_alco.Add(ingredient);
                isAvailable = true;
                break;

            case IngredientType.Base:
                if (c_base.Count >= maxBase)
                {
                    Debug.Log("Достигнут максимум базы");
                    return 0;
                }
                c_base.Add(ingredient);
                isAvailable = true;
                break;

            case IngredientType.Ingredient:
                if (c_ingredient.Count >= maxIngredient)
                {
                    Debug.Log("Достигнут максимум ингредиентов");
                    return 0;
                }
                c_ingredient.Add(ingredient);
                isAvailable = true;
                break;

            case IngredientType.SpecialIngredient:
                if (c_specIngredient.Count >= maxSpecialIngredient)
                {
                    Debug.Log("Достигнут максимум спецмального ингредиента");
                    return 0;
                }
                c_specIngredient.Add(ingredient);
                isAvailable = true;
                break;

            default:
                Debug.Log("Неизвестный тип ингредиента");
                return 0;
        }
        return 1;
    }
    public void MakeCoctail()
    {
        if (isAvailable)
        {
            Drink drink = ScriptableObject.CreateInstance<Drink>();

            drink.alco = new List<Ingredient>(c_alco);
            drink.bases = new List<Ingredient>(c_base);
            drink.ingredients = new List<Ingredient>(c_ingredient);
            drink.specialIngredients = new List<Ingredient>(c_specIngredient);

            // ВАЖНО
            drink.RecalculateStats();

            Drink detectedDrink = DrinksDetector.Instance.FindDrink(drink);

            if (detectedDrink != null)
            {
                drink = detectedDrink;
                Debug.Log($"{drink.DrinkName} {drink.Sourness} {drink.Sweetness} {drink.Bitterness} {drink.Strength}");
            }
            else
            {
                drink.DrinkName = "Авторский";
                Debug.Log($"{drink.DrinkName} {drink.Sourness} {drink.Sweetness} {drink.Bitterness} {drink.Strength}");
            }

            ResetShaker();
        }
        else
        {
            Debug.Log("Добавьте основу или алкоголь");
        }
    }
    public void ResetShaker()
    {
        
        c_alco.Clear();
        c_base.Clear();
        c_ingredient.Clear();
        c_specIngredient.Clear();
        sweetness = 0;
        bitterness = 0;
        sourness = 0;
        intoxication = 0;
        isAvailable = false;
    }
}
