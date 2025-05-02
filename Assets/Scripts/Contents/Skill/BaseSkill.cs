using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenCover.Framework.Model;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.UI;
using UnityEngine;

namespace Skill
{
    public struct STSkill
    {
        public bool IsPossible;
        public string skillName;
        public int needActivePoint;
        public Define.SkillType type;
    }

    [Serializable]
    public abstract class BaseSkill
    {
        // protected STSkill SkillInfor;
        public string skillName { get; protected set; }
        public int needActivePoint { get; protected set; }
        public Define.SkillType type { get; protected set; }
        public bool IsPossible { get; protected set; }

        protected BaseUnit self;
        public abstract void EvaluateTarget(RaycastHit hit);
        public abstract void OnUpdate();
        // public abstract void Clear();
    }

    public class Move : BaseSkill
    {
        Vector3 destDir;
        public Move(BaseUnit self)
        {
            this.self = self;
            skillName = "Move";
            needActivePoint = 1;
            type = Define.SkillType.Move;
            IsPossible = false;
        }

        public override void EvaluateTarget(RaycastHit hit)
        {
            if (self.MoveSpeed >= Vector3.Distance(self.gameObject.transform.position, hit.point))
            {
                destDir = hit.point;
                // 거리에 따라 needActivePoint 값 변경 가능함 
                IsPossible = true;
            }
            else
            {
                IsPossible = false;
            }
            Debug.Log(IsPossible);
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(self.gameObject.transform.position, destDir) > 0.001f)
            {
                self.transform.position += (destDir - self.gameObject.transform.position).normalized * Time.deltaTime;
            }
            else
            {
                IsPossible = false;
            }
        }
    }

    public class AttackSkill : BaseSkill
    {
        public AttackSkill()
        {
            skillName = "Attack";
            needActivePoint = 2;
            type = Define.SkillType.Attack;
            IsPossible = false;
        }

        public override void EvaluateTarget(RaycastHit hit)
        {
            
        }

        public override void OnUpdate()
        {
        }
    }
}