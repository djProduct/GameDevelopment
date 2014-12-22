using UnityEngine;

public class OrbitTarget : MonoBehaviour
{
	public float OrbitSpeed = 100f;
	public Transform Target;

	private void Start()
	{
	}

	private void Update()
	{
		Target = Target ?? transform.parent;
		transform.RotateAround(Target.position, new Vector3(0f, 0f, 1f), OrbitSpeed*Time.deltaTime);
	}
}