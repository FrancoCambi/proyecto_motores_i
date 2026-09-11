using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] private TMP_Text ammoText;

    private AmmoInventory ammoInventory;
    private PlayerFire playerFire;

    private bool _hasBeenActivated;

    private void Start()
    {
        ammoText.gameObject.SetActive(false);

        ammoInventory = FindFirstObjectByType<AmmoInventory>();
        playerFire = FindFirstObjectByType<PlayerFire>();
    }

    private void Update()
    {
        if (playerFire == null || ammoInventory == null) 
            return;

        Weapon currentWeapon = playerFire.GetCurrentWeapon();

        if (currentWeapon != null)
        {
            _hasBeenActivated = true;
        }

        if (!_hasBeenActivated)
            return;

        ammoText.gameObject.SetActive(true);

            ammoText.text = currentWeapon.CurrentAmmo + " / " + ammoInventory.Ammo;
    
        
    }
}
