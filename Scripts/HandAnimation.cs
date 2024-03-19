using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;
    public Animator handAnimator;
    // Start is called before the first frame update
    void Animator(InputActionProperty Value, string AnimatorValue)
    {
        float handValue = Value.action.ReadValue<float>();
        handAnimator.SetFloat(AnimatorValue, handValue);
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Animator(triggerValue, "Trigger");
        Animator(gripValue, "Grip");
    }
}
