using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeliefRevisionAssignment
{
    class Clause
    {
        private List<Literal> literals;

        public Clause()
        {
            literals = new List<Literal>();
        }

        public void addLiteral(Literal l)
        {
            literals.Add(l);
        }

        public Boolean isEqual(Clause c)
        {
            int range = c.getLiterals().Count;
            int i = 0;
            foreach(Literal l in literals)
            {
                if (range == i) return true;
                else if (range < i) return false;
                else if (l != c.getLiterals()[i]) return false;
                i++;
            }
            return true;
        }

        public List<Literal> getLiterals()
        {
            return literals;
        }

        public void printClause()
        {
            String printValue = "";
            foreach(Literal l in literals)
            {
                if (l.getExists())
                {
                    printValue += l.getName() + " v ";
                }
                else
                {
                    printValue += "!" + l.getName()+ " v ";
                }
            }
            if(printValue.Length > 3)
            {
                printValue = printValue.Substring(0, printValue.Length - 3);
            }
            
            Console.WriteLine(printValue);
        }
    }
}
