using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Connection;
using FishNet.Object;

public class cursorScript : NetworkBehaviour
{
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (true || base.IsOwner)
        {
            //transform.position = Input.mousePosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (base.IsOwner)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(pos.x, pos.y);
            gameObject.GetComponent<Renderer>().material.color = new Color(1, 0, 0);
            Cursor.visible = false;
        }
    }

    public override void OnStopClient()
    {
        base.OnStopClient();
        Cursor.visible = true;
    }
}
