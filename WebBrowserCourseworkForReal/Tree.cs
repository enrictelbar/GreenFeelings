using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBrowserCourseworkForReal
{
    class Tree
    {
        private String name;
        private double latitude;
        private double longitude;
        private String owner;
        private String description;
        private String address;
        private bool owned;


        /**
         * Constructor for tree
         */
        public Tree(String name, double latitude, double longitude, String owner, String description, String address, bool owned)
        {
            this.name = name;
            this.latitude = latitude;
            this.longitude = longitude;
            this.owner = owner;
            this.description = description;
            this.address = address;
            this.owned = owned;
        }

        /**
         * Buys the tree. If everything has gone well and the tree is not owned, returns true.
         * Else: returns false.
         */
        public bool buy(String newOwner)
        {
            if (owned)
            {
                return false;
            }
            this.owned = true;
            this.owner = newOwner;
            return true;
        }

        public String getName()
        {
            return this.name;
        }

        public double getLatitude()
        {
            return this.latitude;
        }

        public double getLongitude()
        {
            return this.longitude;
        }

        public String getOwner()
        {
            return this.owner;
        }

        public String getDescription()
        {
            return this.description;
        }

        public String getAddress()
        {
            return this.address;
        }

        public bool isOwned()
        {
            return this.owned;
        }
    }
}
