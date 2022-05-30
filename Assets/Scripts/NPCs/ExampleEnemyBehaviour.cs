using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleEnemyBehaviour : MonoBehaviour, NPC
{
    public float delay;
    [SerializeField] Vector3 step = Vector3.zero;
    GameObject head;

    private void Start()
    {
        head=GetComponentInChildren<Head>().gameObject;
    }

    public Aim GetAim()
    {
        return new Aim(head, gameObject, this);
    }

    public void GetKilled()
    {
        EventHolder.Awake(new DeathEv(this));
        Destroy(gameObject);
    }

    public void Act()
    {
        EventHolder.Awake(new EnemyTookOutEv(GetAim()));
        transform.localPosition += step;
    }
}
