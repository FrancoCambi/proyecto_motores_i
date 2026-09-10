using UnityEngine;

public class Door : Interactable
{
    [Header("Required Item")]
    [SerializeField] private KeyData requiredKey;

    public override void Interact()
    {
        Inventory inventory = FindFirstObjectByType<Inventory>();

        if (inventory == null)
        {
            Debug.LogWarning("No se encontró un Inventory en la escena.");
            return;
        }

        if (!inventory.HasItem(requiredKey))
        {
            Debug.Log("Necesitas una llave para abrir esta puerta.");
            return;
        }

        Open();
    }

    private void Open()
    {
        Debug.Log("Puerta abierta");

        gameObject.SetActive(false);
    }
}