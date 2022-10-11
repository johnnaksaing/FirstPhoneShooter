using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{

    //���α׷��� �� ���(�ι��� �̹���)
    [SerializeField]
    RectTransform pb;
    //���α׷��� �� �����̳� ������(ù��° �̹���)
    [SerializeField]
    RectTransform pbContainer;

    //���α׷��� ��
    float pbValue;

    void Update()
    {
        //�ð� ���� ���� ������Ų��.
        pbValue += (Time.deltaTime * 500);

        //���� �ִ�ġ�� �̸��� �ʱ�ȭ��Ų��.
        if (pbValue >= pbContainer.sizeDelta.x)
        {
            pbValue = 0;
        }
        else
        {
            //�����Ȱ��� ����� width ������ �־��ش�.
            pb.sizeDelta = new Vector2(pbValue, pb.sizeDelta.y);
        }

    }
}
