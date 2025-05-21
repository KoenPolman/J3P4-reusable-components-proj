using UnityEngine;

public interface IControls
{
    Vector2 GetMovement();   
    Vector2 GetAim();        
    bool SelectPressed();      
    bool ReturnPressed();
}
