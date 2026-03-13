using UnityEngine;

public enum SpecialEffects
{
    xz
}
public class Drink : ScriptableObject
{
    [Header("Основная информация")]
    public string DrinkName;                            
    [TextArea]

    [Header("Свойства напитка")]
    public float Strength;              
    public float Sweetness;             
    public float Bitterness;            
    public SpecialEffects SpecialEffect;         

    public void ApplyEffect(Client client)
    {
        if (client == null) return;

        client.UpdateMood(this);

    }
}
