using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionScript : MonoBehaviour
{

    Animator animator;

    // Enemy

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("isAtt1", true);
        }
        
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetBool("isAtt1", false);
        }
    }


}
