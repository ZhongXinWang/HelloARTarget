/**
* Copyright (c) 2015-2016 VisionStar Information Technology (Shanghai) Co., Ltd. All Rights Reserved.
* EasyAR is the registered trademark or trademark of VisionStar Information Technology (Shanghai) Co., Ltd in China
* and other countries for the augmented reality technology developed by VisionStar Information Technology (Shanghai) Co., Ltd.
*/
using UnityEngine;
namespace EasyAR
{
    public class MyImageTargetBehaviour : ImageTargetBaseBehaviour
    {

		protected override void Awake ()
		{
			base.Awake ();
			TargetFound += OnTargetFound;
			TargetLost += OnTargetLost;
			TargetLoad += OnTargetLoad;
			TargetUnload += OnTargetUnoad;
		}


		protected override void Start ()
		{
			base.Start ();
			hideTargetObjects (transform);
		}



		void showTargetObjects(Transform trans){
		

			for (int i = 0; i < trans.childCount; i++) {
			
				showTargetObjects(trans.GetChild(i));

			
			}

			if (trans != transform) {
			
				gameObject.SetActive(true);
			}

		
		}

		void hideTargetObjects(Transform trans){
		

			for (int i = 0; i < trans.childCount; i++) {
				
				hideTargetObjects(trans.GetChild(i));
				
				
			}
			
			if (trans != transform) {
				
				gameObject.SetActive(false);
			}

		
		}
		void OnTargetFound(ImageTargetBaseBehaviour behaviour){

			Debug.Log ("Found"+Target.Id);
			showTargetObjects (transform);
		}

		
		void OnTargetLost(ImageTargetBaseBehaviour behaviour){
			
			Debug.Log ("Lost"+Target.Id);

			hideTargetObjects (transform);
			
		}

		void OnTargetLoad(ImageTargetBaseBehaviour behaviour,ImageTrackerBaseBehaviour track,bool status){

			Debug.Log ("load"+Target.Id+"trachname="+track.name+"status"+status);

		}
		
		void OnTargetUnoad(ImageTargetBaseBehaviour behaviour,ImageTrackerBaseBehaviour track,bool status){
			
			Debug.Log ("unload"+Target.Id+"trachname="+track.name+"status"+status);
			
		}
    }
}
