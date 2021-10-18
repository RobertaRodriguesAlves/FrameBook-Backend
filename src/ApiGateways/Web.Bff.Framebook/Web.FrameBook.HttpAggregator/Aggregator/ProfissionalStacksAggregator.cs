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
    public class ProfissionalStacksAggregator : IDefinedAggregator
    {
        public Task<DownstreamResponse> Aggregate(List<HttpContext> responses)
        {

            ProfissionalStacksDTO result = new ProfissionalStacksDTO();
            result.profissionalDTO = responses[0].Items.DownstreamResponse().Content.ReadAsAsync<ProfissionalDTO>().Result;
            result.StacksExperiencia = responses[1].Items.DownstreamResponse().Content.ReadAsAsync<List<StacksDTO>>().Result;
            result.StacksDesejaAprender = responses[2].Items.DownstreamResponse().Content.ReadAsAsync<List<StacksDTO>>().Result;

            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new ObjectContent<ProfissionalStacksDTO>(result, new JsonMediaTypeFormatter());

            return Task.FromResult(new DownstreamResponse(response));
        }
    }
}