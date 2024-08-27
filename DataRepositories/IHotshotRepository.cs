using BT_COMMONS.Hotshot;
using BT_COMMONS.Operators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.DataRepositories;

public interface IHotshotRepository
{
    Task<List<HotshotCategory>> GetHotshotCategories();
}
