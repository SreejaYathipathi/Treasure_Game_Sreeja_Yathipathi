using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutTag : MonoBehaviour
{
    public UIManager.MenuLayouts myLayout;
    private GameObject displayObject;

    private void Awake()
    {
        displayObject = transform.GetChild(0).gameObject;
    }

    public void DisableLayout()
    {
        displayObject.SetActive(false);
    }

    public void EnableLayout()
    {
        displayObject.SetActive(true);
    }
}
