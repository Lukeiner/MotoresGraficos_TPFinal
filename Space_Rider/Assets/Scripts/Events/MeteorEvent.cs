using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MeteorEvent : MonoBehaviour, IGameEvent
{
    [Header("Posiciones de impacto")]

    public List<Transform> impactPoints;

    [Header("Daño")]

    public int impactDamage = 50;

    [Tooltip("Radio de daño en área alrededor del piunto de impacto")]

    public float impactRadius = 1.5f;

    [Header("Timing")]

    public float warningDuration = 2f;

    [Tooltip("Prefab del meteorito (opcional, para animación de caída)")]
    public GameObject meteorPreFab;

    [Tooltip("Prefab del indicador de advertencia en el suelo (opcional)")]
    public GameObject warningIndicatorPreFab;

    [Tooltip("Prefab del efecto de explosión al impactar (opcional)")]
    public GameObject impactEffectPreFab;

    [Tooltip("LayerMask con la capa de los enemigos para detectarlos con Physics2D")]
    public LayerMask enemyLayer;

    public void Execute ()
    {
        if (impactPoints == null || impactPoints.Count == 0)
        {
            Debug.LogWarning("[MeteorEvent] No hay puntos de impacto configurados.");
            return;
        }

        else
        {
            int index = Random.Range(0, impactPoints.Count);
            Transform chosenPoint = impactPoints[index];

            StartCoroutine(MeteorSequence(chosenPoint.position));
        }
    }
     
    private IEnumerator MeteorSequence (Vector2 targetPosition)
    {
        GameObject warning = null;

        if (warningIndicatorPreFab != null)
        {
            warning = Instantiate(warningIndicatorPreFab, targetPosition, Quaternion.identity);

        }

        Debug.Log($"[MeteorEvent] ¡Meteorito cayendo en {targetPosition}! ({warningDuration}s)");

        yield return new WaitForSeconds(warningDuration);

        if (warning != null)
        {
            Destroy(warning);
        }

        if (meteorPreFab != null)
        {
            Vector2 startPosition = targetPosition + new Vector2(8f, 10f);

            GameObject meteor = Instantiate(meteorPreFab, startPosition, Quaternion.identity);

            Vector2 direction = (targetPosition - startPosition).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            meteor.transform.rotation = Quaternion.Euler(0f, 0f, angle);
            meteor.GetComponent<SpriteRenderer>().sortingOrder = 10;

            // Lo movemos hacia el punto de impacto
            StartCoroutine(MoveMeteor(meteor, startPosition, targetPosition));
        }

        if (impactEffectPreFab != null )
        {
            Instantiate(impactEffectPreFab, targetPosition, Quaternion.identity);
        }

        ApplyAreaDamage(targetPosition);

    }

    private IEnumerator MoveMeteor(GameObject meteor, Vector2 from, Vector2 to)
    {
        float duration = 1.5f; // segundos que tarda en llegar
        float elapsed = 0f;

        while (elapsed < duration)
        {
            if (meteor == null) yield break; // seguridad por si se destruyó

            elapsed += Time.deltaTime;
            float t = elapsed / duration;

            // Lerp suaviza el movimiento de A a B
            meteor.transform.position = Vector2.Lerp(from, to, t);

            yield return null;
        }

        // Asegurarse que llegó exactamente al destino
        if (meteor != null)
        {
            meteor.transform.position = to;
            ApplyAreaDamage(to);     // daño al llegar
            Destroy(meteor, 1f);   // desaparece después del impacto
        }
    }

    private void ApplyAreaDamage (Vector2 center)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(center, impactRadius, enemyLayer);

        if (hits.Length == 0)
        {
            Debug.Log("No hay enemigos en el área");
            return;
        }

        foreach (Collider2D hit in hits)
        {
            Enemy enemy = hit.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.TakeDamage(impactDamage);
                Debug.Log($"[MeteorEvent] Daño a {hit.gameObject.name}: {impactDamage}");
            }
        }

    }
}
