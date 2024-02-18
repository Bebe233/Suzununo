using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        get_input();
        do_move();
    }

    public float speed = 3, angle = 200;
    private void do_move()
    {
        Vector3 dir_move = new Vector3(x, 0, y).normalized;
        transform.Translate(dir_move * speed * Time.deltaTime, Space.Self);
        // if (mouse_x != 0)
        //     transform.Rotate(Vector3.up, mouse_x * Time.deltaTime * angle, Space.Self);
        // if (mouse_y != 0)
        //     transform.Rotate(Vector3.right, mouse_y * Time.deltaTime * angle, Space.World);
    }

    private float x, y, mouse_x, mouse_y;

    private void get_input()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        var temp_x = Input.GetAxis("Mouse X");
        if (temp_x > 0.1f || temp_x < -0.1f) mouse_x = temp_x;
        else mouse_x = 0;

        var temp_y = Input.GetAxis("Mouse Y");
        if (temp_y > 0.1f || temp_y < -0.1f) mouse_y = temp_y;
        else mouse_y = 0;
    }
}
