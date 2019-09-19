//
// Copyright 2019 JotaDev
// Author: Juan Camilo Mayor Taborda
// Created: 18/09/2019
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    #region Parameters

    // -------------PRIVATE----------------

    private Rigidbody2D my_rb;

    private float v;
    private float h;

    [SerializeField]
    private GameObject exclamation;
    private SpriteRenderer my_sprite;
    private Animator my_anim;


    // -------------PUBLIC----------------

    public Transform my_tr;
    public float movement_speed;
    public float current_speed;

    public bool can_move;
    public bool can_interact;
    public bool interacting;
    public bool can_tp;

    #endregion




    #region Functions
    // Start is called before the first frame update
    void Start()
    {
        can_move = true;
        can_tp = true;
        my_rb = GetComponent<Rigidbody2D>();
        my_tr = GetComponent<Transform>();
        my_sprite = GetComponent<SpriteRenderer>();
        my_anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void FixedUpdate()
    {

        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");

        if(can_move)
        {
            PlayerMovement();
        }

        PlayerActions();

    }
    void PlayerMovement()
    {
        if(h > .1f)
        {
            my_sprite.flipX = false;
        }
        else if( h < -.1f)
        {
            my_sprite.flipX = true;
        }

        current_speed = new Vector2(h, v).sqrMagnitude;
        my_anim.SetFloat("Speed", current_speed);

        if (current_speed > .5f)
        {
            my_rb.velocity = new Vector2(h, v).normalized * movement_speed * Time.deltaTime;
        }
        else if (current_speed < .5)
        {
            my_rb.velocity -= my_rb.velocity * .5f;
        }
            my_anim.SetFloat("Speed", current_speed);


    }

    void PlayerActions()
    {
        if (Input.GetKeyDown(KeyCode.E) && can_interact)
        {
            Interact();
        }
        if (Input.GetKeyDown(KeyCode.Space) && interacting)
        {
            Interact();
        }
    }

    void Interact()
    {
        can_move = !can_move;
        can_interact = !can_interact;
        interacting = !interacting;
    }

    public void Interactable()
    {
        can_interact = !can_interact;
        exclamation.SetActive(!exclamation.activeSelf);
    }



    #region Collisions


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Interactable")
        {
            Interactable();
        }
        else if(col.tag == "Door")
        {
            can_move = false;
            can_tp = false;
            my_anim.SetFloat("Speed", 0);
            col.transform.parent.GetComponent<DoorController>().SetTp(col.transform);
            my_rb.velocity = Vector2.zero;
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Interactable")
        {
            Interactable();
        }
        if(col.tag == "Door" )
        {
            can_tp = true;
        }
    }

    #endregion


    #endregion



}
