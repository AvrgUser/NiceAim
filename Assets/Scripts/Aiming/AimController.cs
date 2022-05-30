using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    PlayerController player;

    List<Aim> aims = new List<Aim>();

    public bool Empty => aims.Count == 0;

    public void WakeUp()
    {
        StopAllCoroutines();
        StartCoroutine(Work());
    }

    IEnumerator Work()
    {
        while (true)
        {
            if (!Empty)
            {
                var aim = GetNext();
                player.StartAim(aim);
                yield break;
            }
            yield return null;
        }
    }

    public void Refresh(DeathEv ev)
    {
        foreach (var aim in aims)
        {
            if (aim.self == ev.died)
            {
                aims.Remove(aim);
                break;
            }
        }
    }

    public Aim GetNext()
    {
        if (!Empty)
        {
            int ret = 0;
            for(int i = 0; i < aims.Count; i++)
            {
                if (aims[i].importancy > aims[ret].importancy) ret = 1;
            }
            Aim aim = aims[ret];
            return aim;
        }
        return null;
    }

    void Awake()
    {
        player = GetComponent<PlayerController>();
        EventHolder.AddListener<EnemyTookOutEv>(AutoAdd);
        EventHolder.AddListener<DeathEv>(Refresh);
    }

    public void Start()
    {
        WakeUp();
    }

    void AutoAdd(EnemyTookOutEv ev)
    {
        aims.Add(ev.enemy);
    }
}
