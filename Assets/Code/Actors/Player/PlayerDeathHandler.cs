using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerDeathHandler : MonoBehaviour, IDeathHandler
{
    [Header("Possible Spawn Points")]
    [SerializeField] private List<GameObject> spawnPoints;

    private CharacterController _controller;

    private IResettable[] _resettables;

    private void Awake()
    {
        _resettables = GetComponents<IResettable>();
        _controller = GetComponent<CharacterController>();
    }

    public void Die()
    {
        if (spawnPoints.Count == 0)
        {
            Destroy(gameObject);
            return;
        }

        int randomIndex = Random.Range(0, spawnPoints.Count);
        Vector3 nextSpawnPoint = spawnPoints[randomIndex].transform.position;
        spawnPoints.RemoveAt(randomIndex);

        foreach (IResettable resettable in _resettables)
        {
            resettable.ResetState();
        }

        _controller.enabled = false;
        transform.position = nextSpawnPoint;
        _controller.enabled = true;
    }
}