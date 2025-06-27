using System;
using UnityEngine;

public class AlliedUnitDeathHandler : MonoBehaviour
{
    public void OnDeath(Action<GameObject> OnUnitDied)
    {
        //call event that removes unit from the warband
        OnUnitDied?.Invoke(gameObject);
    }
}
