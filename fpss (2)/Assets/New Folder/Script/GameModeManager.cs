using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    static Vector3 pos;
    
    [SerializeField]
    GameObject pfb_eMob;

    [SerializeField]
    GameObject pfb_eBoss;

    [SerializeField]
    public PlayerScript _player;

    public static GameModeManager Inst;

    [SerializeField]
    UIManager ui;

    public int score = 0;
    public int CountToBoss = 10;

    public float LimitTime = 30f;

    // Start is called before the first frame update
    void Start()
    {
        if(Inst == null)
            Inst = this;
        SpawnEnemyMob();
        InvokeRepeating("SpawnEnemyMob",0.5f,Random.Range(1f,1f));
        InvokeRepeating("SpawnPickupItem", 0.5f, Random.Range(3f, 7f));


        LimitTime = 30f;
    }
    bool bYouLose = false;
    bool bYouWin = false;
    // Update is called once per frame
    void Update()
    {
        if (bYouWin)
            return;

        if (LimitTime < 0f && !bYouLose)
            YouLose();
        else
            LimitTime -= Time.deltaTime;
    }

    public void SpawnEnemyMob()
    {
        pos = _player.transform.position + _player.transform.forward * 4f + new Vector3(Random.Range(-2f, 2f), Random.Range(-2f, 2f), Random.Range(2f, 4f));
        
        EnemyMob e = Instantiate(pfb_eMob,pos,Quaternion.identity).GetComponent<EnemyMob>();
        e.player = _player.transform;
    }

    [SerializeField]
    List<GameObject> pfb_Pickups = new List<GameObject>();
    public void SpawnPickupItem() 
    {
        pos = _player.transform.position + _player.transform.forward * 3f + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(2f, 4f));

        int idx = Random.Range(0,pfb_Pickups.Count);
        Instantiate(pfb_Pickups[idx], pos, Quaternion.identity);
    }

    public void SpawnEnemyBoss()
    {
        CancelInvoke("SpawnEnemyMob");

        pos = _player.transform.position + _player.transform.forward * 5f + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(2f, 4f));
        EnemyBoss e = Instantiate(pfb_eBoss, pos, Quaternion.identity).GetComponent<EnemyBoss>();
        e.player = _player.transform;
    }

    public void YouWin() 
    {
        Debug.Log("You Win");
        ui.m_YouWin.gameObject.SetActive(true);
        bYouWin = true;
        CancelInvoke();
    }
    public void YouLose()
    {
        Debug.Log("You Lose");
        bYouLose = true;
        CancelInvoke();
        bEnemyStunned = true;
        ui.m_YouLose.gameObject.SetActive(true);
    }

    public bool bEnemyStunned = false;

    public void StunEnemy()
    {
        bEnemyStunned = true;
        Invoke("DeStunEmeny",3f);
    }
    void DeStunEnemy()
    {
        bEnemyStunned = false;
    }
}
