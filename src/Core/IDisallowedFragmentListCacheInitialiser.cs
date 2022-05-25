/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;

namespace DotNotStandard.Validation.Core
{
    /// <summary>
    /// The contract that a disallowed fragment list cache is required to fulfil in order
    /// to correctly support initialisation. Separated from the main contract so that 
    /// the members are less visible and distracting
    /// </summary>
    public interface IDisallowedFragmentListCacheInitialiser
    {
        void Initialise();

        void StartInitialisation();

        bool TryCompleteInitialisation(TimeSpan timeout);
    }
}