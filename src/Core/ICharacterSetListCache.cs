/*
 * Copyright © 2022 DotNotStandard. All rights reserved.
 * 
 * See the LICENSE file in the root of the repo for licensing details.
 * 
 */
using System.Threading.Tasks;

namespace DotNotStandard.Validation.Core
{

    /// <summary>
    /// The contract that a character set list cache is required to fulfil
    /// </summary>
    public interface ICharacterSetListCache
    {
        CharacterSetList GetCharacterSetList();

        Task<CharacterSetList> GetCharacterSetListAsync();
    }
}