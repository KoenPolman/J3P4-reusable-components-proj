using UnityEngine;
using UnityEngine.Rendering;

public class DozeTerrain : MonoBehaviour
{
    [SerializeField] GameObject grassPrefab;
    private CircleCollider2D trigger;
    void Start()
    {
        CircleCollider2D[] colliders = GetComponents<CircleCollider2D>();
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].isTrigger)
            {
                trigger = colliders[i];
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TerrainType>() != null && collision.GetComponent<TerrainType>().GetType() == TerrainTypes.DenseForrest)
        {
            GameObject newTerrain = Instantiate(grassPrefab);
            newTerrain.transform.position = collision.transform.position;
            Destroy(collision.gameObject);
        }       
    }
}