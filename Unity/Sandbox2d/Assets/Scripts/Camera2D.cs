using UnityEngine;

public class Camera2D : MonoBehaviour
{
	public float TextureSize = 100f;

	private float _unitsPerPixel;

	private void Start()
	{
		_unitsPerPixel = 1f/TextureSize;

		Camera.main.orthographicSize = (Screen.height/2f)*_unitsPerPixel;
	}
}