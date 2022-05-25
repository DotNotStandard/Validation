/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using DotNotStandard.Validation.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core.UnitTests.Fakes
{
    /// <summary>
    /// Fake implementation of ICharacterSetRepository that simply blocks for 120 seconds
    /// and then returns an empty list. Intended to simulate a slow repository for testing
    /// </summary>
    internal class FakeBlockingCharacterSetRepository : ICharacterSetRepository
    {
        public async Task<IList<CharacterSetDTO>> FetchListAsync()
        {
            await Task.Delay(TimeSpan.FromSeconds(30));
            return new List<CharacterSetDTO>();
        }
    }
}
