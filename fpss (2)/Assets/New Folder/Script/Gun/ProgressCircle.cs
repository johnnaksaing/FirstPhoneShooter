using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressCircle : MonoBehaviour
{
    public Text ProgressIndicator;
    public Image LoadingBar;
    float currentValue;
    public float CooldownTime;

    //float currentTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    bool bDone = true;
    // Update is called once per frame
    void Update()
    {
        if (bDone) return;

        if (currentValue < 1)
        {
            currentValue += Time.deltaTime / CooldownTime;
            ProgressIndicator.text = ((int)(currentValue * 100)).ToString() + "%";
        }
        else
        {
            ProgressIndicator.text = "Done";
            gameObject.SetActive(false);
        }

        LoadingBar.fillAmount = currentValue;
    }

    public void LaunchBar(float seconds) 
    {
        currentValue = 0;
        CooldownTime = seconds;
        gameObject.SetActive(true);
        bDone = false;
    }
}
