

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;
using UnityEngine.InputSystem;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class RearWheelDrive: MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	public UnityCurve.UnityCurve angularVelocityPositive;
	public UnityCurve.UnityCurve angularVelocityNegative;
	public UnityCurve.UnityCurve motorTorque;
	public UnityCurve.UnityCurve brakeTorque;
	public float maxAngle = 30;
	public float maxTorque = 300;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	private WheelCollider[] WheelColliders { get; set; }
	private float Angle { get; set; }
	private float MotorTorque { get; set; }
	private float BrakeTorque { get; set; }

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Awake() {
		WheelColliders = GetComponentsInChildren<WheelCollider>();
	}

	private void FixedUpdate() {
		// ------------------------------------------------------------------------------
		// Get angle and torque from the ADSR input controllers
		// ------------------------------------------------------------------------------
		// angle:
		// torque:
		// ------------------------------------------------------------------------------
		UpdateAngle();
		UpdateTorque();

		foreach (WheelCollider wheel in WheelColliders) {
			// ------------------------------------------------------------------------------
			// Rear Wheel Drive Controls: front wheels steer and rear wheels drive forward
			// ------------------------------------------------------------------------------
			// !!!ASSUMPTION!!! wheels in positive z are "front" and negative x are "back"
			// ------------------------------------------------------------------------------
			if (wheel.transform.localPosition.z > 0) {
				wheel.steerAngle = Angle;
				if (Angle != 0) {
					Debug.Log("Angle:" + Angle);
				}
			}

			if (wheel.transform.localPosition.z < 0) {
				wheel.motorTorque = MotorTorque;
				//wheel.brakeTorque = BrakeTorque;
				if (MotorTorque != 0) {
					Debug.Log("MotorTorque:" + MotorTorque);
				}
				if (BrakeTorque != 0) {
					Debug.Log("BrakeTorque:" + BrakeTorque);
				}
			}
		}
	}

	private void UpdateAngle() {
		Angle = Mathf.Clamp(Angle + (float)angularVelocityPositive.Value + (float)angularVelocityNegative.Value, -maxAngle, maxAngle);
	}

	private void UpdateTorque() {
		MotorTorque = Mathf.Clamp((float)motorTorque.Value, 0, maxTorque);
		BrakeTorque = Mathf.Clamp((float)brakeTorque.Value, -maxTorque, 0);
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
