using NUnit.Framework;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
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
        if (controls.ReturnPressed())
        {
            //Debug.Log("rallying units");
            Rally();
        }
    }
    public void Rally()
    {
        CommandInterperter[] targets = FindObjectsByType<CommandInterperter>(FindObjectsSortMode.None); //doelwitten worden gevonden
        //Debug.Log("qty CommandInterperter found : " + targets.Length); //
        for (int i = 0; i < targets.Length; i++)
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (distance <= commandRange && !currentWarBand.Contains(targets[i]))
            {
                currentWarBand.Add(targets[i]);
            }
        }
        Debug.Log("Curren warband size : " + currentWarBand.Count);
        foreach (CommandInterperter unit in currentWarBand)
        {
            //Debug.Log("unitbehavior set");
            unit.SetUnitBehavior(UnitBehaviorType.following, gameObject);
        }
    }
    public void Attack()
    {

    }
}