using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform[] moveSpots;
    public float speed = 1.0f;
    public Animator animator;
    public float distance;
    private int direction = 1;
    public Transform groundDetection;
    public Transform playerDetection;
    private float baseSpeed;

    void Start()
    {
        baseSpeed = speed;
    }

    void Update()
    {
        RaycastHit2D groundInfo = Physics2D.Raycast(playerDetection.position, Vector2.down, distance);
        if (groundInfo.collider == true && groundInfo.transform.tag != "Bound")
        {
            animator.SetBool("isWalking", false);
            return;
        }

        animator.SetBool("isWalking", true);

            if (groundInfo.collider == false)
            {
                if (direction == 1)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    direction *= -1;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    direction*=-1;

                }
            }
        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, direction * Vector2.right);
        if (playerInfo.collider == true && playerInfo.transform.tag == "Player")
        {
            speed = 2 * baseSpeed;
        }
        else
            speed = baseSpeed;
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

}
