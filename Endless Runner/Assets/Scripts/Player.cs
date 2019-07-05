using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed;
    public float increment;
    public float maxY;
    public float minY;
    public float minSwipeDistY;

    public float minSwipeDistX;

    private Vector2 startPos;

    private Vector2 targetPos;

    public int health;

    public GameObject moveEffect;
    public Animator camAnim;
    public Text healthDisplay;


    public GameObject spawner;
    public GameObject restartDisplay;


    private void Update()
    {


        if (health <= 0)
        {
            spawner.SetActive(false);
            restartDisplay.SetActive(true);
            Destroy(gameObject);
        }

        healthDisplay.text = health.ToString();

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Input.touchCount > 0)

        {

            Touch touch = Input.touches[0];





            if (touch.phase == TouchPhase.Began)

                startPos = touch.position;





            if (touch.phase == TouchPhase.Ended)
            {

                float swipeDistVertical = (new Vector3(0, touch.position.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;

                if (swipeDistVertical > minSwipeDistY)

                {

                    float swipeValue = Mathf.Sign(touch.position.y - startPos.y);

                    if (swipeValue > 0 && transform.position.y < maxY)
                    {
                        //up
                        camAnim.SetTrigger("shake");
                        Instantiate(moveEffect, transform.position, Quaternion.identity);
                        targetPos = new Vector2(transform.position.x, transform.position.y + increment);
                    }
                    else if (swipeValue < 0 && transform.position.y > minY)
                    {
                        //down
                        camAnim.SetTrigger("shake");
                        Instantiate(moveEffect, transform.position, Quaternion.identity);
                        targetPos = new Vector2(transform.position.x, transform.position.y - increment);

                    }


                }



            }
        }

    }
}
