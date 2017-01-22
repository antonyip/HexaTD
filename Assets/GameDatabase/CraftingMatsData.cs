using System;
using System.Collections.Generic;
using System.Linq;

namespace AntTool
{
  public class CraftingMatsDataRow
  {
    public string _Name;
    public int _ID;
    public string _Sprite;
    public CraftingMatsDataRow(string Name,int ID,string Sprite)
    {
     _Name = Name;
     _ID = ID;
     _Sprite = Sprite;
    }
  } // class CraftingMatsDataRow
  public class CraftingMatsData
  {
    private CraftingMatsData()
    {
      Rows.Add(new CraftingMatsDataRow("Tree_Log",1,"Tree_Log_Image"));
    }

    private class NestedCraftingMatsData
    {
      static NestedCraftingMatsData(){}
      internal static readonly CraftingMatsData instance = new CraftingMatsData();
    }

    public static CraftingMatsData instance
    {
      get { return NestedCraftingMatsData.instance;}
    }

    public List<CraftingMatsDataRow> Rows = new List<CraftingMatsDataRow>();

  } // class CraftingMatsData
} // namespace AntTool
