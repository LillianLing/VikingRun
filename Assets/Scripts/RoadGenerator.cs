using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadGenerator : MonoBehaviour
{
    //53.5F
    private float spawnz = -6f;
    private float spawnx = 0f;
    public GameObject[] prefabs;
    private float roadLength = 55f;
    private float roadWeight = -57f;
    private int amountOfRoad = 2;

    private List<GameObject> roadList;
    private Transform player;

    void Start()
    {
        roadList = new List<GameObject>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        for(int i = 0; i < prefabs.Length; ++i)
        {
            SpawnRoad(i);
        }
    }

    void Update()
    {
        if(player.position.z > spawnz - roadLength * (amountOfRoad-1))
        {
            int r = Random.Range(0, prefabs.Length);
            SpawnRoad(r);
            DeleteRoad();
        }
    }

    void SpawnRoad(int prefabIndex)
    {
        GameObject go;

        go = Instantiate(prefabs[prefabIndex]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnz + Vector3.right*(spawnx);
        spawnz += roadLength;
        if (prefabIndex == 2)
        {
            go.transform.position += Vector3.right * (-2) ;
            spawnx += roadWeight;
            spawnz += 7;
        }
        else
        {
            go.transform.position += Vector3.forward * (5);
            spawnz += 5;
        }

        // Add gameobject to list
        roadList.Add(go);
    }

    void DeleteRoad()
    {
        Destroy(roadList[0]);
        roadList.RemoveAt(0);
    }


    /*   public Transform startPosition;
       float NextStep;
       public GameObject[] prefabs;

       // Start is called before the first frame update
       void Start()
       {

       }

       // Update is called once per frame
       void Update()
       {
           NextStep += 53;

           Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(startPosition.position.x, startPosition.position.y, startPosition.position.z + NextStep), Quaternion.identity);
       }*/
}
