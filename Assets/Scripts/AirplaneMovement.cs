using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneMovement : MonoBehaviour
{
    public GameObject cityToMove;
    public float speed = 0.1f;
    public bool Sick = false;
    public bool timeStoped = false;
    void Update()
    {
        if (!timeStoped)
        {
            if (transform.position != cityToMove.transform.position)
            {
                transform.position = Vector2.MoveTowards(transform.position, cityToMove.transform.position, speed);
                transform.up = cityToMove.transform.position - transform.position;
            }

            if (Vector2.Distance(transform.position, cityToMove.transform.position) < 0.1f)
            {
                if (Sick == true)
                    cityToMove.transform.GetComponentInParent<ContinentData>().SickPeople++;
                Destroy(this.gameObject);
            }
        }         
    }
}
