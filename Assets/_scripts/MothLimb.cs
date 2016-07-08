using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PygmyMonkey;
using SVGImporter;

public class MothLimb : MonoBehaviour 
{

	private Moth moth;
	public List<SVGRenderer> limbShapes;
	private int limbIndex;
	private Color limbColor;


	void Awake () 
	{

		// Necessary for limbShapes to initialise correctly
		foreach( GameObject childObject in gameObject.GetComponentsInChildren<GameObject>() )
		{
			childObject.SetActive (true);
		}

		limbShapes = new List<SVGRenderer>();

		SVGRenderer[] allChildren = gameObject.GetComponentsInChildren<SVGRenderer>(  );

		foreach (SVGRenderer child in allChildren ) 
		{
			if (child.gameObject.transform.parent.gameObject.name == gameObject.name ) 
			{
				Debug.Log (gameObject.name + " child - " + child.gameObject);
				limbShapes.Add (child);
			} 
			else 
			{
				Debug.Log (gameObject.name + " INVALID - " + child.gameObject);
			}

		}

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
	    limbShapes[ shapeIndex % limbShapes.Count ].gameObject.SetActive (true);
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
		int activeLimb = Random.Range (0, limbShapes.Count);

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
