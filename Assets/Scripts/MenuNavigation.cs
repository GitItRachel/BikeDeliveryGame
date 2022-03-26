using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour {
    [SerializeField] private GameObject homepanel;
    [SerializeField] private GameObject deliverypanel;
    [SerializeField] private GameObject mappanel;
    [SerializeField] private GameObject leaderpanel;

    private void Awake()
    {
        Assert.IsNotNull(homepanel);
        Assert.IsNotNull(deliverypanel);
        Assert.IsNotNull(mappanel);
        Assert.IsNotNull(leaderpanel);
    }
    
    public void EnableHomePanel()
    {
        homepanel.SetActive(true);
    }

    public void DisableHomePanel()
    {
        homepanel.SetActive(false);
    }

    public void EnableDeliveryPanel()
    {
        deliverypanel.SetActive(true);
    }

    public void DisableDeliveryPanel()
    {
        deliverypanel.SetActive(false);
    }

    public void EnableMapPanel()
    {
        mappanel.SetActive(true);
    }

    public void DisableMapPanel()
    {
        mappanel.SetActive(false);
    }

    public void EnableLeadPanel()
    {
        leaderpanel.SetActive(true);
    }

    public void DisableLeadPanel()
    {
        leaderpanel.SetActive(false);
    }

    public void MapScene()
    {
        SceneManager.LoadScene("MapView");
    }
}
