using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guntroller : MonoBehaviour
{
    [SerializeField]
    Transform FireTransform;

    [SerializeField]
    GameObject m_pfbBullet;

    public float fireAngle = 1f;
    public float fireRate = 0.05f;
    float curTime = 0f;

    public float ReloadTime = 1.5f;
    public bool bReloading = false;
    public int MagCount = 30;
    public int curMagCount;

    public ProgressCircle m_ReloadBar;
    public AmmoController m_Ammo;

    // Start is called before the first frame update
    void Start()
    {
        if (FireTransform == null)
        {
            FireTransform = transform.Find("FireOffset").transform;
        }
        curMagCount = MagCount;

        if (m_ReloadBar == null) 
        {
            Debug.LogWarning("m_ReloadBar is null");
        }

        if (m_Ammo == null)
        {
            Debug.LogError("m_Ammo is null");
        }
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (Input.GetMouseButton/*Down*/(0) && !bReloading && curTime > fireRate && curMagCount > 0)
        {
            Vector3 vec_random = new Vector3(
                Random.Range(-fireAngle, fireAngle),
                Random.Range(-fireAngle, fireAngle),
                Random.Range(-fireAngle, fireAngle));

            FireTransform.rotation = Quaternion.Euler(vec_random);

            Instantiate(m_pfbBullet, FireTransform.position, FireTransform.rotation);
            curTime = 0f;
            curMagCount--;

            if (curMagCount <= 0)
                Reload();
        }

        if (Input.GetKeyDown(KeyCode.R)) 
        {
            Reload();
        }
    }

    void Reload() 
    {
        Debug.Log("Start Reloading");

        if (m_Ammo.m_totalAmmo <= 0) 
        {
            Debug.Log("no ammo");
            return;
        }

        bReloading = true;
        m_ReloadBar.LaunchBar(ReloadTime);
        StartCoroutine("c_Reload");
    }
    
    IEnumerator c_Reload() 
    {
        yield return new WaitForSeconds(ReloadTime);

        int AmmoAmount = MagCount - curMagCount;
        if (m_Ammo.m_totalAmmo - AmmoAmount < 0) 
        {
            AmmoAmount = m_Ammo.m_totalAmmo;
        }
        //curMagCount = m_Ammo.m_totalAmmo < MagCount? m_Ammo.m_totalAmmo : MagCount;

        m_Ammo.m_totalAmmo -= AmmoAmount;
        curMagCount += AmmoAmount;
        bReloading = false;
        Debug.Log("End Reloading");
    }

    IEnumerator c_Cooltime()
    {
        while(true)
        {
        //    if ( )
                yield break;

        }

    }
}

