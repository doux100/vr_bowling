using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoving : MonoBehaviour
{
    [SerializeField] private AudioClip strikeClip;
    [SerializeField] private AudioClip rollingClip;
    [SerializeField] private Vector3 positionRespawn;
    private AudioSource x;
    // Start is called before the first frame update
    void Start()
    {
        x = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("lane"))
        {

            x.PlayOneShot(rollingClip);

        }
        if (col.gameObject.CompareTag("pin"))
        {
            x.PlayOneShot(strikeClip);
        }
        if (col.gameObject.CompareTag("WallPines"))
        {
            gameObject.transform.position = positionRespawn;
        }
    }
}