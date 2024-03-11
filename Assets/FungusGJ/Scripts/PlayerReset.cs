using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerReset : MonoBehaviour
{

    public Transform resetPoint;
    public Transform resetPoint2;
    public Transform resetPoint3;


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Respawn")
        {

            transform.position = resetPoint.position;
        }

        if (other.gameObject.tag == "Respawn2")
        {

            transform.position = resetPoint2.position;
        }

        if (other.gameObject.tag == "Respawn3")
        {

            transform.position = resetPoint3.position;
        }
    }
}
