using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Self : MonoBehaviour
{
    public float destructTime;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = destructTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0){
            Destroy(gameObject);
        }
    }
}
