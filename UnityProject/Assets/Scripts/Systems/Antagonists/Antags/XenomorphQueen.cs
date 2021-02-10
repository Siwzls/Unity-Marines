using System;
using System.Threading.Tasks;
using Managers;
using NaughtyAttributes;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Antagonists
{
	[CreateAssetMenu(menuName = "ScriptableObjects/Antagonist/XenomorphQueen")]
	public class XenomorphQueen : Antagonist
	{
		public override void AfterSpawn(ConnectedPlayer player)
		{
		}
	}
}