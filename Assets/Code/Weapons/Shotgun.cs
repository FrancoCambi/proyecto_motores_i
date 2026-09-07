using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
public class Shotgun : MonoBehaviour
{
    public Transform muzzle;
    public GameObject projectilePrefab;
    public int pellets = 6;
    public float spread = 8f;
    public float projectileSpeed = 20f;

    public float fireRate = 0.8f;

    private float nextFireTime;

    void Start()
    {

    }

    void Update()
    {
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame &&
            IsPlayerAiming())
        {
            Shoot();
        }
    }

    bool IsPlayerAiming()
    {
        PlayerAim aim = GetComponentInParent<PlayerAim>();

        return aim != null && aim.isAiming;
    }

    void Shoot()
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
