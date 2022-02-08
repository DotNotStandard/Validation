/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Repositories.InMemoryRepository
{
	public class DisallowedFragmentRepository : IDisallowedFragmentRepository
	{

		#region IDisallowedFragmentRepository Implementation

		public IList<DisallowedFragmentDTO> FetchList()
		{
			IList<DisallowedFragmentDTO> fragments;

			// Create all of the disallowed fragments
			fragments = new List<DisallowedFragmentDTO>(10);
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 1,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "SQL Comment",
				DisallowedFragment = "--"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 2,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "Script opening tag",
				DisallowedFragment = "<script>"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 3,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "Script closing tag",
				DisallowedFragment = "</script>"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 4,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "Javascript opening tag",
				DisallowedFragment = "<javascript>"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 5,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "Javascript closing tag",
				DisallowedFragment = "</javascript>"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 6,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "ASP opening bee sting",
				DisallowedFragment = "<%"
			});
			fragments.Add(new DisallowedFragmentDTO
			{
				DisallowedFragmentId = 7,
				CharacterSetName = string.Empty,
				DisallowedFragmentDescription = "ASP closing bee sting",
				DisallowedFragment = "%>"
			});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 8,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 9,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 10,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 11,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 12,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 13,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 14,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});
			//fragments.Add(new DisallowedFragmentDTO
			//{
			//	DisallowedFragmentId = 15,
			//	CharacterSetName = string.Empty,
			//	DisallowedFragmentDescription = "",
			//	DisallowedFragment = ""
			//});

			return fragments;
		}

		public Task<IList<DisallowedFragmentDTO>> FetchListAsync()
		{
			return Task.FromResult(FetchList());
		}

		#endregion

		}
	}
