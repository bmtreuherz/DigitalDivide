using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GazeTargetLaptop : GazeTarget {

	public override void Act() {
		Debug.Log ("Act called on Laptop.");
	}
	public override string getInfoText() {

		return "Use laptop";
	}
}
