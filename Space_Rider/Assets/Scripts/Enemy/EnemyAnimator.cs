using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimator : MonoBehaviour
{
    private Animator animator;
    private Vector3 lastPosition;

    void Start()
    {
        animator = GetComponent<Animator>();
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 movement = transform.position - lastPosition;

        if (movement.magnitude > 0.001f) // si se movió
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                // Movimiento horizontal
                if (movement.x > 0)
                    animator.Play("MoveRight");   // animación hacia la derecha
                else
                    animator.Play("MoveLeft");    // animación hacia la izquierda
            }
            else
            {
                // Movimiento vertical
                if (movement.y > 0)
                    animator.Play("MoveUp");      // animación hacia arriba
                else
                    animator.Play("MoveDown");    // animación hacia abajo
            }
        }

        lastPosition = transform.position;
    }
}
