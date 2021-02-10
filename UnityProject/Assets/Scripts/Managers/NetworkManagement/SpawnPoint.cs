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

			{ JobType.CHIEF_MEDICAL_OFFICER, SpawnPointCategory.ChiefMedicalOfficer },
			{ JobType.RESEARCHER, SpawnPointCategory.Researcher },
			{ JobType.DOCTOR, SpawnPointCategory.Doctor },
			{ JobType.NURSE, SpawnPointCategory.Nurse },
			
			{ JobType.SQUAD_LEADER, SpawnPointCategory.SquadLeader },
			{ JobType.SQUAD_SPECIALIST, SpawnPointCategory.SquadSpecialist },
			{ JobType.SQUAD_SMARTGUNNER, SpawnPointCategory.SquadSmartgunner},
			{ JobType.SQUAD_MEDIC, SpawnPointCategory.SquadEngineer },
			{ JobType.SQUAD_ENGINEER, SpawnPointCategory.SquadEngineer },
			{ JobType.SQUAD_MARINE, SpawnPointCategory.SquadMarine },

			{ JobType.XENOMORPHQUEEN, SpawnPointCategory.XenomorphQueen },
			{ JobType.XENOMORPH, SpawnPointCategory.Xenomorph },
		};

		private static readonly Dictionary<SpawnPointCategory, string> iconNames = new Dictionary<SpawnPointCategory, string>()
		{
			{SpawnPointCategory.CommandingOfficer, "Mapping/mapping_commandingofficer.png" },
			{SpawnPointCategory.ExecutifeOfficer, "Mapping/mapping_executiveofficer.png" },
			{SpawnPointCategory.StaffOfficer, "Mapping/mapping_staffofficer.png" },
			{SpawnPointCategory.IntelligateOfficer, "Mapping/mapping_intelligateofficer.png" },
			{SpawnPointCategory.PilotOfficer, "Mapping/mapping_pilotofficer.png" },
			{SpawnPointCategory.VehicleCrewman, "Mapping/mapping_vehiclecrewmna.png" },
			{SpawnPointCategory.SeniorEnlisted, "Mapping/mapping_seniorenlisted.png" },

			{SpawnPointCategory.ChiefMedicalOfficer, "Mapping/mapping_chiefmedicalofficer.png" },
			{SpawnPointCategory.Researcher, "Mapping/mapping_researcher.png" },			
			{SpawnPointCategory.Doctor, "Mapping/mapping_doctor.png" },
			{SpawnPointCategory.Nurse, "Mapping/mapping_nurse.png" },

			{SpawnPointCategory.SquadLeader, "Mapping/mapping_squadleader.png" },
			{SpawnPointCategory.SquadSpecialist, "Mapping/mapping_squadspecialist.png" },
			{SpawnPointCategory.SquadSmartgunner, "Mapping/mapping_squadsmartgunner.png" },
			{SpawnPointCategory.SquadMedic, "Mapping/mapping_squadmedic.png" },
			{SpawnPointCategory.SquadEngineer, "Mapping/mapping_squadengineer.png" },
			{SpawnPointCategory.SquadMarine, "Mapping/mapping_SquadMarine.png"},

			{SpawnPointCategory.XenomorphQueen, "Mapping/mapping_xenomorphqueen.png" },
			{SpawnPointCategory.Xenomorph, "Mapping/mapping_xenomorph.png" },
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
		Xenomorph,
		XenomorphQueen,
		LateJoin
	}
}
