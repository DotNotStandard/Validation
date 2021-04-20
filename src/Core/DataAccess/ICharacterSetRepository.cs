using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

// Generated from the built-in Scriban RepositoryInterface template

namespace DotNotStandard.Validation.Core.DataAccess
{
	public interface ICharacterSetRepository
	{

		IList<CharacterSetDTO> FetchList();

		Task<IList<CharacterSetDTO>> FetchListAsync();

	}
}