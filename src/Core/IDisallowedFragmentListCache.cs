/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core
{
    public interface IDisallowedFragmentListCache
    {
        DisallowedFragmentList GetDisallowedFragmentList();

        Task<DisallowedFragmentList> GetDisallowedFragmentListAsync();
    }
}