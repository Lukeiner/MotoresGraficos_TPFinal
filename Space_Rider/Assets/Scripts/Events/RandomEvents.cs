using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEvents : MonoBehaviour
{
    [Header("Configuración de Intervalos")]
    [Tooltip("Tiempo mínimo entre eventos (segundos)")]
    public float minTimeBetweenEvents = 8f;

    [Tooltip("Tiempo máximo entre eventos (segundos)")]
    public float maxTimeBetweenEvents = 20f;

    [Header("Referencias")]
    public MeteorEvent meteorEvent; // Arrastrá el GameObject del MeteorEvent acá

    // Lista extensible: podés agregar más IGameEvent (power-ups, etc.)

    private bool eventsActive = false;

    private List<IGameEvent> availableEvents = new List<IGameEvent>();

    void Start()
    {
        // Registrar eventos disponibles
        if (meteorEvent != null)
            availableEvents.Add(meteorEvent);

        // Iniciar el ciclo de eventos
        StartEvents();
    }

    public void StartEvents()
    {
        eventsActive = true;
        StartCoroutine(EventLoop());
    }


    public void StopEvents()
    {
        eventsActive = false;
        StopAllCoroutines();
    }

    private IEnumerator EventLoop()
    {
        while (eventsActive)
        {
            // Esperar un tiempo aleatorio antes del próximo evento
            float waitTime = Random.Range(minTimeBetweenEvents, maxTimeBetweenEvents);
            yield return new WaitForSeconds(waitTime);

            if (availableEvents.Count > 0)
                TriggerRandomEvent();
        }
    }

    private void TriggerRandomEvent()
    {
        // Elegir un evento aleatorio de los disponibles
        int index = Random.Range(0, availableEvents.Count);
        availableEvents[index].Execute();
    }
}

