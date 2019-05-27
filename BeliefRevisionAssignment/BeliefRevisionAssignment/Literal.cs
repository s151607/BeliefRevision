using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeliefRevisionAssignment
{
    class Literal
    {
        private String name;
        private Boolean exists;

        public Literal(String n, Boolean e)
        {
            name = n;
            exists = e;
        }

        public String getName()
        {
            return name;
        }

        public Boolean getExists()
        {
            return exists;
        }

        public override string ToString()
        {
            if (exists)
            {
                return name;
            }
            else
            {
                return "NOT(" + name + ")";
            }
        }

        public Boolean isEqual(Literal literal)
        {
            if(literal.getName() == name && literal.getExists() == exists)
            {
                return true;
            }
            else
            {
                return false;
            }
 
        }
    }
}
