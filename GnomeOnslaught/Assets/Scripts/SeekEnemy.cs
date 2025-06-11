using UnityEngine;

public class SeekEnemy : MonoBehaviour
{
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
        
    }
}
