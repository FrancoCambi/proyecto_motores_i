using System;
using UnityEngine;

public class AmmoLoot : Loot
{
    [SerializeField] private int ammoAmount = 8;

    public override void Pickup()
    {
        AmmoInventory ammoInventory = FindFirstObjectByType<AmmoInventory>();
        
        if (ammoInventory == null)
        {
            Debug.LogError("AmmoInventory not found in Player");
            return;
        }

        ammoInventory.AddAmmo(ammoAmount);

        Destroy(gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
