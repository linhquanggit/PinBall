using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PinBall
{
    public class ArmController : MonoBehaviour
    {
        private HingeJoint2D hinge;
        private JointMotor2D motor;
        [SerializeField] private float flipperForce = 1000f;
        [SerializeField] private float lowerAngle ;
        [SerializeField] private float upperAngle ;
        [SerializeField] private string inputName ;
        [SerializeField] private bool onRightClick;
        [SerializeField] private bool isRight;

        private Vector3 mousePos;
        // Start is called before the first frame update
        void Start()
        {
            hinge = GetComponent<HingeJoint2D>();
            motor = hinge.motor;
            JointAngleLimits2D limits = hinge.limits;
            limits.min = lowerAngle; 
            limits.max = upperAngle; 
            hinge.limits = limits;
            hinge.useLimits = true;


        }

        void Update()
        {
            CheckPos();
            if(onRightClick == isRight)
            {
                Flip();
            }
             
        } 
        private void Flip()
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.Instance.PlayFlipperSFXClip();
                motor.motorSpeed = -flipperForce;
            }
            else if (Input.GetMouseButton(0))
            {
                motor.motorSpeed = -flipperForce;
            }
            else
            {
                motor.motorSpeed = flipperForce;
            }
            hinge.motor = motor;
        }
        private void CheckPos()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePos = Input.mousePosition;
                if(mousePos.x > Screen.width/2)
                {
                    onRightClick = true;
                }
                else
                {
                    onRightClick = false;
                }
            }
        }
    }
}
