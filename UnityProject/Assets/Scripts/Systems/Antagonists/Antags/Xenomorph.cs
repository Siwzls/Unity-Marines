using System;
using System.Threading.Tasks;
using Managers;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Antagonists
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Antagonist/Xenomorph")]
	public class Xenomorph : Antagonist
	{

		public override void AfterSpawn(ConnectedPlayer player)
		{
		}

	}

}