using Microsoft.AspNetCore.Http;
using Ocelot.Middleware;
using Ocelot.Multiplexer;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Web.FrameBook.HttpAggregator.Models;

namespace Web.FrameBook.HttpAggregator.Aggregator
{
    public class ProfessionalStacksAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {

            ProfessionalStacksDTO result = new ProfessionalStacksDTO();
            result.ProfessionalDTO = responses[0].Items.DownstreamResponse().Content.ReadAsAsync<ProfessionalDTO>().Result;
            result.StacksExperiencia = responses[1].Items.DownstreamResponse().Content.ReadAsAsync<List<StacksDTO>>().Result;
            result.StacksDesejaAprender = responses[2].Items.DownstreamResponse().Content.ReadAsAsync<List<StacksDTO>>().Result;

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new ObjectContent<ProfessionalStacksDTO>(result, new JsonMediaTypeFormatter());

            return Task.FromResult(new DownstreamResponse(response));
        }
    }
}