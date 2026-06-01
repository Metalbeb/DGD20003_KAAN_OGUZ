using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class NPCSpawner : MonoBehaviour
{
    public Transform spawnPoint;

    void Start()
    {
        SpawnNPC();
    }

    void SpawnNPC()
    {
        Addressables.InstantiateAsync(
            "NPCPrefab",
            spawnPoint.position,
            Quaternion.identity
        ).Completed += OnNPCSpawned;
    }

    void OnNPCSpawned(AsyncOperationHandle<GameObject> handle)
    {
        if (handle.Status == AsyncOperationStatus.Succeeded)
        {
            Debug.Log("NPC spawned successfully!");
        }
    }
}