﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;
using UnityEngine.UI;

public class DeliveryButton : MonoBehaviour {

    private string[] deliveryStartMarkers;
    private string[] deliveryEndMarkers;
    private GameDataStorage gamedata;
    private float maxDistance = 0.0001f;
    private bool isDeliveryStarted = false;
    private float deliveryTime = 0.0f;
    private float deliveryMiles = 0;
    private Vector2 startlocation;
    Text buttonText;

    // Use this for initialization
    void Start () {
        gamedata = GameObject.Find("GameData").GetComponent<GameDataStorage>();
        deliveryStartMarkers = gamedata.GetDeliveryStartStrings();
        deliveryEndMarkers = gamedata.GetDeliveryEndStrings();
        buttonText = GameObject.Find("Start Button Text").GetComponent<Text>();
    }

    void Update()
    {
        if (Input.location.status == LocationServiceStatus.Running)
        //Check if user is within range of delivery start
            if (isDeliveryStarted)
            {
                if (CloseToMarker(deliveryEndMarkers))
                {
                    buttonText.text = "Complete Delivery";
                }
                else
                {
                    buttonText.text = "Cancel Delivery";
                }
                deliveryTime += Time.deltaTime;
                deliveryMiles = Vector2.Distance(new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude), startlocation);
            }
            else
            {
                if (CloseToMarker(deliveryStartMarkers))
                {
                    buttonText.text = "Start Delivery";
                }
                else
                {
                    buttonText.text = "Out of Range of Delivery Start";
                    GetComponent<Button>().interactable = false;
                }
            }
    }

    /// <summary>
    /// Function Name: CloseToMarker
    /// Summary: This function takes in an array of locations as a string in the format
    /// "latitutude, longitude" and returns true if the device location is within range
    /// of one of the markers.
    /// </summary>
    /// <param name="markerlist"></param>
    /// <returns>True if device in range of a marker in the provided list.  False otherwise. </returns>
    public bool CloseToMarker(string[] markerlist)
    {
        foreach (string location in markerlist)
        {
            string[] latlong = location.Split(',');
            float latitude = System.Convert.ToSingle(latlong[0]);
            float longitude = System.Convert.ToSingle(latlong[1]);
            Vector2 markerlocationvector = new Vector2(latitude, longitude);
            Vector2 userlocationvector = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
            if (Vector2.Distance(markerlocationvector, userlocationvector) <= maxDistance)
            {
                return true;
            }
        }
        return false;
    }

    public void StartDelivery()
    {
        isDeliveryStarted = true;
        deliveryTime = 0.0f;
        startlocation = new Vector2(Input.location.lastData.latitude, Input.location.lastData.longitude);
    }

    public void StopDelivery()
    {
        isDeliveryStarted = false;
    }

    public void AbortDelivery()
    {
        isDeliveryStarted = false;
    }

    public void ButtonPress()
    {
        if (buttonText.text == "Start Delivery")
        {
            StartDelivery();
        }
        else if (buttonText.text == "Complete Delivery")
        {
            StopDelivery();
        }
        else if (buttonText.text == "Cancel Delivery")
        {
            AbortDelivery();
        }
    }


}
