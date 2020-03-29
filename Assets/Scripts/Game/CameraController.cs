using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public float interpVelocity;
	public float minDistance;
	public float followDistance;
	public GameObject target;
	public GameObject player;
	public Vector3 offset;
	Vector3 targetPos;
	public static CameraController Instance { get { return _instance; } }
	private static CameraController _instance;

	private GameObject newTarget;
	private float keepDelay;

	void Awake()
	{
		if (_instance != null && _instance != this)
		{
			Destroy(this.gameObject);
		}
		else
		{
			enabled = true;
			_instance = this;
		}
	}
	void Start()
	{
		targetPos = transform.position;
	}

	void FixedUpdate()
	{
		if (target)
		{
			Vector3 posNoZ = transform.position;
			posNoZ.z = target.transform.position.z;

			Vector3 targetDirection = (target.transform.position - posNoZ);

			interpVelocity = targetDirection.magnitude * 10f;

			targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);
			transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.25f);

		}
	}
	public void SwitchTarget(GameObject target)
	{
		newTarget = target;
		StartCoroutine("SwitchTargetCoroutine");
	}
	public IEnumerator SwitchTargetCoroutine()
	{
		PlayerMovement.Instance.SetMovementEnabled(false);
		target = newTarget;
		yield return new WaitForSeconds(3);
		target = player;
		yield return new WaitForSeconds(1);
		PlayerMovement.Instance.SetMovementEnabled(true);
		GuideArrow.Instance.ReturnToBase();
	}
}
