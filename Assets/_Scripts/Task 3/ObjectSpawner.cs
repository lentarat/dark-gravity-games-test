using UnityEngine;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Transform _spawnPointTransform;
    [SerializeField] private Transform _objectsParent;
    [SerializeField] private float _spawnInterval;
    [SerializeField] private float _maxRandomSpawnRadius;
    [SerializeField] private List<GameObject> _objectsList;

    private void Start()
    {
        SpawnRandomObjectsAsync().Forget();
    }

    private async UniTask SpawnRandomObjectsAsync()
    {
        while (true)
        {
            SpawnRandomObject();
            await UniTask.WaitForSeconds(_spawnInterval);
        }
    }

    private void SpawnRandomObject()
    {
        int randomIndex = Random.Range(0, _objectsList.Count);
        GameObject randomObject = _objectsList[randomIndex];
        Vector3 randomSpawnPosition = _spawnPointTransform.position + Random.insideUnitSphere * _maxRandomSpawnRadius;
        Instantiate(randomObject, randomSpawnPosition, Quaternion.identity, _objectsParent);
    }
}
