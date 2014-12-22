using System;
using UnityEngine;

public class PlayerFlip : MonoBehaviour
{
	public bool StartFlipped = true;

	private int _left = -1;
	private int _right = 1;
	private const float Tolerance = 0.01f;

	private void Start()
	{
		if (StartFlipped)
		{
			_left = 1;
			_right = -1;
		}
	}

	private void Update()
	{
		var xPlayer = Input.GetAxis("Horizontal");
		if (Math.Abs(xPlayer) > Tolerance)
		{
			var scale = transform.localScale;
			if (xPlayer > 0f)
			{
				if (Math.Abs(transform.localScale.x - _left) > Tolerance)
				{
					scale.x = _left;
				}
			}
			else if (xPlayer < 0f)
			{
				if (Math.Abs(transform.localScale.x - _right) > Tolerance)
				{
					scale.x = _right;
				}
			}

			transform.localScale = scale;
		}
	}
}