using UnityEngine;

public abstract class Weapon : Loot
{
    public abstract int CurrentAmmo {  get; }
    public abstract void Shoot();
    public abstract void Reload();
}
