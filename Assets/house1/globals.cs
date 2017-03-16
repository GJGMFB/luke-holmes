using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class globals {
	public static bool item = false;

	public static bool Item {
		get {
			return item;
		}
		set {
			item = value;
		}
	}
}
