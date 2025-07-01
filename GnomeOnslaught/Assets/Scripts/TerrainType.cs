using UnityEngine;

public class TerrainType : MonoBehaviour
{
    [SerializeField] private TerrainTypes type;

    public TerrainTypes GetType()
    {
        return type;
    }
}
