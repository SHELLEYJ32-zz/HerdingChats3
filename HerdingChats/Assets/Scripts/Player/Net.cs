using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Net : MonoBehaviour
{

    private float netTimer;

    // Start is called before the first frame update
    void Start()
    {
        netTimer = Global.Instance.netTimer;
    }

    // Update is called once per frame
    void Update()
    {
        netTimer = netTimer - Time.deltaTime;
        if (netTimer <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}
