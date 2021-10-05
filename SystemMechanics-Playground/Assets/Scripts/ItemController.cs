using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //calls gameManager and accesses the onItemPickupTrigger action
        //adds ItemController to gameManer list of subscribed events
        GameManager.current.onItemPickupTrigger += OnItemPickup;
    }


    //method that listens to event
    private void OnItemPickup()
    {
        //add item to inventory when pickedup
        //increase item counter
        Debug.Log("this item is collected" +1);
    }
}
