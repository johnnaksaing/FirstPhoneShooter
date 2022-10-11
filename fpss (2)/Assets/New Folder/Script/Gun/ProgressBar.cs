using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    //프로그래스 바 밸류(두번쨰 이미지)
    [SerializeField]
    RectTransform pb;
    //프로그래스 바 컨테이너 껍데기(첫번째 이미지)
    [SerializeField]
    RectTransform pbContainer;

    //프로그래스 값
    float pbValue;

    void Update()
    {
        //시간 마다 값을 증가시킨다.
        pbValue += (Time.deltaTime * 500);

        //값이 최대치에 이르면 초기화시킨다.
        if (pbValue >= pbContainer.sizeDelta.x)
        {
            pbValue = 0;
        }
        else
        {
            //증가된값을 밸류의 width 값으로 넣어준다.
            pb.sizeDelta = new Vector2(pbValue, pb.sizeDelta.y);
        }

    }
}
