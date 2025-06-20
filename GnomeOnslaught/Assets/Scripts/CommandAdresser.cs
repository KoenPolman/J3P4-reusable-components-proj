using System.Collections.Generic;
using UnityEngine;

public class CommandAdresser : MonoBehaviour
{
    [SerializeField] float commandRange = 5;
    private List<CommandInterperter> currentWarBand = new List<CommandInterperter>();
    private IControls controls;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = new KeyboardControls(gameObject);    
    }

    // Update is called once per frame
    void Update()
    {
        CheckForDeaths();
        if (controls.ReturnPressed())
        {
            //Debug.Log("rallying units");
            Rally();
        }
    }
    public void Rally()
    {
        CommandInterperter[] targets = FindObjectsByType<CommandInterperter>(FindObjectsSortMode.None); //doelwitten worden gevonden
        //Debug.Log("qty CommandInterperter found : " + targets.Length);
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (distance <= commandRange && !currentWarBand.Contains(targets[i]) && targets[i].GetComponent<Alleigiance>().Faction == FactionTypes.Player)
            {
                currentWarBand.Add(targets[i]);
            }
        }
        Debug.Log("Curren warband size : " + currentWarBand.Count);
        foreach (CommandInterperter unit in currentWarBand)
        {
            //Debug.Log("unitbehavior set");
            unit.SetBehavior<FollowTarget>();
        }
    }
    public void Attack()
    {

    }
    private void CheckForDeaths()
    {
     List<CommandInterperter> unitsToRemoveFromWarBand = new List<CommandInterperter>();
        foreach (CommandInterperter unit in currentWarBand)
        {
            if (unit == null)
            {
                unitsToRemoveFromWarBand.Add(unit);
            }
        }
        foreach (CommandInterperter unitsToRemove in unitsToRemoveFromWarBand)
        {
            currentWarBand.Remove(unitsToRemove);
        }
    }
}