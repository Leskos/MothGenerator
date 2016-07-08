using UnityEngine;
using System.Collections;
using PygmyMonkey;
using SVGImporter;

public class MothLimb : MonoBehaviour 
{

	private Moth moth;
	private SVGRenderer[] limbShapes;
	private int limbIndex;
	private Color limbColor;


	void Awake () 
	{
		limbShapes = gameObject.GetComponentsInChildren<SVGRenderer> ();
		randomiseShape ();
	}

	public void setMothReference( Moth mothObject )
	{
		moth = mothObject;
	}


	public void setShape( int shapeIndex )
	{
		foreach( SVGRenderer limb in limbShapes )
		{
			limb.gameObject.SetActive (false);
		}
		limbShapes [ shapeIndex % limbShapes.Length ].gameObject.SetActive (true);
	}

	public void setColour( Color newColour )
	{
		foreach( SVGRenderer limb in limbShapes )
		{
			limb.color = newColour;
		}
	}

	public void randomiseShape()
	{
		int activeLimb = Random.Range (0, limbShapes.Length);

		foreach( SVGRenderer limb in limbShapes )
		{
			limb.gameObject.SetActive (false);
		}

		limbShapes [ activeLimb ].gameObject.SetActive (true);
	}


	public void randomiseColour()
	{
		limbColor = moth.getRandomColour ();

		foreach( SVGRenderer limb in limbShapes )
		{
			limb.color = limbColor;
		}
	}

}
