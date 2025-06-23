using UnityEngine;
using UnityEngine.UIElements;

public class UnitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject UnitToInstantiate;
    [SerializeField] private float InstatiationFrequency = 2f; //interval of spawning units
    [SerializeField] private float SpawnRadius = 3f;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= InstatiationFrequency)
        {
            SpawnUnit();
            timer = 0f;
        }
    }

    private void SpawnUnit()
    {
        // Generate a random angle in radians
        float angle = Random.Range(0f, Mathf.PI * 2f);

        // Calculate position on the circle
        Vector3 spawnOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * SpawnRadius + new Vector3(0, 0, -1);

        // Calculate final spawn position
        Vector3 spawnPosition = transform.position + spawnOffset;

        // Instantiate unit
        Instantiate(UnitToInstantiate, spawnPosition, Quaternion.identity);
    }
}
