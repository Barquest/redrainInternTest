using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musuh8 : Musuh
{
    public bool gantiLane;
    public float gantiLaneMaxCooldown;
    public float gantiLaneSpeed = 5f;
    private float gantiLaneCooldown;
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        gantiLaneCooldown = gantiLaneMaxCooldown;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

        if (gantiLaneCooldown > 0)
        {
            if (!gantiLane)
                gantiLaneCooldown -= Time.deltaTime;
        }
        else if (gantiLaneCooldown < 0)
        {
            gantiLaneCooldown = 0;
        }
        else {
            StartCoroutine(GantiLane());
        }
    }
    public IEnumerator GantiLane()
    {
        gantiLane = true;
        gantiLaneCooldown = gantiLaneMaxCooldown;
        float targetY = transform.position.y * -1;
        if (targetY > 0)
        {
            while (transform.position.y <= targetY)
            {
                transform.Translate(Vector2.up * Time.deltaTime * gantiLaneSpeed, Space.World);
                yield return new WaitForEndOfFrame();
            }
        }
        else {
            while (transform.position.y >= targetY)
            {
                transform.Translate(-Vector2.up * Time.deltaTime * gantiLaneSpeed, Space.World);
                yield return new WaitForEndOfFrame();
            }
        }
        gantiLane = false;
    }
    public override void Mati()
    {
        base.Mati();
        gantiLane = false;
        gantiLaneCooldown = gantiLaneMaxCooldown;

    }
}
