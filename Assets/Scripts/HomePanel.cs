using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePanel : MonoBehaviour {

	public void Start()
    {
		UpdateDeliveriesText();
    }

	public void UpdateDeliveriesText()
    {
		int score;
		score = FindObjectOfType<UserData>().GetDeliveries();
		GameObject.Find("Deliveries Complete Badge").GetComponentInChildren<Text>().text = "Deliveries Completed: " + score.ToString();
	}
		
	
}
