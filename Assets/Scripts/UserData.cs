using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserData : MonoBehaviour {

    [SerializeField] private int deliveries;
    [SerializeField] private float miles;
    
    public int GetDeliveries()
    {
        return deliveries;
    }
}
