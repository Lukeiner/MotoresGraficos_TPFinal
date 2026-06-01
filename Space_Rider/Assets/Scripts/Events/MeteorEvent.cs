using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MeteorEvent : MonoBehaviour
{
    [Header("Posiciones de impacto")]

    public List<Transform> impactPoints;

    [Header("Daño")]

    public float impactDamage = 1f;

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
            Instantiate(meteorPreFab, targetPosition, Quaternion.identity);
        }

        if (impactEffectPreFab != null )
        {
            Instantiate(impactEffectPreFab, targetPosition, Quaternion.identity);
        }

        ApplyAreaDamage(targetPosition);

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
          //  EnemyHealth enemyHealt = hit.GetComponent<EnemyHealth>();

          //  if (enemyHealth != null )
          //  {
            //    enemyHealth.TakeDamage(impactDamage);
              //  Debug.Log($"[MeteorEvent] Daño a {hit.gameObject.name}: {impactDamage}");
            //}
        }

    }
}
