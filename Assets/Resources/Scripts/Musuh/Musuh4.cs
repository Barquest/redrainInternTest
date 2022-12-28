using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh4 : Musuh
{
    public bool isMuter;

    protected override void Tembak()
    {
        base.Tembak();
        if (isMuter)
            transform.Rotate(new Vector3(0,0,45f));
    }
    public override void Move()
    {
        transform.Translate(-Vector2.right * Time.deltaTime * stats.speed,Space.World);

    }

}
