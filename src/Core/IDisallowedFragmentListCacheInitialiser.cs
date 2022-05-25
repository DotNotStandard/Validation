/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System;

namespace DotNotStandard.Validation.Core
{
    public interface IDisallowedFragmentListCacheInitialiser
    {
        void Initialise();

        void StartInitialisation();

        bool TryCompleteInitialisation(TimeSpan timeout);
    }
}