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
            Debug.Log("rallying units");
            Rally();
        }
    }
    public void Rally()
    {
        CommandInterperter[] targets = FindObjectsByType<CommandInterperter>(FindObjectsSortMode.None);
        for(int i = 0; i < targets.Length; i++) 
        {
            float distance = Vector3.Distance(targets[i].transform.position, transform.position);
            if (distance >= commandRange)
            {
                currentWarBand.Add(targets[i]);
            }
        }
        foreach (CommandInterperter unit in currentWarBand)
        {
            unit.SetUnitBehavior(UnitBehaviorType.following);
        }
    }
    public void Attack()
    {

    }
}