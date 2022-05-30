using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public RectTransform field;
    public Slider timer1;
    public TextMeshProUGUI timer2;
    public RectTransform crosshair;
    public TextMeshProUGUI counter;
    RectTransform timerLength;

    public void Awake()
    {
        InstancesManager.RegisterInstance(this);
    }

    private void Start()
    {
        timerLength = timer1.GetComponent<RectTransform>();
    }

    public void DisplayField()
    {
        field.gameObject.SetActive(true);
        crosshair.gameObject.SetActive(true);
    }

    public void UpdateAimInfo(Vector3 point, float dist)
    {
        field.transform.position = point;
        if (field.transform.localPosition.x > 0)
        {
            field.transform.localScale = new Vector3(-1, field.transform.localScale.y, field.transform.localScale.z);
            timerLength.localScale = new Vector3(timerLength.localScale.x, -1, timerLength.localScale.z);
        }
        else
        {
            field.transform.localScale = new Vector3(1, field.transform.localScale.y, field.transform.localScale.z);
            timerLength.localScale = new Vector3(timerLength.localScale.x, 1, timerLength.localScale.z);
        }
        timerLength.localPosition = new Vector3(1920 / dist / 2, 0, 0);
        timerLength.sizeDelta = new Vector2(30 + 2000 / (dist*Mathf.Sqrt(dist/5)), 5 + 40 / dist);
    }

    public void HideField()
    {
        crosshair.gameObject.SetActive(false);
        field.gameObject.SetActive(false);
    }

    public void EnhanceCounter()
    {
        UpdateCounter(Convert.ToInt32(counter.text)+1);
    }
    public void EnhanceCounter(int c)
    {
        UpdateCounter(Convert.ToInt32(counter.text) + c);
    }

    public void UpdateCounter(int count)
    {
        counter.text = count.ToString();
    }
}
