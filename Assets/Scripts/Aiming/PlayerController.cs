using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public UIController ui;
    public Camera cam;
    AimController Controller;
    public float sens = 1, time = 1.5f;

    public KeyCode shoot_key = KeyCode.Mouse0;

    public Vector2 borders = new Vector2(100, 100);

    public void Awake()
    {
        InstancesManager.RegisterInstance(this);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Controller =GetComponent<AimController>();
        EventHolder.AddListener<KillEv>(OnEnemiesKilled);
    }

    void OnEnemiesKilled(KillEv ev)
    {
        ui.EnhanceCounter(ev.shoot.damaged.Count);
    }

    public void StartAim(Aim aim)
    {
        
        ui.DisplayField();
        StartCoroutine(CrosshairMover(aim.body));
    }

    public void StopAim()
    {
        ui.HideField();
    }

    IEnumerator CrosshairMover(GameObject aim)
    {
        Vector3 origin = ui.field.position;
        float timeLeft = 0;
        while (timeLeft<time)
        {
            ui.timer1.value = (time-timeLeft) / time;
            ui.timer2.text = (Mathf.Round((time-timeLeft)*100)/100).ToString();
            ui.crosshair.position += new Vector3(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")) * sens;
            ui.crosshair.position = new Vector3(Mathf.Clamp(ui.crosshair.position.x, origin.x - borders.x, origin.x + borders.x), Mathf.Clamp(ui.crosshair.position.y, origin.y - borders.y, origin.y + borders.y));
            Vector2 point = cam.WorldToScreenPoint(aim.transform.position);
            ui.UpdateAimInfo(point, Vector3.Distance(transform.position, aim.transform.position));
            timeLeft += Time.deltaTime;
            yield return null;
            if (Input.GetKeyDown(shoot_key))
            {
                EventHolder.Awake(new ShootEv(gameObject, new Bullet(ui.crosshair.position)));
                break;
            }
        }
        StopAim();
        Controller.WakeUp();
    }
}
