using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemypatrol : MonoBehaviour
{
    public GameObject pointa;
    public GameObject pointb;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// rb là rigidbody của cả obj
        anim = GetComponent<Animator>();
        currentPoint = pointb.transform;
        anim.SetBool("isRunning", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;// give direction that our enemy wants to go toward from current point

        if (currentPoint == pointb.transform)
        {
            rb.velocity = new Vector2(-speed, 0);// go right
        }

        else
        {
            rb.velocity = new Vector2(speed, 0);//go left
        }


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointa.transform)
        {
            flip();
            currentPoint = pointb.transform;
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointb.transform)
        {
            flip();
            currentPoint = pointa.transform;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointa.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointb.transform.position, 0.5f);
        Gizmos.DrawLine(pointa.transform.position, pointb.transform.position);
    }
}
