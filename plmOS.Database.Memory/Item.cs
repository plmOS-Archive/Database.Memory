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
    public class Item : IItem
    {
        public IItemType Type { get; private set; }

        public Guid ItemID { get; private set; }

        public Guid BranchID { get; private set; }

        public Guid VersionID { get; private set; }

        public Int64 Branched { get; private set; }

        public Int64 Versioned { get; private set; }

        public Int64 Superceded { get; internal set; }

        private Dictionary<PropertyType, Property> _properties;

        public IEnumerable<IProperty> Properties
        {
            get
            {
                return this._properties.Values;
            }
        }

        public void AddProperty(IPropertyType Type, object Value)
        {
            this._properties[(PropertyType)Type] = new Property((PropertyType)Type, Value);
        }

        internal Item(ItemType Type, Guid ItemID, Guid BranchID, Guid VersionID, Int64 Branched, Int64 Versioned)
        {
            this.Type = Type;
            this.ItemID = ItemID;
            this.BranchID = BranchID;
            this.VersionID = VersionID;
            this.Branched = Branched;
            this.Versioned = Versioned;
            this.Superceded = -1;
            this._properties = new Dictionary<PropertyType, Property>();
        }
    }
}
