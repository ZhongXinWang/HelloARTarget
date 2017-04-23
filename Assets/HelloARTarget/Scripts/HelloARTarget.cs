using UnityEngine;
using System.Collections;
using System.Linq;
using EasyAR;

namespace EasyARTargets
{
	public class HelloARTarget : MonoBehaviour
	{

	
		//create target
		void createTarget (string name, out MyImageTargetBehaviour behaviour)
		{

			GameObject target = new GameObject (name);
			
			target.transform.localPosition = Vector3.zero;
			
			behaviour = target.AddComponent<MyImageTargetBehaviour> ();
		
		}
		void Start ()
		{
			
			MyImageTargetBehaviour behaviour;
			ImageTrackerBehaviour track = FindObjectOfType<ImageTrackerBehaviour> ();
			//动态加载一张识别图
			createTarget ("second",out behaviour);
			behaviour.Bind (track);
			behaviour.SetupWithImage ("stucard.png",StorageType.Assets,"second",new Vector2());
			GameObject duck = Instantiate (Resources.Load("duck1")) as GameObject;
			duck.transform.parent = behaviour.gameObject.transform;
	 

			//动态加载个.json文件配置的识别图片
			createTarget ("argame02",out behaviour);
			behaviour.Bind (track);

			//argame  最好和 .json文件里面的name一样,要不然只会加载文件，而不会设置size和name
			behaviour.SetupWithJsonFile ("targets.json",StorageType.Assets,"argame");
			GameObject duck2 = Instantiate (Resources.Load ("duck2")) as GameObject;

			duck2.transform.parent = behaviour.gameObject.transform;
			behaviour = null;

     

			//通过json字符串来加载一张识别图

			string jsonStr = @"
    {
     ""images"" :
     [
     {
     ""image"" : ""argame03.jpg"",
     ""name"" : ""argame03""
     }
     ]
     }";

			createTarget ("argame03",out behaviour);

			behaviour.Bind (track);
			//argame  最好和 .json文件里面的name一样,要不然只会加载文件，而不会设置size和name
			behaviour.SetupWithJsonString (jsonStr, StorageType.Assets, "argame03");

			GameObject duck3 = Instantiate (Resources.Load("duck1")) as GameObject;

			duck3.transform.parent = behaviour.gameObject.transform;//behaviour作为它父类的显示位置

		}



	}
}
