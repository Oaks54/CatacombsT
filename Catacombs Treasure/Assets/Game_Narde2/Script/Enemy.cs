using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private int damage = 1;
    [SerializeField]
    private EnemyData data;
    [SerializeField]
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SetEnemyValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetEnemyValues()
    {
        GetComponent<Health>().SetHealth(data.hp, data.hp);
        damage = data.damage;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            if (collider.GetComponent<Health>() != null)
            {
                collider.GetComponent<Health>().Damage(damage, collider.gameObject);
            }
        }
    }
}
