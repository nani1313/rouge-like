using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;
    private float distance;
    

    Animator animator;

    public float isRunning;

    public float distanceToPlayer;
    public float attackDistance = 1f;


    public bool flip;

    void Awake()
    {
         animator = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, player.transform.position);
        Vector3 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        if (distance < distanceBetween)
        {
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            animator.SetBool("isRunning", true);

        }
        else
        {
            animator.SetBool("isRunning", false);
        }



        //distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        //if (distanceToPlayer <= attackDistance)
        //{
        //    transform.position = transform.position;
        //    animator.SetBool("isAtt1", true);
        //}
        //else
        //{
        //    transform.position = transform.position;
        //    animator.SetBool("isAtt1", false);
        //}




        Vector3 scale = transform.localScale;

        if (player.transform.position.x > transform.position.x)
        {
            scale.x = Mathf.Abs(scale.x) * -1 * (flip ? 1 : -1);
        }
        else
        {
            scale.x = Mathf.Abs(scale.x) * (flip ? 1 : -1);
        }

        transform.localScale = scale;

    }
       
}
 