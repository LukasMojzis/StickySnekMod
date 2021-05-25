using TLDLoader;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Reflection;

namespace StickySnekMod
{
	public class StickySnek : Mod
	{
		// The ID of the mod - Should be unique
		public override string ID { get { return "StickySnek"; } }

		// The name of the mod that is displayed
		public override string Name { get { return "Sticky NOT A SNAKE"; } }

		// The name of the author
		public override string Author { get { return "LukasMojzis"; } }

		// Load on db load
		public override bool LoadInDB { get { return true; } }

		// The version of the mod
		public override string Version { get { return "1.0.0"; } }
		private GameObject goldBarPrefab = null;
		private GameObject armPrefab = null;
		Material goldBarMaterial;
		private GameObject siphonPrefab = null;
		string debugText = "";

		private void LimbFlip(GameObject arm)
		{
			// Left <> Right flip
			if (Random.value >= 0.5 || true)
			{
				var localScale = arm.transform.localScale;
				localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
				arm.transform.localScale = localScale;
			}
			
			// Arm <> Leg swap
			if (Random.value >= 0.5 || true)
			{
				// TODO
			}
		}
		//
		// public override void OnLoad()
		// {
		//
		// }
		
		public override void dbLoad()
		{

			debugText += "M:";
			debugText += (mainscript.M == null) ? "NULL" : "OK";
			debugText += '\n';
			debugText += "CumMats:";
			debugText += (typeof(mainscript)).GetFields().ToString();
			debugText += '\n';
			debugText += "butt\n";

			// foreach (mainscript.conditionmaterial conditionMaterial in )
			// {
			// 	if (conditionMaterial.tipus != "nyulsz01") continue;
			// 	foreach (Material bunnyFurMaterial in new Material[]
			// 	{
			// 		conditionMaterial.New,
			// 		conditionMaterial.Used,
			// 		conditionMaterial.Middle,
			// 		conditionMaterial.Old,
			// 		conditionMaterial.Rusty,
			// 	})
			// 	{
			// 		bunnyFurMaterial.EnableKeyword("_EMISSION");
			// 		bunnyFurMaterial.SetColor("_EmissionColor",Color.green * 10f);
			// 	}
			// }

			// GOLDBAR GLOWING: DONE
			if (goldBarPrefab == null)
			{
				goldBarPrefab = itemdatabase.d.ggold;
				Light goldBarLight;
				goldBarLight = goldBarPrefab.AddComponent<Light>();
				goldBarLight.intensity = 1;
				goldBarLight.color = Color.yellow;
				goldBarLight.range = 1;
				goldBarMaterial = goldBarPrefab.GetComponent<MeshRenderer>().material;


				goldBarMaterial.EnableKeyword("_EMISSION");
				goldBarMaterial.SetColor("_EmissionColor",Color.yellow * 0.5f);
			}


			GameObject bunnyPrefab = itemdatabase.d.cnyul;
			foreach (Component comp in bunnyPrefab.GetComponents<Component>())
			{
				debugText += comp.ToString();
				debugText += '\n';
			}
			GameObject nunnyFurObject = bunnyPrefab.GetComponentInChildren<SkinnedMeshRenderer>().gameObject;
			nunnyFurObject.AddComponent<Light>();

			
			mainscript.DistanceWrite(4000f);
			
			// TODO: randomize hands into {left,right}{arm,leg}
			if (armPrefab == null)
				armPrefab = itemdatabase.d.ghand01;

			// TODO: Make siphon hose end segments attachable
			if (siphonPrefab == null)
	            siphonPrefab = itemdatabase.d.gleszivocso;
		}

		// Called to draw the GUI
		public override void OnGUI()
		{
			GUI.Label(new Rect(0f, 0f, 1920f, 1080f), debugText);
		}

		public override void Update()
		{
		}
	}
}