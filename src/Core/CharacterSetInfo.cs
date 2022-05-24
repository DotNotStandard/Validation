/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;
using System.Threading.Tasks;
using DotNotStandard.Validation.Core.DataAccess;

namespace DotNotStandard.Validation.Core
{

	[Serializable]
	internal class CharacterSetInfo : ICloneable
	{

		private readonly int _characterSetId;
		private readonly string _characterSetName;
		private readonly string _allowedCharacters;

        #region Constructors

        internal CharacterSetInfo(CharacterSetDTO data)
        {
			_characterSetId = data.CharacterSetId;
			_characterSetName = data.CharacterSetName;
			_allowedCharacters = data.AllowedCharacters;
        }

        #endregion

        #region Exposed Properties and Methods

        public int CharacterSetId
		{
			get { return _characterSetId; }
		}

		public string CharacterSetName
		{
			get { return _characterSetName; }
		}

		public string AllowedCharacters
		{
			get { return _allowedCharacters; }
		}

		#region ICloneable Interface

		public object Clone()
		{
			return this.MemberwiseClone();
		}

		#endregion

		#endregion

	}
}