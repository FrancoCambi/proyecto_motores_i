using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponPickup : MonoBehaviour
{
    public Transform weaponHolder;

    private bool playerNearby = false;

    void Update()
    {
        if (playerNearby && Keyboard.current != null && Keyboard.current.eKey.wasPressedThisFrame)
        {
            Pickup();
        }
    }

    void Pickup()
    {
        Shotgun shotgun = GetComponent<Shotgun>();

        if (shotgun != null)
        {
            shotgun.enabled = true;
        }

        transform.SetParent(weaponHolder);

        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;

        SphereCollider pickupCollider = GetComponent<SphereCollider>();

        if (pickupCollider != null)
        {
            pickupCollider.enabled = false;
        }
        Debug.Log("Groovy");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
            Debug.Log("Grab");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
    void Start()
    {
        
    }

   
}
