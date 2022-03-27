using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mapbox.Unity.Utilities;
using Mapbox.Utils;

public class GameDataStorage : MonoBehaviour {
	[SerializeField]
	[Geocode]
	string[] _deliveryStartStrings;
	[SerializeField]
	[Geocode]
	string[] _deliveryEndStrings;

	public string[] GetDeliveryStartStrings()
    {
		return _deliveryStartStrings;
    }

	public string[] GetDeliveryEndStrings()
    {
		return _deliveryEndStrings;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
}
