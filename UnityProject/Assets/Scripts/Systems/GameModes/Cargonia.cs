using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameModes
{
	[CreateAssetMenu(menuName="ScriptableObjects/GameModes/Cargonia")]
	public class Cargonia : GameMode
	{
		private List<JobType> rebelJob;

		public override void SetupRound()
		{
			base.SetupRound();

			//Select a random department
			var rnd = new System.Random();
			var rebelDep = (Departments) rnd.Next(Enum.GetNames(typeof(Departments)).Length);
			rebelJob = rebelJobs[rebelDep];
			GameManager.Instance.Rebels = rebelJob;
			Logger.LogFormat("The using {0} as the rebel department!", Category.GameMode, rebelDep);

		}

		// TODO switch this for the Department ScriptableObjects
		private  enum Departments
		{
		}

		private readonly Dictionary<Departments, List<JobType>> rebelJobs = new Dictionary<Departments, List<JobType>>() {

		};

		protected override bool ShouldSpawnAntag(PlayerSpawnRequest spawnRequest)
		{
			return rebelJob.Contains(spawnRequest.RequestedOccupation.JobType);
		}
	}
}