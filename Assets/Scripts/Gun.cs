using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject spawn;
    [SerializeField] Camera cam = null;

    bool d = false;
    Ray d1;

    void Start()
    {
        EventHolder.AddListener<ShootEv>(Shoot);
    }

    void Shoot(ShootEv shootEv)
    {
        Ray ray = cam.ViewportPointToRay(new Vector2(shootEv.bullet.screenPoint.x/1920, shootEv.bullet.screenPoint.y/1080));
        d = true;
        d1 = ray;
        RaycastHit[] hitted = Physics.RaycastAll(ray);
        List<NPC> damaged = new List<NPC>();
        for (int i = 0; i < hitted.Length; i++)
        {
            for(int j = 1; j < hitted.Length - i; j++)
            {
                if(hitted[j].distance < hitted[j-1].distance)
                    (hitted[j], hitted[j - 1]) = (hitted[j - 1], hitted[j]);
            }
        }
        for(int i = 0; i < hitted.Length; i++)
        {
            var v = hitted[i].collider.GetComponentInParent<NPC>();
            if (v!=null&!damaged.Contains(v))
            {
                v.GetKilled();
                damaged.Add(v);
            }
            else
            {
                break;
            }
        }
        if(damaged.Count>0)
            EventHolder.Awake(new KillEv(new Shoot(damaged)));
    }

    private void OnDrawGizmos()
    {
        if(d) Debug.DrawRay(d1.origin, d1.direction * 100, Color.yellow);
    }
}
