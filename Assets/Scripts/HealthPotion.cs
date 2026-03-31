using UnityEngine;

public class HealthPotion : Item
{
    public int healthAmount;

    public override void Use()
    {
        Debug.Log($"Consuming {itemName}. Healed {healthAmount} HP.");
    }
}
