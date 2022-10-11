using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("In-Game Objects") ,SerializeField]
    PlaceARObject gun;

    [SerializeField]
    AmmoController m_Ammo;

    [SerializeField]
    PlayerScript pc;

    [Header("UI Objects"), SerializeField]
    Text m_GunMagCount;
    [SerializeField]
    Text m_AmmoCount;

    [SerializeField]
    Text m_Score;

    [SerializeField]
    Text m_LeftTime;


    [SerializeField]
    Text m_health;

    [SerializeField]
    public Text m_YouWin;


    [SerializeField]
    public Text m_YouLose;

    // Start is called before the first frame update
    void Start()
    {
        if (m_GunMagCount == null)
            Debug.LogError("UIManager : m_GunMagCount is Null");

        if (m_Score == null)
            Debug.LogError("UIManager : m_Ammo is Null");

        if (m_LeftTime == null)
            Debug.LogError("UIManager : m_Wind is Null");
    }

    // Update is called once per frame
    void Update()
    {
        m_GunMagCount.text = gun.curMagCount.ToString();
        m_AmmoCount.text = m_Ammo.m_totalAmmo.ToString();
        m_Score.text = GameModeManager.Inst.score.ToString();
        m_LeftTime.text = (Mathf.Floor( GameModeManager.Inst.LimitTime) ).ToString();

        m_health.text = pc.GetHp().ToString();
    }
}
