using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;  //  ARRaycastManager
using UnityEngine.XR.ARSubsystems;  //  TrackableType

public class PlaceARObject : MonoBehaviour
{
    [Header("레이케스트 매니져"), SerializeField]
    ARRaycastManager _arRaycastManager;
    [Header("레이캐스트를 시작하는 AR 카메라"), SerializeField]
    Camera _cam;

    //---------------------------------------
    [Header("스크린을 탭 했을때 생성할 오브젝트 "), SerializeField]
    GameObject _spawnObject;
    [SerializeField]
    GameObject _spawnPowerObject;
    [Header("Fire(Bullet Spawning) Position"), SerializeField]
    Transform _firePosition;

    public float fireAngle = 1f;
    public float fireRate = 0.5f;
    float curTime = 0f;

    PlayerScript me;

    public float ReloadTime = 2f;
    public bool bReloading = false;
    public int MagCount = 20;
    public int curMagCount;

    public ProgressCircle m_ReloadBar;
    public AmmoController m_Ammo;

    private void Start()
    {
        curMagCount = MagCount;
        me = GetComponent<PlayerScript>();
    }
    private void Update()
    {
        curTime += Time.deltaTime;
        if (Input.GetMouseButton/*Down*/(0) && !bReloading && curTime > fireRate && curMagCount > 0)
        {
            Vector3 pos = _firePosition.position;//transform.position;// + Vector3.up;

            if (!me.bPowered)
                Instantiate(_spawnObject, pos, transform.rotation);
            else
                Instantiate(_spawnPowerObject, pos, transform.rotation);

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
        //m_ReloadBar.LaunchBar(ReloadTime);
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

    void LateUpdate()
    {
        Vector2 viewportCenter = new Vector2 (0.5f, 0.5f);
        var screenCenter = _cam.ViewportToScreenPoint(viewportCenter);
        UpdateIndicator(screenCenter);

    }
    void UpdateIndicator( Vector2 screenPos )
    {
        var hits = new List<ARRaycastHit>();

        if(_arRaycastManager.Raycast(screenPos, hits,TrackableType.Planes))
        {
            if (hits.Count > 0)
            {
                //  Pose
                //  -   3D 공간에서 위치와 회전값을 함께 관리하는 구조체..
                //  -   주로 XR 어플리케이션을 사용하는 디바이스의 3D공간상의
                //      현재 위치와 회전값을 표현하는데 사용..
                var placementsPose = hits[0].pose;

                var camForward = _cam.transform.forward;

                camForward.y = 0;
                camForward.Normalize();
                placementsPose.rotation = Quaternion.LookRotation(camForward);
                var newPose = placementsPose.position;
                newPose.y += 0.001f;

                transform.SetPositionAndRotation(newPose, placementsPose.rotation);

            }// if( hits.Count > 0 )

        }// if(_arRaycastManager.Raycast(screenPos, hits))

    }// void UpdateIndicator( Vector2 screenPos )
    //-------------------------------

}// public class PlaceARObject : MonoBehaviour
 //==========================================================================