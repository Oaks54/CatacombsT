using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea=default;
    private PlayerController playerController;

    private bool attacking=false;

    private Animator animator;

    public bool IsAttacking()
    {
        return attacking;
    }

    private float timeToAttack=0.5f;
    private float timer=0f;

    // Start is called before the first frame update
    void Start()
    {
        attackArea=transform.GetChild(0).gameObject;
        playerController = GetComponent<PlayerController>();
         animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Ho attaccato");
            Attack();
        }

        if (attacking)
        {
            timer+=Time.deltaTime;

            if (timer>=timeToAttack)
            {
                timer=0;
                attacking=false;
                attackArea.SetActive(attacking);
            }
        }
    }

    public void StopAttack()
    {
        animator.SetBool("isAttacking", false);
    }

    private void Attack()
    {
        attacking=true;
        animator.SetBool("isAttacking", true);
        attackArea.SetActive(attacking);

        // Posiziona l'attackArea in base alla direzione dell'ultimo movimento del giocatore
        float attackDistance = 3f; // Imposta questa variabile al valore che preferisci
        attackArea.transform.localPosition = playerController.LastMoveDirection * attackDistance;

        
    }
}
