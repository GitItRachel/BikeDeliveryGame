using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.MeshGeneration.Factories;
using System;

public class POIClick : MonoBehaviour {
    public int spawnCount;
    private GameDataStorage gamedata;
    private GameObject[] endMarkers;
    private GameObject endMarker;
    private GameObject directions;

    void Start()
    {
        directions = GameObject.Find("Directions Holder").transform.Find("Directions").gameObject;
    }
	void OnMouseDown()
    {
        endMarkers = GameObject.FindGameObjectsWithTag("Delivery End");
        foreach (GameObject marker in endMarkers)
        {
            if (marker.GetComponent<POIClick>().spawnCount == spawnCount)
            {
                endMarker = marker;
            }
        }
        directions.SetActive(true);
        directions.transform.Find("Waypoint1").transform.position = gameObject.transform.position;
        directions.transform.Find("Waypoint2").transform.position = endMarker.transform.position;
        directions.GetComponent<DirectionsFactory>().Query();
        StartCoroutine(UpdateRoute());
    }


    private IEnumerator UpdateRoute()
    {
        yield return new WaitForSeconds(2);
        directions.transform.Find("Waypoint1").transform.position = gameObject.transform.position;
        directions.transform.Find("Waypoint2").transform.position = endMarker.transform.position;
        directions.GetComponent<DirectionsFactory>().Query();
    }
}
