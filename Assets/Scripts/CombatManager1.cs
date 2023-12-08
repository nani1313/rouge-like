using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager1 : MonoBehaviour
{
    public static CombatManager1 Instance;

    public bool canReceiveInput;
    public bool InputReceived;
    public GameObject attackPoint;
    public float radius;
    public LayerMask enemies;
    public float damgage;

    private void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            InputReceived = true;
            canReceiveInput = false;
        }
    }

    public void Attack()
    {
        Collider2D[] enemy = Physics2D.OverlapCircleAll(attackPoint.transform.position, radius, enemies);

        foreach (Collider2D enemyGameObject in enemy)
        {
            Debug.Log("Hit enemy!");
            enemyGameObject.GetComponent<EnemyHealth>().Health -= damgage; 
        }
    }

    public void InputManager()
    {
        if(!canReceiveInput) 
        {
            canReceiveInput = true;
        }
        else
        {
            canReceiveInput = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.transform.position, radius);
    }

}
