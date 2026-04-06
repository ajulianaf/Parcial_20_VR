using UnityEngine;

[RequireComponent(typeof(Collider))]
public class EventZone1 : MonoBehaviour
{
    [SerializeField] private string requiredLayerName = "Objeto_1";
    [SerializeField] private string eventName = "Evento 1";
    [SerializeField] private bool activateOnlyOnce = true;

    private int requiredLayer;

    private void Awake()
    {
        GetComponent<Collider>().isTrigger = true;
        requiredLayer = LayerMask.NameToLayer(requiredLayerName);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer != requiredLayer)
            return;

        if (EventsManager.Instance != null)
        {
            EventsManager.Instance.ActivateEvent(eventName);
        }

        if (activateOnlyOnce)
            enabled = false;
    }
}