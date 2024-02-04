using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PE07_grp4_Project.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string EventsEndpoint = $"{Prefix}/events";
        public static readonly string OrganisersEndpoint = $"{Prefix}/organisers";
    }
}
