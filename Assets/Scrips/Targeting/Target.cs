using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    public UnityEvent<Target> OnDestroyed;
    public UnityEvent<Target> OnTake;
    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
}
