using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_COMMONS.Hotshot;

public class HotshotCategory
{
    public int hscatid { get; set; }
    public string title { get; set; }
    public List<HotshotItem> items { get; set; }

    public HotshotCategory()
    {
        items = new List<HotshotItem>();
    }
}
