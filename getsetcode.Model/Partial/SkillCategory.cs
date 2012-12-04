using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace getsetcode.Model
{
    public partial class SkillCategory : IComparable, IComparer<SkillCategory>
    {
        #region Override Object methods

        public override bool Equals(object obj)
        {
            SkillCategory other = obj as SkillCategory;
            return other != null && SkillCategoryId.Equals(other.SkillCategoryId);
        }

        /// <summary>
        /// From http://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode
        /// </summary>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17, hash2 = 23; // 2 random prime numbers
                hash = hash * hash2 + SkillCategoryId.GetHashCode();
                hash = hash * hash2 + SkillCategoryText.GetHashCode();
                hash = hash * hash2 + Rank.GetHashCode();
                return hash;
            }
        }

        #endregion

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (obj is SkillCategory)
            {
                return SkillCategoryId.CompareTo((obj as SkillCategory).SkillCategoryId);
            }
            else
                throw new ArgumentException("Wrong data type.");
        }

        #endregion

        #region IComparer<SkillCategory> Members

        int IComparer<SkillCategory>.Compare(SkillCategory x, SkillCategory y)
        {
            return string.Compare(x.SkillCategoryId.ToString(), y.SkillCategoryId.ToString());
        }

        #endregion
    }
}
