using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private int health=100;

    private int MAX_HEALTH=100;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            //Damage(10);
        }
        /*if (Input.GetKeyDown(KeyCode.H))
        {
            //Heal(10);
        }*/
    }

    public void SetHealth(int maxhealth, int health)
    {
        this.MAX_HEALTH= maxhealth;
        this.health = health;
    }

    private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void Damage(int amount, GameObject caller)
    {
        if (amount<0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative damage");
        }

        this.health-=amount;
        StartCoroutine(VisualIndicator(Color.red));

        if (health<=0)
        {
            Die(caller);
        }
    }

    /*public void Heal(int amount)
    {
        if (amount<0)
        {
            throw new System.ArgumentOutOfRangeException("cannot have negative healing");
        }

        bool wouldBeOverMaxHealth=health+amount>MAX_HEALTH;

        if (wouldBeOverMaxHealth)
        {
            this.health=MAX_HEALTH;
        }
        else
        {
            this.health+=amount;
        }        
    }*/
    private void Die(GameObject caller)
    {
        if (caller.tag == "Enemy")
        {
            Debug.Log("Sono stato ucciso da un nemico");
            Destroy(caller);
        }
        else if (caller.tag == "Player")
        {
            Debug.Log("Sono schiattato");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
