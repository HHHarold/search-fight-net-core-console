using SearchFight.Models;
using System.Collections.Generic;

namespace SearchFight.IServices
{
    public interface ISearchEngineFight
    {
        SearchFightResult GetResult(IList<string> values);
    }
}
