using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor( typeof( MothLimb ) )]
public class MothLimbEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		MothLimb limb = (MothLimb)target;

		if(GUILayout.Button("Randomise Shape"))
		{
			limb.randomiseShape();
		}

		if(GUILayout.Button("Randomise Colour"))
		{
			limb.randomiseColour();
		}
	}

}
