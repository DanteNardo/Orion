

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
[RequireComponent(typeof(WheelCollider))]
public abstract class WheelController : MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	public GameObject wheelPrefab;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/
	protected WheelCollider Wheel { get; set; }
	private GameObject Model { get; set; } = null;

	/***************************************/
	/*               METHODS               */
	/***************************************/
	private void Awake() {
		Wheel = GetComponent<WheelCollider>();
		if (wheelPrefab != null) {
			Model = Instantiate(wheelPrefab, transform.position, Quaternion.identity);
			Model.transform.parent = gameObject.transform;
		}
	}

	public void FixedUpdate() {
		if (Wheel == null) return;

		if (Model) {
			Wheel.GetWorldPose(out Vector3 position, out Quaternion orientation);
			Model.transform.position = position;
			Model.transform.rotation = orientation;
		}
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
