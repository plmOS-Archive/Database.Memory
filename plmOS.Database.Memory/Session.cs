/*  
  plmOS Database Memory is a .NET library that implements an in memory plmOS Database.

  Copyright (C) 2015 Processwall Limited.

  This program is free software: you can redistribute it and/or modify
  it under the terms of the GNU Affero General Public License as published
  by the Free Software Foundation, either version 3 of the License, or
  (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU Affero General Public License for more details.

  You should have received a copy of the GNU Affero General Public License
  along with this program.  If not, see http://opensource.org/licenses/AGPL-3.0.
 
  Company: Processwall Limited
  Address: The Winnowing House, Mill Lane, Askham Richard, York, YO23 3NW, United Kingdom
  Tel:     +44 113 815 3440
  Email:   support@processwall.com
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plmOS.Database.Memory
{
    public class Session : ISession
    {
        private Dictionary<String, ItemType> ItemTypesCache;

        public IItemType CreateItemType(String Name)
        {
            return this.CreateItemType(null, Name);
        }

        public IItemType CreateItemType(IItemType Base, String Name)
        {
            ItemType itemtype = new ItemType((ItemType)Base, Name);
            this.ItemTypesCache[Name] = itemtype;
            return itemtype;
        }

        public IRelationshipType CreateRelationshipType(IItemType Base, String Name, IItemType ParentType, IItemType ChildType)
        {
            RelationshipType reltype = new RelationshipType((ItemType)Base, Name, ParentType, ChildType);
            this.ItemTypesCache[Name] = reltype;
            return reltype;
        }

        public IRelationshipType CreateRelationshipType(IRelationshipType Base, String Name, IItemType ParentType, IItemType ChildType)
        {
            RelationshipType reltype = new RelationshipType((RelationshipType)Base, Name, ParentType, ChildType);
            this.ItemTypesCache[Name] = reltype;
            return reltype;
        }

        public ITransaction BeginTransaction()
        {
            return new Transaction(this);
        }

        Dictionary<Guid, Item> ItemCache;

        public IItem Create(IItemType Type, Guid ItemID, Guid BranchID, Guid VersionID, Int64 Branched, Int64 Versioned, ITransaction Transaction)
        {
            Item item = new Item((ItemType)Type, ItemID, BranchID, VersionID, Branched, Versioned);
            this.ItemCache[item.VersionID] = item;
            return item;
        }

        public IRelationship Create(IRelationshipType Type, Guid ItemID, Guid BranchID, Guid VersionID, Int64 Branched, Int64 Versioned, IItem Parent, IItem Child, ITransaction Transaction)
        {
            Relationship rel = new Relationship((RelationshipType)Type, ItemID, BranchID, VersionID, Branched, Versioned, (Item)Parent, (Item)Child);
            this.ItemCache[rel.VersionID] = rel;
            return rel;
        }

        public void Supercede(Guid VersionID, Int64 Superceded, ITransaction Transaction)
        {
            this.ItemCache[VersionID].Superceded = Superceded;
        }

        public Session()
        {
            this.ItemTypesCache = new Dictionary<String, ItemType>();
            this.ItemCache = new Dictionary<Guid, Item>();
        }
    }
}
