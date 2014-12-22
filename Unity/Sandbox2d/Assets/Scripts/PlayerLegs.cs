using System;
using UnityEngine;

public class PlayerLegs : MonoBehaviour
{
	private const float Tolerance = 0.01f;

	public float WalkSpeed = 8.0f;
	public float JogSpeed = 15.0f;
	public float RunSpeed = 25.0f;
	// Must double tap within half a second (by default)
	public float DoubleTapTime = 0.5f;
	// Time to wait between dashes
	public float DashWaitTime = 2.0f;

	// Time that the dash button was last pressed
	private float _lastDashButtonTime;
	// Time of the last dash
	private float _lastDashTime;

	// Use this for initialization
	private void Start()
	{
	}

	// Update is called once per frame
	private void Update()
	{
		var xPlayer = Input.GetAxis("Horizontal");
		Debug.Log(string.Format("Player Axis: {0}", xPlayer));

		var speed = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)
			? JogSpeed
			: WalkSpeed;
		if (Math.Abs(xPlayer) > Tolerance)
		{
			var position = transform.localPosition;
			var distance = Time.deltaTime * speed;
			if (xPlayer < 0f)
			{
				distance = -distance;
			}

			position.x += distance;
			transform.localPosition = position;
		}
	}
}