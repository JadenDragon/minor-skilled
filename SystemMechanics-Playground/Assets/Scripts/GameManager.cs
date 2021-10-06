using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //references the script to be used
    public static GameManager current;

    private void Awake()
    {
        current = this;
    }

    //define onItemPickup event
    public event System.Action onItemPickupTrigger;

    public void ItemPickup()
    {
        if (onItemPickupTrigger != null)
        {
            Debug.Log("Item is here boy");
            onItemPickupTrigger();
            
        }
    }
}
