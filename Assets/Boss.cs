using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public Transform player;

    public bool isFlipped = false;
    
    public void LookAtPlayer()
    {
        Vector3 flippeed = transform.localScale;
        flippeed.z *= -1f;

        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flippeed;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;  
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flippeed;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }



}
