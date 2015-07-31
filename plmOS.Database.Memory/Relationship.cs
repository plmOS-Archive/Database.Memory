using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plmOS.Database.Memory
{
    public class Relationship : Item, IRelationship
    {
        public IRelationshipType RelationshipType
        {
            get
            {
                return (RelationshipType)this.Type;
            }
        }

        public IItem Parent { get; private set; }

        public IItem Child { get; private set; }

        internal Relationship(RelationshipType Type, Guid ItemID, Guid BranchID, Guid VersionID, Int64 Branched, Int64 Versioned, Item Parent, Item Child)
            :base(Type, ItemID, BranchID, VersionID, Branched, Versioned)
        {
            this.Parent = Parent;
            this.Child = Child;
        }
    }
}
