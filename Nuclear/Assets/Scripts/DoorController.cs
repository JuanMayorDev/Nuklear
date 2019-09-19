//
// Copyright 2019 JotaDev
// Author: Juan Camilo Mayor Taborda
// Created: 18/09/2019
//

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{



    #region Parameters

    // -------------PRIVATE----------------


    // -------------PUBLIC----------------
    public Transform door_a;
    public Transform door_b;
    public Transform spawn_a;
    public Transform spawn_b;

    #endregion



    // Start is called before the first frame update
    void Start()
    {
        SetChilds();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetChilds()
    {
        door_a = transform.GetChild(0);
        spawn_a = transform.GetChild(0).GetChild(0);
        door_b = transform.GetChild(1);
        spawn_b = transform.GetChild(1).GetChild(0);


    }

    public void SetTp(Transform recieved_door)
    {
        GameManager.Instance.door_to_tp = recieved_door == door_a ? spawn_b : spawn_a;
        GameManager.Instance.CameraTransition();

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Debug.Log("Yooo");
            if (col.GetComponent<PlayerController>().can_tp)
            {
                col.GetComponent<PlayerController>().can_move = false;
                col.GetComponent<PlayerController>().can_tp = false;
                GameManager.Instance.CameraTransition();
                GameManager.Instance.player_tr.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.tag == "Player")
        {
            if(col.transform.GetComponent<PlayerController>().can_tp)
            {
                col.transform.GetComponent<PlayerController>().can_move = false;
                col.transform.GetComponent<PlayerController>().can_tp = false;
                GameManager.Instance.door_to_tp = door_a;
            }

        }
    }

}
