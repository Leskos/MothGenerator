using UnityEngine;
using System.Collections;
using UnityEditor;


[CustomEditor( typeof( Moth ) )]
public class MothEditor : Editor {

	public override void OnInspectorGUI()
	{
		DrawDefaultInspector();

		Moth moth = (Moth)target;

		if(GUILayout.Button("Randomise Shapes"))
		{
			moth.randomiseShapes();
		}

		if(GUILayout.Button("Randomise Colours"))
		{
			moth.randomiseColours();
		}

		if(GUILayout.Button("Randomise Palette"))
		{
			moth.randomisePalette();
		}
	}

}
