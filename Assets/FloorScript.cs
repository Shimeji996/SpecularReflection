using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    ReflectionProbe probe;

    // Start is called before the first frame update
    void Start()
    {
        this.probe = GetComponent<ReflectionProbe>();
    }

    // Update is called once per frame
    void Update()
    {
        // y‚É1‚ð‚©‚¯‚Ä‹t‘¤‚É”z’u
        this.probe.transform.position = 
            new Vector3(Camera.main.transform.position.x,
                        Camera.main.transform.position.y*-1,
                        Camera.main.transform.position.z);
        probe.RenderProbe();
    }
}
