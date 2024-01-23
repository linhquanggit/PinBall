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
        [SerializeField] private bool isActive ;
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
            if (Input.GetAxis(inputName)==1)
            {
                AudioManager.Instance.PlayFlipperSFXClip();
                motor.motorSpeed = -flipperForce; // Điều này tạo ra lực quay cho flipper khi nhấn nút
            }
            else
            {
                motor.motorSpeed = flipperForce; // Đặt ngược lại motorSpeed để flipper tự động trở về vị trí ban đầu khi không nhấn nút
            }

            hinge.motor = motor;

        }


    }
}
