using System;
using System.Collections.Generic;
using Verse;
using RimWorld;

namespace FixingIllogicalIdeas
{
    // Token: 0x02000489 RID: 1161
    public class PawnCapacityWorker_ManipulationFixed : PawnCapacityWorker
    {
        // Token: 0x06001491 RID: 5265 RVA: 0x0009F084 File Offset: 0x0009D484
        public override float CalculateCapacityLevel(HediffSet diffSet, List<PawnCapacityUtility.CapacityImpactor> impactors = null)
        {
            float num = 0f;
            float num2 = PawnCapacityUtility.CalculateLimbEfficiency(diffSet, BodyPartTagDefOf.ManipulationLimbCore, BodyPartTagDefOf.ManipulationLimbSegment, BodyPartTagDefOf.ManipulationLimbDigit, 0.8f, out num, impactors);
            float num3 = num2;
            BodyPartTagDef tag = BodyPartTagDefOf.Spine;
            num2 = num3 * PawnCapacityUtility.CalculateTagEfficiency(diffSet, tag, float.MaxValue, default(FloatRange), impactors, -1f);
            return num2 * base.CalculateCapacityAndRecord(diffSet, PawnCapacityDefOf.Consciousness, impactors);
        }

        // Token: 0x06001492 RID: 5266 RVA: 0x0009F0C6 File Offset: 0x0009D4C6
        public override bool CanHaveCapacity(BodyDef body)
        {
            return body.HasPartWithTag(BodyPartTagDefOf.ManipulationLimbCore);
        }
    }
}
