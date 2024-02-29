using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallCaster : MonoBehaviour
{
    public FireBall fireballPrefab;
    public Transform fireballSourceTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(fireballPrefab, fireballSourceTransform.position, fireballSourceTransform.rotation);
        }
    }
}
