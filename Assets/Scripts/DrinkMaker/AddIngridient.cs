using System;
using UnityEditor.PackageManager;
using UnityEngine;

public class AddIngridient : MonoBehaviour
{

    public int count;
    [SerializeField] Ingredient ingredient;
    private void Start()
    {
        count = ingredient.startCount;
    }
    public void AddIngredients()
    {
       
        if(count != 0)
        {
            count -= DrinkShaker.instance.AddIngredients(ingredient, ingredient.type);
            
        }
        else
        {
            Debug.Log("Ингредиент закончился");
        }
    }
}
