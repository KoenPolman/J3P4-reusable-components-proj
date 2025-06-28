using System.Collections.Generic;
using UnityEngine;

public class CommandAdresser : MonoBehaviour
{
    [SerializeField] float commandRange = 5;
    private List<BehaviorManager> currentWarBand = new List<BehaviorManager>();
    private IControls controls;

    void Start()
    {
        controls = new KeyboardControls(gameObject);

        Health.OnUnitDied += RemoveFromWarband;
    }

    void OnDestroy()
    {
        Health.OnUnitDied -= RemoveFromWarband;
    }

    void Update()
    {
        if (controls.ReturnPressed())
        {
            Rally();
        }
    }

    public void Rally()
    {
        BehaviorManager[] targets = FindObjectsByType<BehaviorManager>(FindObjectsSortMode.None);
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (distance <= commandRange &&
                !currentWarBand.Contains(targets[i]) &&
                targets[i].GetComponent<Alleigiance>().Faction == FactionTypes.Player)
            {
                currentWarBand.Add(targets[i]);
            }
        }

        //Debug.Log("Current warband size: " + currentWarBand.Count);
        foreach (BehaviorManager unit in currentWarBand)
        {
            unit.SetBehavior<FollowTarget>();
        }
    }

    public void Attack()
    {
        // attack logic
    }

    private void RemoveFromWarband(GameObject gameObjectToRemove)
    {
        var bm = gameObjectToRemove.GetComponent<BehaviorManager>();
        if (bm != null && currentWarBand.Contains(bm))
        {
            currentWarBand.Remove(bm);
           // Debug.Log("Unit removed from warband.");
        }
    }
}