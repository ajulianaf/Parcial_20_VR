using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager Instance { get; private set; }

    [System.Serializable]
    public class EventData
    {
        public string eventName;                 // Ej: "Evento 1" o "Evento 2"
        public List<BoxCollider> collidersToEnable = new List<BoxCollider>();
        public bool isActive;
    }

    [SerializeField] private List<EventData> events = new List<EventData>();

    private Dictionary<string, EventData> eventDictionary = new Dictionary<string, EventData>();

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        eventDictionary.Clear();
        foreach (var ev in events)
        {
            if (ev == null || string.IsNullOrWhiteSpace(ev.eventName))
                continue;

            if (!eventDictionary.ContainsKey(ev.eventName))
                eventDictionary.Add(ev.eventName, ev);
        }
    }

    private void Start()
    {
        // Al iniciar, todos los colliders quedan apagados
        foreach (var ev in events)
        {
            if (ev == null) continue;
            SetCollidersState(ev.collidersToEnable, false);
            ev.isActive = false;
        }
    }

    public void ActivateEvent(string eventName)
    {
        if (!eventDictionary.TryGetValue(eventName, out var ev))
        {
            Debug.LogWarning($"No existe el evento: {eventName}");
            return;
        }

        if (ev.isActive) return;

        SetCollidersState(ev.collidersToEnable, true);
        ev.isActive = true;
    }

    public void DeactivateEvent(string eventName)
    {
        if (!eventDictionary.TryGetValue(eventName, out var ev))
        {
            Debug.LogWarning($"No existe el evento: {eventName}");
            return;
        }

        SetCollidersState(ev.collidersToEnable, false);
        ev.isActive = false;
    }

    private void SetCollidersState(List<BoxCollider> colliders, bool state)
    {
        foreach (var col in colliders)
        {
            if (col != null)
                col.enabled = state;
        }
    }
}