using UnityEngine;
using UnityEngine.InputSystem;

public class Shotgun : Loot
{
    [Header("References")]
    [SerializeField] private Transform weaponHolder;
    [SerializeField] private Transform muzzle;
    [SerializeField] private GameObject projectilePrefab;

    [Header("Settings")]
    [SerializeField] private int pellets = 6;
    [SerializeField] private float spread = 8f;
    [SerializeField] private float projectileSpeed = 20f;
    [SerializeField] private float fireRate = 0.8f;

    private bool _pickedUp;
    private float nextFireTime;

    private void Update()
    {
        if (_pickedUp && Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame && IsPlayerAiming())
            Shoot();
    }

    public override void Pickup()
    {
        if (_pickedUp)
            return;

        _pickedUp = true;

        transform.SetParent(weaponHolder);
        transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);

        Debug.Log("Groovy");
    }

    private bool IsPlayerAiming()
    {
        PlayerAim aim = GetComponentInParent<PlayerAim>();

        return aim != null && aim.isAiming;
    }

    private void Shoot()
    {
        Debug.Log("Shoot");

        if (Time.time < nextFireTime)
            return; 
        
        nextFireTime = Time.time + fireRate;

        for (int i = 0; i < pellets; i++)
        {
            Quaternion rotation = muzzle.rotation;

            float randomX = Random.Range(-spread, spread);
            float randomY = Random.Range(-spread, spread);

            rotation *= Quaternion.Euler(randomX, randomY, 0f);

            GameObject projectile = Instantiate(
                projectilePrefab,
                muzzle.position,
                rotation
                );    

            Rigidbody rb = projectile.GetComponentInChildren<Rigidbody>();

            if (rb == null)
            {
                Destroy(projectile);
                return;
            }

            rb.linearVelocity = rotation * Vector3.forward * projectileSpeed;
        }
    }
}
