using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float Health;
    public float currentHealth;

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentHealth = Health;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health < currentHealth)
        {
            currentHealth = Health;
            anim.SetTrigger("Attacked");
        }


        if (Health <= 0)
        {
            anim.SetBool("isDead", true);
            Destroy(gameObject,0.5f);
        }
  
    }
}
