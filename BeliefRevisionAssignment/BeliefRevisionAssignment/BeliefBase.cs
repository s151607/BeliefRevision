using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeliefRevisionAssignment
{
    class BeliefBase
    {
        List<Clause> clauses;

        public BeliefBase()
        {
            clauses = new List<Clause>();
        }

        public void addClause(Clause c)
        {
            clauses.Add(c);
        }



       /* public Boolean entails(Clause c)
        {
            List<Clause> eClauses = new List<Clause>();
            eClauses.AddRange(clauses);
            eClauses.Add(c);

            List<Clause> resolvents = new List<Clause>();
            List<Clause> newClauses = new List<Clause>();

            while (true)
            {
                //For each pair of clauses that is not the same
                foreach(Clause clause1 in eClauses.ToList())
                {
                    foreach(Clause clause2 in eClauses.ToList())
                    {
                        if (!clause1.isEqual(clause2)){
                            //Add resolvents
                            resolvents.AddRange(resolve(clause1, clause2));

                            //Return true if it contains a clause with no literals
                            foreach(Clause clause in resolvents)
                            {
                                clause.printClause();
                                if (!clause.getLiterals().Any())
                                {
                                    return true;
                                }
                            }

                            newClauses.AddRange(resolvents);

                            //If newCluases is a subset of eClauses return false
                            if (!newClauses.Except(eClauses).Any()) return false;

                            eClauses.AddRange(newClauses);

                        }

                    }
                }
            }

        }*/


        public Boolean entails(Clause c)
        {
            List<Clause> resolvents = new List<Clause>();
            List<Clause> newClauses = new List<Clause>();
            List<Clause> eClauses = new List<Clause>();
            
            eClauses.AddRange(clauses);
            eClauses.Add(c);

            int range;

            while (true) {
                range = eClauses.Count;
                // For each unique pair of Clauses
                for (int i = 0; i < range - 1; i++)
                {
                    for (int j = i + 1; j < range; j++)
                    {
                        //Find resolvents
                        resolvents.AddRange(resolve(eClauses[i], eClauses[j]));
  
                        //Check if they contain an empty clause
                        foreach (Clause clause in resolvents)
                        {
                           if (!clause.getLiterals().Any()) return true;
                        }

                        newClauses.AddRange(resolvents);

                        //eClauses.AddRange(resolvents);
                        resolvents.Clear();
                    }
                    
                    //If newCluases is a subset of eClauses return false
                    //if (newClauses.Intersect(eClauses).Count() == newClauses.Count()) return false;
                }
                //if (newClauses.Intersect(eClauses).Count() == newClauses.Count()) return false;
                if (newClauses.All(i => eClauses.Contains(i))) return false;
                eClauses.AddRange(newClauses);
            }
        }

        private List<Clause> resolve(Clause ci, Clause cj)
        {
            int i = 0;
            int j = 0;
            List<(int, int)> matchingIndices = new List<(int, int)>();
            List<Clause> resolvants = new List<Clause>();
            //For each pair of literals in the two clauses
            foreach(Literal li in ci.getLiterals())
            {
                j = 0;
                foreach (Literal lj in cj.getLiterals())
                {
                    //If they contain a matching literal where one is negated and one is not
                    if(li.getName() == lj.getName() && li.getExists() != lj.getExists())
                    {
                        matchingIndices.Add((i, j));
                    }
                    j++;
                }
                i++;
            }
            
            //For each matchingIndex: combine the two clases where the two
            // literals corresponding to the indices are excluded.
            foreach((int,int) index in matchingIndices)
            {
                i = 0;
                j = 0;
                Clause resolvant = new Clause();

                foreach(Literal li in ci.getLiterals())
                {
                    if(i != index.Item1)
                    {
                        resolvant.addLiteral(li);
                    }
                    i++;
                }
                foreach(Literal lj in cj.getLiterals())
                {
                    if(j != index.Item2)
                    {
                        resolvant.addLiteral(lj);
                    }
                    j++;
                }
                resolvants.Add(resolvant);
            }

            return resolvants;
        }

    }
}
