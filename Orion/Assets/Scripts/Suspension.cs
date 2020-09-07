

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class Suspension: MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	[Range(0, 20)]
	public float naturalFrequency = 10;

	[Range(0, 3)]
	public float dampingRatio = 0.8f;

	[Range(-1, 1)]
	public float forceShift = 0.03f;

	public bool setSuspensionDistance = true;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	private Rigidbody SuspensionBody { get; set; }
	private WheelCollider[] WheelColliders { get; set; }

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Awake() {
		SuspensionBody = GetComponent<Rigidbody>();
		WheelColliders = GetComponentsInChildren<WheelCollider>();
	}

	private void FixedUpdate() {
		foreach (var wheel in WheelColliders) {

			//JointSpring spring = wc.suspensionSpring;

			//spring.spring = Mathf.Pow(Mathf.Sqrt(wc.sprungMass) * naturalFrequency, 2);
			//spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wc.sprungMass);

			//wc.suspensionSpring = spring;
			// ------------------------------------------------------------------------------
			// Calculate the spring force and damping for this wheel's suspension
			// ------------------------------------------------------------------------------
			// Natural Frequency(NF):     SQRT(k/m)
			// Spring Damping Ratio(SDR): 2*m*NF
			// Spring Constant(k):        (SQRT(m)*NF)^2
			// Spring Damping(SD):        2*dampingRatio*SQRT(k*m)
			// ------------------------------------------------------------------------------
			JointSpring spring = wheel.suspensionSpring;
			spring.spring = Mathf.Pow(Mathf.Sqrt(wheel.sprungMass) * naturalFrequency, 2);
			spring.damper = 2 * dampingRatio * Mathf.Sqrt(spring.spring * wheel.sprungMass);
			wheel.suspensionSpring = spring;

			// ------------------------------------------------------------------------------
			// Calculate application point of suspension force
			// ------------------------------------------------------------------------------
			// wheelRelative: The wheel's position relative to the entire vehicle
			// distance:      The vertical distance between the vehicle's center of mass and 
			//                the wheel's base. Used to determine wheel force calculation.
			// ------------------------------------------------------------------------------
			Vector3 wheelRelative = transform.InverseTransformPoint(wheel.transform.position);
			float distance = SuspensionBody.centerOfMass.y - wheelRelative.y + wheel.radius;
			wheel.forceAppPointDistance = distance - forceShift;

			// The following line makes sure the spring force at maximum droop is exactly zero
			if (spring.targetPosition > 0 && setSuspensionDistance)
				wheel.suspensionDistance = wheel.sprungMass * Physics.gravity.magnitude / (spring.targetPosition * spring.spring);
		}
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
