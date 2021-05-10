using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Catapult : MonoBehaviour
{
    [SerializeField] private float _force;
    [SerializeField] private Text _text;
    private HingeJoint _joint;
    private bool _missleLanded = false;



    private void Awake()
    {
        GameEvents.OnCatpultClick += OnCatapultClickHandler;
        GameEvents.OnMissleLanded += OnMissleLandedHandler;
        _joint = GetComponent<HingeJoint>();

    }

    public void OnCatapultClickHandler()
    {
        if (_missleLanded) {
            _joint.useMotor = true;
            JointMotor motor = new JointMotor();
            motor.force = _force;
            motor.targetVelocity = _force;
            _joint.motor = motor;

        }
        
    }

    private void OnMissleLandedHandler()
    {
        _text.text = StringConstants.ClickOnCatapultMessage;
        _missleLanded = true;
    }

   

}
