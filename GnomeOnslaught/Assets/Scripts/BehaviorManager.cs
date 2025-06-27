using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    private MonoBehaviour currentBehavior;
    private void Start()
    {
        SetBehavior<Idle>();
    }

    public void SetBehavior<T>() where T : MonoBehaviour
    {
        // If the current behavior is already of this type, do nothing
        if (currentBehavior != null && currentBehavior.GetType() == typeof(T))
        {
            return;
        }

        // Remove the previous behavior
        if (currentBehavior != null)
        {
            Destroy(currentBehavior);
        }

        if (GetComponent<T>() == null)
        {
            currentBehavior = gameObject.AddComponent<T>();
        }
    }
    public void ClearBehavior()
    {
        if (currentBehavior != null)
        {
            Destroy(currentBehavior);
            currentBehavior = null;
        }
    }
    public System.Type GetCurrentBehaviorType()
    {
        return currentBehavior?.GetType();
    }
    public bool IsCurrentBehavior<T>() where T : MonoBehaviour
    {
        return currentBehavior != null && currentBehavior is T;
    }
}