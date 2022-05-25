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
    /// <summary>
    /// The contract that a CharacterSetRepository factory must implement
    /// </summary>
    public interface ICharacterSetRepositoryFactory
    {
        ICharacterSetRepository CreateCharacterSetRepository();
    }
}
