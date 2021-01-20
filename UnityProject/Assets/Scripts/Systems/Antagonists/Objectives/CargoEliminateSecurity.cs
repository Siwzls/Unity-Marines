using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Antagonists
{
	[CreateAssetMenu(menuName="ScriptableObjects/Objectives/CargoEliminateSecurity")]
	public class CargoEliminateSecurity : Objective
	{
		protected override void Setup()
		{
		}

		protected override bool CheckCompletion()
		{
			foreach (Transform t in GameManager.Instance.PrimaryEscapeShuttle.MatrixInfo.Objects.transform)
			{
				var player = t.GetComponent<PlayerScript>();
				if (player != null)
				{
					var playerDetails = PlayerList.Instance.Get(player.gameObject);
					if (playerDetails.Job == JobType.MILITARY_POLICE || playerDetails.Job == JobType.CHIEF_MP
					                                        		 || playerDetails.Job == JobType.MILITARY_WARDEN)
					{
						if(playerDetails.Script == null || playerDetails.Script.playerHealth == null) continue;
						if (!playerDetails.Script.playerHealth.IsDead)
						{
							return false;
						}
					}
				}
			}

			return true;
		}
	}
}