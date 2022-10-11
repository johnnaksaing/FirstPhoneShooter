using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public int m_totalAmmo = 300;
    public UIManager m_uimanager;

    private void Start()
    {
        if (!m_uimanager)
            m_uimanager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }
}
