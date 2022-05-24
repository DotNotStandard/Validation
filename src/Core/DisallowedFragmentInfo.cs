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
	internal class DisallowedFragmentInfo : ICloneable
	{

		private readonly int _disallowedFragmentId;
		private readonly string _characterSetName;
		private readonly string _disallowedFragment;

        #region Constructors

        internal DisallowedFragmentInfo(DisallowedFragmentDTO data)
        {
			_disallowedFragmentId = data.DisallowedFragmentId;
			_characterSetName = data.CharacterSetName;
			_disallowedFragment = data.DisallowedFragment;
        }

        #endregion

        #region Exposed Properties and Methods

        public int DisallowedFragmentId
		{
			get { return _disallowedFragmentId; }
		}

		public string CharacterSetName
		{
			get { return _characterSetName; }
		}

		public string DisallowedFragment
		{
			get { return _disallowedFragment; }
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