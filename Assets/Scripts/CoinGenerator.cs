using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{

    public GameObject[] coins;
    public float coinTime;
    public Transform player;

    int turn = 0;
   
    // Start is called before the first frame update
    void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(spawnCoin());
    }

    IEnumerator spawnCoin()
    {
        yield return new WaitForSeconds(coinTime);
        spawn();
    }

    void spawn()
    {
        for(int i = 0; i < 3; i++)
        {
            int r = Random.Range(0, coins.Length);

            Vector3 coinp;
            

            if (turn == 0)
            {
                coinp = new Vector3(player.localPosition.x, 0.7f, player.localPosition.z + 6 * (i + 1));
            }
            else
            {
                coinp = new Vector3(player.localPosition.x - 6  * (i + 1), 0.7f, player.localPosition.z);
            }

            Instantiate(coins[r],coinp,coins[r].transform.rotation);

        }


        StartCoroutine(spawnCoin());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) turn = 1;
        else if (Input.GetKey(KeyCode.D)) turn = 0;
    }
}
