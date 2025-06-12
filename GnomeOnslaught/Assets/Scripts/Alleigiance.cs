using UnityEngine;

public class Alleigiance : MonoBehaviour
{
    [SerializeField] FactionTypes faction;

    public FactionTypes Faction
    {
        get { return faction; }
    }
}
