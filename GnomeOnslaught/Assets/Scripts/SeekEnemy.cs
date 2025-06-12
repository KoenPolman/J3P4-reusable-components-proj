using UnityEngine;

public class SeekEnemy : MonoBehaviour
{
    [SerializeField] FactionTypes[] targetedFactions;
    private Alleigiance alleigiance;
    private CommandInterperter commandInterperter;

    void Start()
    {
        alleigiance = gameObject.GetComponent<Alleigiance>();
        commandInterperter = gameObject.GetComponent<CommandInterperter>();
    }

    // Update is called once per frame
    void Update()
    {
        Alleigiance[] allUnits = GetComponents<Alleigiance>();
        for (int i = 0; i < allUnits.Length; i++)
        {
            float distance = Vector3.Distance(allUnits[i].gameObject.transform.position, gameObject.transform.position);
            if (isEnemy(allUnits[i]))
            {
                commandInterperter.SetBehavior<AttackTarget>();
                gameObject.GetComponent<AttackTarget>().Target = allUnits[i].gameObject.transform;
            }
        }
    }
    private bool isEnemy(Alleigiance alleigiance)
    {
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
