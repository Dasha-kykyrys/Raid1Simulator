using UnityEditor.Build;
using UnityEngine;

public class DrinkShaker : MonoBehaviour
{
    private const int maxAlcohol = 1;
    private const int maxBase = 2;
    private const int maxIngredient = 3;
    private const int maxSpecialIngredient = 1;
    private int alcoholCount, baseCount, ingredientCount, specialIngredientCount = 0;
    private bool isAvailable = false;
    public static DrinkShaker instance;
    private float sweetness, bitterness, sourness, intoxication;
    private void Start()
    {
        instance = this;

    }
    public int AddIngredients(Ingredient ingredient, IngredientType type)
    {
        switch (type)
        {
            case IngredientType.Alcohol:
                if (alcoholCount >= maxAlcohol)
                {
                    Debug.Log("Достигнут максимум алкоголя");
                    return 0;
                }
                alcoholCount++;
                isAvailable = true;
                break;

            case IngredientType.Base:
                if (baseCount >= maxBase)
                {
                    Debug.Log("Достигнут максимум базы");
                    return 0;
                }
                baseCount++;
                isAvailable = true;
                break;

            case IngredientType.Ingredient:
                if (ingredientCount >= maxIngredient)
                {
                    Debug.Log("Достигнут максимум ингредиентов");
                    return 0;
                }
                ingredientCount++;
                break;

            case IngredientType.SpecialIngredient:
                if (specialIngredientCount >= maxSpecialIngredient)
                {
                    Debug.Log("Достигнут максимум спец. ингредиентов");
                    return 0;
                }
                specialIngredientCount++;
                break;

            default:
                Debug.Log("Неизвестный тип ингредиента");
                return 0;
        }

        // Добавляем характеристики ингредиента
        sweetness += ingredient.sweetness;
        bitterness += ingredient.bitterness;
        sourness += ingredient.sourness;
        intoxication += ingredient.intoxication;

        Debug.Log($"{sweetness} {bitterness} {sourness} {intoxication}");
        return 1;
    }
    public void MakeCoctail()
    {
        if (isAvailable)
        {
            Debug.Log($"Готово {sweetness} {bitterness} {sourness} {intoxication}");
        }
        else
        {
            Debug.Log($"Добавьте основу или алкоголь");
        }
    }
    public void ResetShaker()
    {
        alcoholCount = 0;
        baseCount = 0;
        ingredientCount = 0;
        specialIngredientCount = 0;
        sweetness = 0;
        bitterness = 0;
        sourness = 0;
        intoxication = 0;
        isAvailable = false;
    }
}
