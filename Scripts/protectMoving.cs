using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class protectMoving : MonoBehaviour
{
    [SerializeField] private GameObject protect;
    [SerializeField] private GameObject Magnet;

    private bool isMoving = false;
    private Vector3 targetPosition;
    void Start()
    {
    }
    void OnTriggerEnter(Collider col)
    {

        if (col.gameObject.CompareTag("ball") && !isMoving)
        {
            targetPosition = new Vector3(protect.transform.position.x, 0.51f, protect.transform.position.z);
            StartCoroutine(MoveAfterDelay());

        }
    }
    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            Magnet.SetActive(true);
            Vector3 target = new Vector3(targetPosition.x, targetPosition.y, protect.transform.position.z);
            protect.transform.position = Vector3.MoveTowards(protect.transform.position, target, Time.deltaTime);

            if (protect.transform.position.y == 0.51f)
            {
                isMoving = false;

            }

        }

    }


}
