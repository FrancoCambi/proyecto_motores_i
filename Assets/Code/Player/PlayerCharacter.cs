using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    [Header("Character Points")]
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform cameraPoint;

    public Transform SpawnPoint => spawnPoint;
    public Transform CameraPoint => cameraPoint;

    public bool IsDead { get; private set; }

    public void Die()
    {
        IsDead = true;
    }
}
