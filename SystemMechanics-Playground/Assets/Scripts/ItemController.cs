using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        //calls gameManager and accesses the onItemPickupTrigger action
        //adds ItemController to gameManager list of subscribed events
        GameManager.current.onItemPickupTrigger += OnItemPickup;
        count = 0;
    }


    //method that listens to event
    private void OnItemPickup()
    {
        //add item to inventory when pickedup
        //increase item counter
        Debug.Log("this item is collected");
    }

    /*private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("I got it");
        GameManager.current.ItemPickup();
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Debug.Log("triggered by item");
            GameManager.current.ItemPickup();
            count += 1;
        }
    }
}
