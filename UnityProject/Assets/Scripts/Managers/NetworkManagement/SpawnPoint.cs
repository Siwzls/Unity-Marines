using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Mirror;

namespace Systems.Spawns
{
	public class SpawnPoint : NetworkStartPosition
	{
		[SerializeField, FormerlySerializedAs("Department")]
		private SpawnPointCategory category = default;

		public static IEnumerable<Transform> GetPointsForCategory(SpawnPointCategory category)
		{
			return NetworkManager.startPositions.Select(x => x.transform)
				.Where(x => x.GetComponent<SpawnPoint>().category == category);
		}

		public static Transform GetRandomPointForLateSpawn()
		{
			return GetPointsForCategory(SpawnPointCategory.LateJoin).ToList().PickRandom();
		}

		public static Transform GetRandomPointForJob(JobType job)
		{
			Transform point;
			if (categoryByJob.ContainsKey(job) &&
			    (point = GetPointsForCategory(categoryByJob[job]).ToList().PickRandom()) != null)
			{
				return point;
			}

			// Default to arrivals if there is no mapped spawn point for this job!
			// Will still return null if there is no arrivals spawn points set (and people will just not spawn!).
			return GetRandomPointForLateSpawn();
		}

		private const string DEFAULT_SPAWNPOINT_ICON = "Mapping/mapping_x2.png";
		private string iconName => iconNames.ContainsKey(category) ? iconNames[category] : DEFAULT_SPAWNPOINT_ICON;

		private void OnDrawGizmos()
		{
			Gizmos.DrawIcon(transform.position, iconName);
		}

		private static readonly Dictionary<JobType, SpawnPointCategory> categoryByJob = new Dictionary<JobType, SpawnPointCategory>
		{
			{ JobType.COMMANDING_OFFICER, SpawnPointCategory.CommandingOfficer },
			{ JobType.EXECUTIFE_OFFICER, SpawnPointCategory.ExecutifeOfficer },
			{ JobType.STAFF_OFFICER, SpawnPointCategory.StaffOfficer },
			{ JobType.INTELLIGATE_OFFICER, SpawnPointCategory.IntelligateOfficer },
			{ JobType.PILOT_OFFICER, SpawnPointCategory.PilotOfficer },
			{ JobType.VEHICLE_CREWMAN, SpawnPointCategory.VehicleCrewman},
			{ JobType.SENIOR_ENLISTED, SpawnPointCategory.SeniorEnlisted },
			{ JobType.ADVISOR, SpawnPointCategory.Advisor },

			{ JobType.SQUAD_MARINE, SpawnPointCategory.SquadMarine},
		};

		private static readonly Dictionary<SpawnPointCategory, string> iconNames = new Dictionary<SpawnPointCategory, string>()
		{
			{SpawnPointCategory.SquadMarine, "Mapping/mapping_SquadMarine.png"},
		};

	}




	public enum SpawnPointCategory
	{
		SquadMarine,
		SquadEngineer,
		SquadMedic,
		SquadSmartgunner,
		SquadSpecialist,
		SquadLeader,
		Nurse,
		Doctor,
		Researcher,
		ChiefMedicalOfficer,
		RequisitionsOfficer,
		MaintenanceTechnician,
		OrdanceTechician,
		ChiefEngineer,
		MilitaryPolice,
		MilitaryWarden,
		ChiefMP,
		Synthentic,
		CorporateLiasion,
		Advisor,
		SeniorEnlisted,
		VehicleCrewman,
		IntelligateOfficer,
		PilotOfficer,
		StaffOfficer,
		ExecutifeOfficer,
		CommandingOfficer,
		Survivor,
		LateJoin
	}
}
