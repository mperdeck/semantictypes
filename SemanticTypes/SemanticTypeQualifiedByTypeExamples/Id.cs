using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes.SemanticTypeQualifiedByTypeExamples
{
    public class Id<Q> : SemanticType<int, Id<Q>>
    {
        static Id()
        {
            IsValid = v => v > 0;
        }

        public Id(int id)
            : base(id)
        {
        }
    }
}
