using UnityEngine;
using UnityEngine.Events;

public class fireplaceSoundScript : MonoBehaviour
{
    [SerializeField] private UnityEvent fireplaceOn;
    [SerializeField] private UnityEvent fireplaceOff;

    private void OnTriggerEnter(Collider other)
    {
       fireplaceOff?.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        fireplaceOn?.Invoke();
    }
}
