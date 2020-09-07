

/*******************************************/
/*                  INCLUDES               */
/*******************************************/
using UnityEngine;

/*******************************************/
/*                   CLASS                 */
/*******************************************/
public class FollowCamera: MonoBehaviour {

	/***************************************/
	/*               MEMBERS               */
	/***************************************/
	public Transform followTarget;
	public float followSpeed;
	public float mouseSensitivity;

	/***************************************/
	/*              PROPERTIES             */
	/***************************************/


	/***************************************/
	/*               METHODS               */
	/***************************************/

	private void Awake() {
		transform.parent = null;
	}

	private void FixedUpdate() {
		//float horizontal = asfd;
		//transform.Rotate(Vector3.up * horizontal);
	}

	private void MoveRig() {
		transform.position = Vector3.Lerp(transform.position, followTarget.position, followSpeed * Time.deltaTime);
	}

	/***************************************/
	/*              COROUTINES             */
	/***************************************/
}
