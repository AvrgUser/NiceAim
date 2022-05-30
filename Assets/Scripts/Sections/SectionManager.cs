using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionManager : MonoBehaviour
{
    public GameObject self, start;
    GameObject player;
    public List<Port> ports = new List<Port>();
    public List<SectionManager> sections = new List<SectionManager>();
    bool used = false;

    public void Start()
    {
        player = InstancesManager.GetInstance<PlayerController>().gameObject;
        InstancesManager.GetInstance<UnitsCommander>().Initialize();
        EventHolder.AddListener<EnemiesOutEv>(LoadNewSection);
    }

    public void LoadNewSection(EnemiesOutEv ev)
    {
        if (!used)
        {
            var next = sections[Random.Range(0, sections.Count)];
            GameObject nextOBJ = Instantiate(next.self);
            var nextPort = ports[Random.Range(0, ports.Count)];
            next = nextOBJ.GetComponent<SectionManager>();
            next.sections = sections;
            nextOBJ.transform.rotation = nextPort.transform.rotation;
            nextOBJ.transform.position += Vector3.zero - next.start.transform.position;
            self.transform.position += next.start.transform.position - nextPort.transform.position;
            player.transform.position = nextPort.playerPosition.transform.position;
            used = true;
            player.transform.rotation = nextPort.playerPosition.transform.rotation;
        }
        else
        {
            Destroy(self);
        }
    }
}
