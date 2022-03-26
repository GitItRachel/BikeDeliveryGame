using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPSData : MonoBehaviour {

    public float latitude;
    public float longitude;
    bool isUnityRemote = true;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start () {
        StartCoroutine(StartLocationService());
    }
	
	// Update is called once per frame
	void Update () {
    }

    private IEnumerator StartLocationService()
    {
        if (isUnityRemote)
        {
            yield return new WaitForSeconds(5);
        }

        if (Input.location.isEnabledByUser)
        {
            Input.location.Start();
            int maxWait = 20;
            while (Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
            {
                yield return new WaitForSeconds(1);
                maxWait--;
            }

            if (maxWait <= 0)
            {
                Debug.Log("Timed Out");
                yield break;
            }

            if (Input.location.status == LocationServiceStatus.Failed)
            {
                Debug.Log("Unable to Get Location");
                yield break;
            }

            latitude = Input.location.lastData.latitude;
            longitude = Input.location.lastData.longitude;
            Debug.Log("Location services started");
            yield break;
        }
        else
        {
            Debug.Log("Location services not enabled");
            yield break;
        }
    }
}
