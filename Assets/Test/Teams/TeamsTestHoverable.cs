﻿using System;
using UnityEngine;
using UnityEngine.UI;
using HexCasters.Core.Units.Teams;
using HexCasters.Hud.Teams;

namespace HexCasters.Testing.TeamsTest
{
	[RequireComponent(typeof(TeamMember))]
	public class TeamsTestHoverable : MonoBehaviour
	{
		public Image image;
		private TeamColor teamColor;

		void Start()
		{
			var team = GetComponent<TeamMember>().team;
			this.teamColor = team.GetComponent<TeamColor>();
			ErrorIfNoTeamColor();
		}

		void OnMouseOver()
		{
			this.image.color = this.teamColor.Color;
		}

		void ErrorIfNoTeamColor()
		{
			if (teamColor == null)
				throw new ArgumentException(
					"Team has no color");
		}
	}
}
