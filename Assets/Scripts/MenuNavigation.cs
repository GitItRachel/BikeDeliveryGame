using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class MenuNavigation : MonoBehaviour {
    [SerializeField] private GameObject homepanel;

    private void Awake()
    {
        Assert.IsNotNull(homepanel);
    }
    
    public void EnableHomePanel()
    {
        homepanel.SetActive(true);
    }

    public void DisableHomePanel()
    {
        homepanel.SetActive(!homepanel.activeSelf);
    }
}
