using UnityEngine;

public interface IControls
{
    public Vector2 GetMovement();   
    public Vector2 GetAim();        
    public bool SelectPressed();      
    public bool ReturnPressed();
}
