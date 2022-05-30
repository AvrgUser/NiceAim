using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitsCommander : MonoBehaviour
{
    public List<ExampleEnemyBehaviour> units = new List<ExampleEnemyBehaviour>();

    public void Awake()
    {
        InstancesManager.RegisterInstance(this);
    }

    public void Initialize()
    {
        List<int> used = new List<int>(), left = new List<int>();
        for (int i = 0; units.Count > i; i++) left.Add(i);
        for(int i = 0; left.Count > 0; i++)
        {
            int a = Random.Range(0, left.Count-1);
            used.Add(left[a]);
            left.Remove(left[a]);
        }
        StartCoroutine(Attack(used.ToArray()));
    }

    IEnumerator Attack(int[] order)
    {
        var allUnits = units.ToArray();
        int i = 0;
        if(order.Length == 0)
        {
            Debug.Log($"empty, gmbj {gameObject.AddComponent<Animation>()}");
            yield break;
        }
        allUnits[order[i]].Act();
        while (true)
        {
            yield return null;
            if (allUnits[order[i]] == null)
            {
                units.Remove(allUnits[order[i]]);
                i++;
                if(i >= order.Length)
                {
                    EventHolder.Awake(new EnemiesOutEv());
                    yield break;
                }
                else if (allUnits[order[i]] != null)
                {
                    allUnits[order[i]].Act();
                }
            }
        }
    }
}