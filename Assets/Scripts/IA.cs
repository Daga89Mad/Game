using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{

    public int MoveSpeed;
    public float MaxDist;
    public float MinDist;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Transform Player = GameObject.Find("0.1.Daga").transform;
        Vector3 EnemyPos = transform.position;
        Vector3 PlayerPos = Player.position;
        float distancia = Vector3.Distance(EnemyPos, PlayerPos);

        if (distancia >= MinDist && distancia <= MaxDist)
        {
            Vector3 targetPos = new Vector3(Player.position.x,
            this.transform.position.y,
            Player.position.z);
            transform.LookAt(targetPos);
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;

        }


    }
}