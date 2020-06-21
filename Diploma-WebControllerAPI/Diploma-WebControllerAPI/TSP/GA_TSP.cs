using System;
using System.Linq;
using System.Threading;

using System.IO;
using System.Collections.Generic;
using Diploma_WebControllerAPI.Models;

namespace Diploma_WebControllerAPI.TSP

{

    /// <summary>

    /// Summary description for Class1.

    /// </summary>

    public class GA_TSP

    {

        protected int cityCount;

        protected int populationSize;

        protected double mutationPercent;

        protected int matingPopulationSize;

        protected int favoredPopulationSize;

        protected int cutLength;

        protected int generation;

        protected Thread worker = null;

        protected bool started = false;

        protected City[] cities;

        protected Chromosome[] chromosomes;

        private string status = "";

        public GA_TSP(Container[] containers, Utility utility, RecycleFactory recycleFactory)

        {
            cityCount = containers.Length;
            populationSize = cityCount * 10;
            cities = new City[cityCount + 3];

            cities[0] = new City(utility);
            for (int i = 0; i < cityCount; i++)
            {
                cities[i + 1] = new City(containers[i]);
            }
            cities[cityCount + 1] = new City(recycleFactory);
            cities[cityCount + 2] = new City();
            //System.Diagnostics.Debug.WriteLine(cityCount.ToString() + " " + populationSize.ToString());
        }

        public int[] TestFlow()
        {
            var startList = cities.Select((c, index) => index).ToList();
            var startValue = double.MaxValue;

            foreach (var combo in Combinations(cities.Length, cities.Length - 1))
            {
                var newDistance = ArrayDistance(combo);

                if (newDistance < startValue)
                {
                    startValue = newDistance;
                    startList = combo.ToList();
                }
            }

            startList.Remove(cities.Length - 1);

            return startList.ToArray();
        }

        private IEnumerable<int[]> Combinations(int k, int n)
        {
            var result = new int[k];
            var stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value <= n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index == k)
                    {
                        yield return result;
                        break;
                    }
                }
            }
        }

        public double ArrayDistance(int[] indexes)
        {
            double distance = 0;

            for (int i = 0; i < indexes.Length - 1; i++)
                distance += cities[indexes[i]].proximity(cities[indexes[i + 1]]);

            return distance;
        }


        public void Initialization()

        {
            mutationPercent = 0.05;

            matingPopulationSize = populationSize / 2;

            favoredPopulationSize = matingPopulationSize / 2;

            cutLength = cityCount / 5;


            // create the initial chromosomes

            chromosomes = new Chromosome[populationSize];

            for (int i = 0; i < populationSize; i++)

            {

                chromosomes[i] = new Chromosome(cities);

                chromosomes[i].assignCut(cutLength);

                chromosomes[i].assignMutation(mutationPercent);

            }

            Chromosome.sortChromosomes(chromosomes, populationSize);

            started = true;

            generation = 0;

        }



        public int[] TSPCompute()

        {

            double thisCost = double.MaxValue - 1;

            double oldCost = 0.0;

            double dcost = double.MaxValue - 1;

            int countSame = 0;

            Random randObj = new Random();

            while (countSame < 120)

            {

                generation++;

                int ioffset = matingPopulationSize;

                int mutated = 0;

                for (int i = 0; i < favoredPopulationSize; i++)

                {

                    Chromosome cmother = chromosomes[i];

                    int father = (int)(randObj.NextDouble() * (double)matingPopulationSize);

                    Chromosome cfather = chromosomes[father];

                    mutated += cmother.mate(cfather, chromosomes[ioffset], chromosomes[ioffset + 1]);

                    ioffset += 2;

                }

                for (int i = 0; i < matingPopulationSize; i++)

                {

                    chromosomes[i] = chromosomes[i + matingPopulationSize];

                    chromosomes[i].calculateCost(cities);

                }

                // Now sort the new population

                Chromosome.sortChromosomes(chromosomes, matingPopulationSize);

                double cost = chromosomes[0].getCost();

                dcost = Math.Abs(cost - thisCost);

                thisCost = cost;

                double mutationRate = 100.0 * (double)mutated / (double)matingPopulationSize;

                //System.Diagnostics.Debug.WriteLine("Generation = " + generation.ToString() + " Cost = " + thisCost.ToString() + " Mutated Rate = " + mutationRate.ToString() + "%");

                if ((int)thisCost == (int)oldCost)

                {

                    countSame++;

                }

                else

                {

                    countSame = 0;

                    oldCost = thisCost;

                    //System.Console.WriteLine("oldCost = " + oldCost.ToString());

                }

            }

            var list = chromosomes[0].PrintCity(0, cities).ToList();
            list.Remove(cities.Length - 1);

            return list.ToArray();
        }

    }



    public class City

    {

        public City(Container container)

        {

            this.id = "Container" + container.Id;
            distances = new Dictionary<string, double>();

            using (var diplomaDbContext = new DiplomaDBContext())
            {
                var distancesDB = diplomaDbContext.ContainerDistances.Where(cd => cd.ContainerId == container.Id).Select(cd => cd.Distance).ToArray();
                foreach (var distance in distancesDB)
                {
                    var containerDistance = diplomaDbContext.ContainerDistances.Where(cd => cd.DistanceId == distance.Id && cd.ContainerId != container.Id).Single();
                    if (containerDistance.RecycleFactoryId.HasValue)
                        distances.Add("RecycleFactory", distance.Value);
                    else if (containerDistance.UtilityId.HasValue)
                        distances.Add("Utility", distance.Value);
                    else
                        distances.Add("Container" + containerDistance.ContainerId.Value, distance.Value);
                }
            }
        }

        public City(Utility utility)
        {
            this.id = "Utility";
            building = true;
            distances = new Dictionary<string, double>();

            using (var diplomaDbContext = new DiplomaDBContext())
            {
                var distancesDB = diplomaDbContext.ContainerDistances.Where(cd => cd.UtilityId == utility.Id).Select(cd => cd.Distance).ToArray();
                foreach (var distance in distancesDB)
                {
                    var containerDistance = diplomaDbContext.ContainerDistances.Where(cd => cd.DistanceId == distance.Id && cd.UtilityId != utility.Id).Single();
                    if (containerDistance.RecycleFactoryId.HasValue)
                        distances.Add("RecycleFactory", distance.Value);
                    else
                        distances.Add("Container" + containerDistance.ContainerId.Value, distance.Value);
                }
            }
        }

        public City(RecycleFactory recycleFactory)
        {
            this.id = "RecycleFactory";
            building = true;
            distances = new Dictionary<string, double>();

            using (var diplomaDbContext = new DiplomaDBContext())
            {
                var distancesDB = diplomaDbContext.ContainerDistances.Where(cd => cd.RecycleFactoryId == recycleFactory.Id).Select(cd => cd.Distance).ToArray();
                foreach (var distance in distancesDB)
                {
                    var containerDistance = diplomaDbContext.ContainerDistances.Where(cd => cd.DistanceId == distance.Id && cd.RecycleFactoryId != recycleFactory.Id).Single();
                    if (containerDistance.UtilityId.HasValue)
                        distances.Add("Utility", distance.Value);
                    else
                        distances.Add("Container" + containerDistance.ContainerId.Value, distance.Value);
                }
            }
        }

        public City()
        {
            id = "Extra";
            extra = true;
        }

        public string id;

        public bool extra = false;
        public bool building = false;
        private Dictionary<string, double> distances;


        // Returns the distance from the city to another city.

        public double proximity(City cother)
        {
            if (extra && cother.building || building && cother.extra)
                return 0;
            else if (extra && !cother.building || !building && cother.extra)
                return double.MaxValue;

            return distances[cother.id];
        }

    }

}
