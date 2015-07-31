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
    public class RelationshipType : ItemType, IRelationshipType
    {
        public IItemType ParentType { get; private set; }

        public IItemType ChildType { get; private set; }

        internal RelationshipType(ItemType Base, String Name, IItemType ParentType, IItemType ChildType)
            :base(Base, Name)
        {
            this.ParentType = ParentType;
            this.ChildType = ChildType;
        }

        internal RelationshipType(RelationshipType Base, String Name, IItemType ParentType, IItemType ChildType)
            : base(Base, Name)
        {
            this.ParentType = ParentType;
            this.ChildType = ChildType;
        }
    }
}
