using UnityEngine;
using KBEngine;
using System.Collections;

public class Common {
	public static LayerMask moveIgonreLayerMask = ~(1 << LayerMask.NameToLayer("kbentity"));
	public static LayerMask flyIgonreLayerMask = ~(1 << (LayerMask.NameToLayer("kbentity")) | 1 << (LayerMask.NameToLayer("building")));
	
	public static string safe_url(string path)
	{
#if UNITY_EDITOR
		return "file://" + Application.dataPath + path;
#endif

#if UNITY_WEBPLAYER
		return "http://" + KBEngineApp.app.getInitArgs().ip + path;
#endif

#if UNITY_IPHONE
		return "file://" + Application.dataPath + path;
#endif

#if UNITY_STANDALONE_OSX
		return "file://" + Application.dataPath + path;
#endif

#if UNITY_STANDALONE_WIN
		return "file://" + Application.dataPath + path;
#endif
	}
	
	public static string getPlatformDefines() 
	{
#if UNITY_EDITOR
		return "Unity Editor";
#endif

#if UNITY_IPHONE
		return "Iphone";
#endif

#if UNITY_STANDALONE_OSX
		return "Stand Alone OSX";
#endif

#if UNITY_STANDALONE_WIN
		return "Stand Alone Windows";
#endif
		
#if UNITY_WEBPLAYER
		return "webplayer";
#endif
	}
	
	public static void DEBUG_MSG(object s)
	{
		Debug.Log("[DEBUG]:" + s);
	}
	
	public static void WARNING_MSG(object s)
	{
		Debug.LogWarning("[WARNING]:" + s);
	}
	
	public static void ERROR_MSG(object s)
	{
		Debug.LogError("[ERROR]:" + s);
	}
	
	public static bool calcPositionY(Vector3 pos, out float outy, bool fly)
	{
		RaycastHit hit = new RaycastHit();
		
		LayerMask mask = moveIgonreLayerMask;
		if(fly)
			mask = flyIgonreLayerMask;
		
		float y = 1.0f;
		while(y > -50.0f)
		{
			Vector3 offset = new Vector3(0, y, 0);
			if (Physics.Raycast (pos + offset, -Vector3.up, out hit, 2.0f, mask)) 
			{
				outy = hit.point.y;
				return true;
			}
			
			y -= 0.1f;
		}

		y = -1.0f;
		while(y > 50.0f)
		{
			Vector3 offset = new Vector3(0, y, 0);
			if (Physics.Raycast (pos + offset, Vector3.up, out hit, 2.0f, mask)) 
			{
				outy = hit.point.y;
				return true;
			}
			
			y += 0.1f;
		}
		
		outy = pos.y;
		return false;
	}
}
