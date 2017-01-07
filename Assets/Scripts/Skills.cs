﻿using B83.ExpressionParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Skill
{
    public int id;
    public Google2u.SkillDataRow dataBaseSkill;
    private static ExpressionParser ep = new ExpressionParser();

    public Skill(int skillid)
    {
        this.id = skillid;
        dataBaseSkill = Google2u.SkillData.Instance.Rows.Find(x => x._ID == id);
    }

    string skillString;

    public void SubsituteTexts(ref Unit currentUnit, ref Unit unit)
    {
        skillString = skillString.Replace("{PPATT}", currentUnit.character.GetPAtt().ToString());
        skillString = skillString.Replace("{PMATT}", currentUnit.character.GetMAtt().ToString());
        skillString = skillString.Replace("{PPDEF}", currentUnit.character.GetPDef().ToString());
        skillString = skillString.Replace("{PSTR}", currentUnit.character.GetStr().ToString());
        skillString = skillString.Replace("{EPDEF}", unit.character.GetPDef().ToString());
        skillString = skillString.Replace(" ", "");
    }

    public bool EvaluateSkillEffect(ref Unit currentUnit, ref Unit unit)
    {
        skillString = dataBaseSkill._SkillFomular;
        SubsituteTexts(ref currentUnit, ref unit);
        int result = (int)ep.Evaluate(skillString);
        // do stuffs
        Debug.Log(string.Format("{0} hits {1} for {2} ({3})", currentUnit.GetUnitName(), unit.GetUnitName(), result, skillString));
        unit.HP -= 10;
        return dataBaseSkill._AnimationType.Contains("AnimType_MeleeTarget");
    }
}

