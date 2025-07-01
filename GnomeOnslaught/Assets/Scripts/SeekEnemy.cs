using UnityEngine;

public class SeekEnemy : MonoBehaviour
{
    [SerializeField] FactionTypes[] targetedFactions;
    private Alleigiance alleigiance;
    private BehaviorManager commandInterperter;

    void Start()
    {
        alleigiance = gameObject.GetComponent<Alleigiance>();
        commandInterperter = gameObject.GetComponent<BehaviorManager>();
    }

    void Update()
    {
        //Debug.Log("update");
        FindTargets(); //find a way to get this out of the update, this is terrible for performance
    }
    private void FindTargets()
    {
        Alleigiance[] allUnits = FindObjectsByType<Alleigiance>(FindObjectsSortMode.None); //gets all the units with an alleigiance
        for (int i = 0; i < allUnits.Length; i++)
        {
            //Debug.Log("amount of units found = " + i);
            float distance = Vector3.Distance(allUnits[i].gameObject.transform.position, gameObject.transform.position);
            if (isEnemy(allUnits[i]) && distance <= 5f) //look for an unit within a certain distance and check if they are on the list of targeted factions
            {
                //Debug.Log("Enemy found!");
                commandInterperter.SetBehavior<AttackTarget>(); //switch out the current behavior for the attacking behavior
                gameObject.GetComponent<AttackTarget>().Target = allUnits[i].gameObject;//set the target in the attacking behavior
                //Debug.Log("target set!");
            }
        }
    }
    /// <summary>
    /// check if unit is on the list of targeted factions
    /// </summary>
    /// <param name="alleigiance"></param>
    /// <returns></returns>
    private bool isEnemy(Alleigiance alleigiance)
    {
        //Debug.Log("checking for alleigiance");
        for (int i = 0; i < targetedFactions.Length; i++)
        {
            if (alleigiance.Faction == targetedFactions[i])
            {
                return true;
            }
        }
        return false;
    }
}
