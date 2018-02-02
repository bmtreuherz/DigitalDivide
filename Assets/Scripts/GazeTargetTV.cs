using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GazeTargetTV : GazeTarget {

	public override void Act() {
		Debug.Log ("Act called on TV.");
	}
	public override string getInfoText() {

		return "Watch TV";
	}
}
