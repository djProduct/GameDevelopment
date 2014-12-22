using UnityEngine;

public class Lightning : MonoBehaviour
{
	public float ArcLength = 1.0f;
	public float ArcVariation = 1.0f;
	public float Inaccuracy = 0.5f;
	public LineRenderer LineRend;
	public GameObject Target;
	public float TimeOfZap = 0.25f;
	public float ZapTimer;

	private void Start()
	{
		LineRend = gameObject.GetComponent<LineRenderer>();
		ZapTimer = 0;
		LineRend.SetVertexCount(1);
	}

	private void Update()
	{
		if (ZapTimer > 0)
		{
			var lastPoint = transform.position;
			var i = 1;

			LineRend.SetPosition(0, transform.position); //make the origin of the LR the same as the transform

			while (Vector3.Distance(Target.transform.position, lastPoint) > 3.0f)
			{
				//was the last arc not touching the target?
				LineRend.SetVertexCount(i + 1); //then we need a new vertex in our line renderer
				var fwd = Target.transform.position - lastPoint;

				//gives the direction to our target from the end of the last arc
				fwd.Normalize(); //makes the direction to scale
				fwd = Randomize(fwd, Inaccuracy); //we don't want a straight line to the target though
				fwd *= Random.Range(ArcLength*ArcVariation, ArcLength); //nature is never too uniform
				fwd += lastPoint; //point + distance * direction = new point. this is where our new arc ends
				LineRend.SetPosition(i, fwd); //this tells the line renderer where to draw to
				i++;
				lastPoint = fwd; //so we know where we are starting from for the next arc
			}

			LineRend.SetVertexCount(i + 1);
			LineRend.SetPosition(i, Target.transform.position);

			ZapTimer = ZapTimer - Time.deltaTime;
		}
		else
		{
			LineRend.SetVertexCount(1);
		}
	}

	private Vector3 Randomize(Vector3 newVector, float devation)
	{
		newVector += new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f))*devation;
		newVector.Normalize();

		return newVector;
	}

	public void ZapTarget(GameObject newTarget)
	{
		Target = newTarget;
		ZapTimer = TimeOfZap;
	}
}