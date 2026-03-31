using UnityEngine;

public class Weapon : Item
{
    public int damage;

    public override void Use()
    {
        Debug.Log($"Attacking with {itemName} for {damage} damage!");
    }
}
