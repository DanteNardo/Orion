

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
[RequireComponent(typeof(WheelCollider))]
public class Wheel : MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	public GameObject wheelPrefab;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	public float Steering { get; set; }
	public float MotorTorque { get; set; }
	public float BrakeTorque { get; set; }
	private WheelCollider Collider { get; set; }
	private GameObject Model { get; set; } = null;

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Awake() {
		Collider = GetComponent<WheelCollider>();
		if (wheelPrefab != null) {
			Model = Instantiate(wheelPrefab, transform.position, Quaternion.identity);
			Model.transform.parent = gameObject.transform;
		}
	}

	public void FixedUpdate() {
		if (Collider == null) return;

		if (Model) {
			Collider.GetWorldPose(out Vector3 position, out Quaternion orientation);
			Model.transform.position = position;
			Model.transform.rotation = orientation;
		}

		Collider.steerAngle = Steering;
		Collider.motorTorque = MotorTorque;
		Collider.brakeTorque = BrakeTorque;
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
