using UnityEngine;
using System.Collections;

public class Protect_Moving_Z : MonoBehaviour
{
    [SerializeField] private GameObject protect;

    private bool isMoving = false;
    private Vector3 targetPosition;
    private Vector3 originalPosition;
    void Start()
    {
        originalPosition = protect.transform.position;
    }
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("ball") && !isMoving)
        {
            targetPosition = new Vector3(protect.transform.position.x, protect.transform.position.y, -18.44f);
            StartCoroutine(MoveAfterDelay());
        }
    }

    IEnumerator MoveAfterDelay()
    {
        yield return new WaitForSeconds(4f);
        isMoving = true;
    }

    void Update()
    {
        if (isMoving)
        {
            Vector3 target = new Vector3(targetPosition.x, protect.transform.position.y, targetPosition.z);
            protect.transform.position = Vector3.MoveTowards(protect.transform.position, target, Time.deltaTime);

            if (protect.transform.position.z == -18.44f)
            {
                isMoving = false;
                protect.transform.position = new Vector3(originalPosition.x, 1.09f, originalPosition.z);
            }
        }
    }
}