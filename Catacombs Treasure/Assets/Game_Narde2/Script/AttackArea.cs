using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;
    public PlayerAttack playerAttack; // Aggiungi un riferimento al tuo script PlayerAttack

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (playerAttack.IsAttacking()) // Controlla se il giocatore sta attaccando
        {
            if (collider.GetComponent<Health>() != null)
            {
                Health health = collider.GetComponent<Health>();
                health.Damage(damage, collider.gameObject);
            }
        }
    }
}
