using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This Script was inspired by a tutorial by Timmy Kokke
public abstract class GazeTarget : MonoBehaviour {

	public abstract void Act();
	public abstract string getInfoText();
}
