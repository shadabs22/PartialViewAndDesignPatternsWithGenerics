using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForOOPS.CreationalPattern.Singleton
{

    /// <summary>
    /// MainApp startup class for Real-World 
    /// Singleton Design Pattern.
    /// </summary>
    class RealworldSingleton
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        void Main()
        {
            LoadBalancer1 b1 = LoadBalancer1.GetLoadBalancer();
            LoadBalancer1 b2 = LoadBalancer1.GetLoadBalancer();
            LoadBalancer1 b3 = LoadBalancer1.GetLoadBalancer();
            LoadBalancer1 b4 = LoadBalancer1.GetLoadBalancer();

            // Same instance?
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }

            // Load balance 15 server requests
            LoadBalancer1 balancer = LoadBalancer1.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string server = balancer.Server;
                Console.WriteLine("Dispatch Request to: " + server);
            }

            // Wait for user
            Console.ReadKey();
        }
    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    class LoadBalancer1
    {
        private static LoadBalancer1 _instance1;
        private List<string> _servers = new List<string>();
        private Random _random = new Random();

        // Lock synchronization object
        private static object syncLock = new object();

        // Constructor (protected)
        protected LoadBalancer1()
        {
            // List of available servers
            _servers.Add("ServerI");
            _servers.Add("ServerII");
            _servers.Add("ServerIII");
            _servers.Add("ServerIV");
            _servers.Add("ServerV");
        }

        public static LoadBalancer1 GetLoadBalancer()
        {
            // Support multithreaded applications through
            // 'Double checked locking' pattern which (once
            // the instance exists) avoids locking each
            // time the method is invoked
            if (_instance1 == null)
            {
                lock (syncLock)
                {
                    if (_instance1 == null)
                    {
                        _instance1 = new LoadBalancer1();
                    }
                }
            }

            return _instance1;
        }

        // Simple, but effective random load balancer
        public string Server
        {
            get
            {
                int r = _random.Next(_servers.Count);
                return _servers[r].ToString();
            }
        }
    }
}
