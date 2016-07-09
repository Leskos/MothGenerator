using UnityEngine;
using System.Collections;
using PygmyMonkey;
using SVGImporter;

public class Moth : MonoBehaviour 
{
	public enum BodyParts
	{
		BODY,
		ANTENNA,
		HEAD,
		BODY_COLOUR,
		LEG_TOP_LEFT,
		LEG_TOP_RIGHT,
		LEG_MID_LEFT,
		LEG_MID_RIGHT,
		LEG_BOTTOM_LEFT,
		LEG_BOTTOM_RIGHT,
		WING_LEFT,
		WING_RIGHT,
		WING_COLOUR_LEFT,
		WING_COLOUR_RIGHT
	}
	public MothLimb[] bodyParts = new MothLimb[ System.Enum.GetValues (typeof(BodyParts)).Length ];
	public string paletteName;


	void Start () 
	{
		foreach( MothLimb limb in bodyParts )
		{
			limb.setMothReference( this );
		}

		randomisePalette ();
		randomiseShapes ();
		randomiseColours ();
	}


	void Update()
	{
		if( Input.GetKeyDown( KeyCode.Alpha1 ) )
		{
			randomiseShapes ();
		}

		if( Input.GetKeyDown( KeyCode.Alpha2 ) )
		{
			randomiseColours ();
		}

		if( Input.GetKeyDown( KeyCode.Alpha3 ) )
		{
			randomisePalette ();
		}
	}
	

	public Color getRandomColour()
	{
		int colourIndex = Random.Range ( 0, PygmyMonkey.ColorPalette.ColorPaletteData.Singleton.fromName(paletteName).colorInfoList.Count );
		return PygmyMonkey.ColorPalette.ColorPaletteData.Singleton.fromName (paletteName).colorInfoList [colourIndex].color;
	}
		

	public void randomiseShapes()
	{
		foreach( MothLimb limb in bodyParts )
		{
			limb.randomiseShape ();
		}
	}


	public void randomiseColours()
	{
		Color colour1 = getRandomColour();
		Color colour2 = getRandomColour();
		Color colour3 = getRandomColour();
		Color colour4 = getRandomColour();

		bodyParts [ (int)BodyParts.HEAD              ].setColour( colour1 );
		bodyParts [ (int)BodyParts.ANTENNA           ].setColour( colour2 );
		bodyParts [ (int)BodyParts.BODY              ].setColour( colour4 );
		bodyParts [ (int)BodyParts.BODY_COLOUR       ].setColour( colour3 );
		bodyParts [ (int)BodyParts.LEG_TOP_LEFT      ].setColour( colour4 );
		bodyParts [ (int)BodyParts.LEG_TOP_RIGHT     ].setColour( colour4 );
		bodyParts [ (int)BodyParts.LEG_MID_LEFT      ].setColour( colour4 );
		bodyParts [ (int)BodyParts.LEG_MID_RIGHT     ].setColour( colour4 );
		bodyParts [ (int)BodyParts.LEG_BOTTOM_LEFT   ].setColour( colour4 );
		bodyParts [ (int)BodyParts.LEG_BOTTOM_RIGHT  ].setColour( colour4 );
		bodyParts [ (int)BodyParts.WING_LEFT         ].setColour( colour1 );
		bodyParts [ (int)BodyParts.WING_RIGHT        ].setColour( colour1 );
		bodyParts [ (int)BodyParts.WING_COLOUR_LEFT  ].setColour( colour2 );
		bodyParts [ (int)BodyParts.WING_COLOUR_RIGHT ].setColour( colour2 );
	}


	public void randomisePalette()
	{
		int paletteIndex = Random.Range( 0, PygmyMonkey.ColorPalette.ColorPaletteData.Singleton.colorPaletteList.Count );
		paletteName = PygmyMonkey.ColorPalette.ColorPaletteData.Singleton.colorPaletteList [paletteIndex].name;
		randomiseColours ();
	}

}
