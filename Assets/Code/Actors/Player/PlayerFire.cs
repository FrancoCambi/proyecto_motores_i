using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerFire : MonoBehaviour
{
    private Weapon _currentWeapon;

    private void Update()
    {
        // DISPARO
        if (Mouse.current != null &&
            Mouse.current.leftButton.wasPressedThisFrame &&
            IsPlayerAiming() &&
            _currentWeapon != null)
        {
            _currentWeapon.Shoot();
        }
        // RECARGA
        if (Keyboard.current != null &&
            Keyboard.current.rKey.wasPressedThisFrame &&
            _currentWeapon != null)
        {
            _currentWeapon.Reload();
        }
   
    }

    public void SetWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }
    
    public Weapon GetCurrentWeapon()
    {
        return _currentWeapon;
    }
    private bool IsPlayerAiming()
    {
        PlayerAim aim = GetComponent<PlayerAim>();

        return aim != null && aim.isAiming;
    }
    void Start()
    {
        
    }
}
