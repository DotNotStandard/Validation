/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Collections.Generic;
using System.Text;

namespace DotNotStandard.Validation.Core.DataAccess
{
	public class CharacterSetDTO
	{

		public int CharacterSetId { get; set; }

		public string CharacterSetName { get; set; }

		public string CharacterSetDescription { get; set; }

		public string AllowedCharacters { get; set; }

	}
}
