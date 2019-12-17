using RoadStatus.Extensions;
using RoadStatus.Interfaces;
using RoadStatus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoadStatus.ApiHelper
{
    public class RoadStatusService : IRoadStatusService
    {
        private readonly IAsyncApiContext apiContext;

        public RoadStatusService(IAsyncApiContext apiContext)
        {
            this.apiContext = apiContext;
        }

        public async Task<string> GetRoadStatusAsync(ApiSettings settings, string roadName)
        {
            try
            {
                if(string.IsNullOrEmpty(roadName))
                {
                    throw new Exception("Please enter a road name and retry");
                }

                var actionUri = $"Road/{roadName}/?app_id={settings.AppID}&app_key={settings.ApiKey}";

                var apiCall = await apiContext.GetObjectsAsync<Road>
                    (settings.BaseAddress, actionUri);

                var roadStatus = apiCall.FirstOrDefault();

                return $"The status of the {roadStatus.DisplayName} is as follows\n" +
                     $"\t{DisplayName("StatusSeverity")} is {roadStatus.StatusSeverity}\n" +
                     $"\t{DisplayName("StatusSeverityDescription")} is {roadStatus.StatusSeverityDescription}";
            }

            catch (Exception ex)
            {
                if (ex.Message.Contains("404"))
                {
                   throw new Exception($"{roadName} is not a valid road");
                }

                throw;
            }
        }

        private static string DisplayName(string property)
        {
            return typeof(Road)
               .GetProperty(property)?
               .GetDisplayName().Replace("\"", "");
        }
    }
}
